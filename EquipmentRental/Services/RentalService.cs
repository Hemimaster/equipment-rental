using System.Collections.Generic;
using System.Linq;
using EquipmentRental.Common;
using EquipmentRental.Data;
using EquipmentRental.Domain;

namespace EquipmentRental.Services;

public class RentalService
{
    private readonly DataStore _dataStore;

    private readonly UserService _userService;

    private readonly EquipmentService _equipmentService;

    private readonly RentalPolicy _rentalPolicy;

    private readonly PenaltyCalculator _penaltyCalculator;

    public RentalService(
        DataStore dataStore,
        UserService userService,
        EquipmentService equipmentService,
        RentalPolicy rentalPolicy,
        PenaltyCalculator penaltyCalculator)
    {
        _dataStore = dataStore;
        _userService = userService;
        _equipmentService = equipmentService;
        _rentalPolicy = rentalPolicy;
        _penaltyCalculator = penaltyCalculator;
    }

    public OperationResult RentEquipment(int userId, int equipmentId, int days)
    {
        var user = _userService.GetById(userId);

        if (user == null)
        {
            return OperationResult.Fail("User not found.");
        }

        var equipment = _equipmentService.GetById(equipmentId);

        if (equipment == null)
        {
            return OperationResult.Fail("Equipment not found.");
        }

        if (equipment.Status != EquipmentStatus.Available)
        {
            return OperationResult.Fail("Equipment is not available.");
        }

        int activeRentalsCount = _dataStore.Rentals.Count(r => r.User.Id == userId && r.ReturnDate == null);

        if (!_rentalPolicy.CanUserRentMore(user, activeRentalsCount))
        {
            return OperationResult.Fail(_rentalPolicy.GetLimitExceededMessage(user));
        }

        int rentalId = _dataStore.GenerateRentalId();

        var rental = new Rental(rentalId, user, equipment, DateTime.Now, days);

        equipment.MarkAsRented();
        _dataStore.Rentals.Add(rental);

        return OperationResult.Ok("Equipment rented successfully.");
    }

    public OperationResult ReturnEquipment(int rentalId)
    {
        var rental = GetRentalById(rentalId);

        if (rental == null)
        {
            return OperationResult.Fail("Rental not found.");
        }

        if (rental.IsReturned)
        {
            return OperationResult.Fail("Equipment has already been returned.");
        }

        DateTime returnDate = DateTime.Now;
        decimal penalty = _penaltyCalculator.CalculatePenalty(rental.DueDate, returnDate);

        rental.MarkAsReturned(returnDate, penalty);
        rental.Equipment.MarkAsAvailable();

        return OperationResult.Ok($"Equipment returned successfully. Penalty: {penalty} PLN.");
    }

    public Rental? GetRentalById(int rentalId)
    {
        return _dataStore.Rentals.FirstOrDefault(r => r.Id == rentalId);
    }

    public List<Rental> GetAllRentals()
    {
        return _dataStore.Rentals;
    }

    public List<Rental> GetActiveRentals()
    {
        return _dataStore.Rentals
            .Where(r => r.ReturnDate == null)
            .ToList();
    }    
}