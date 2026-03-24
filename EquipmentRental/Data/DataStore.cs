using System.Collections.Generic;
using EquipmentRental.Domain;

namespace EquipmentRental.Data;

public class DataStore
{
    public List<User> Users { get; set; }

    public List<Equipment> EquipmentItems { get; set; }

    public List<Rental> Rentals { get; set; }

    private int _userIdCounter;

    private int _equipmentIdCounter;

    private int _rentalIdCounter;

    public DataStore()
    {
        Users = new List<User>();
        EquipmentItems = new List<Equipment>();
        Rentals = new List<Rental>();

        _userIdCounter = 1;
        _equipmentIdCounter = 1;
        _rentalIdCounter = 1;
    }

    public int GenerateUserId()
    {
        return _userIdCounter++;
    }

    public int GenerateEquipmentId()
    {
        return _equipmentIdCounter++;
    }

    public int GenerateRentalId()
    {
        return _rentalIdCounter++;
    }
}