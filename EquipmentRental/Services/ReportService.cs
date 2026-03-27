using System.Text;
using EquipmentRental.Data;
using EquipmentRental.Domain;

namespace EquipmentRental.Services;

public class ReportService
{
    private readonly DataStore _dataStore;

    public ReportService(DataStore dataStore)
    {
        _dataStore = dataStore;
    }

    public int GetTotalEquipmentCount()
    {
        return _dataStore.EquipmentItems.Count;
    }

    public int GetAvailableEquipmentCount()
    {
        return _dataStore.EquipmentItems.Count(e => e.Status == EquipmentStatus.Available);
    }

    public int GetRentedEquipmentCount()
    {
        return _dataStore.EquipmentItems.Count(e => e.Status == EquipmentStatus.Rented);
    }

    public int GetUnavailableEquipmentCount()
    {
        return _dataStore.EquipmentItems.Count(e => e.Status == EquipmentStatus.Unavailable);
    }

    public int GetActiveRentalsCount()
    {
        return _dataStore.Rentals.Count(r => r.IsActive);
    }

    public int GetOverdueRentalsCount()
    {
        return _dataStore.Rentals.Count(r => r.IsOverdue);
    }

    public decimal GetTotalPenaltiesAmount()
    {
        return _dataStore.Rentals.Sum(r => r.PenaltyAmount);
    }

    public string GenerateSummaryReport()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"Total equipment: {GetTotalEquipmentCount()}");
        sb.AppendLine($"Available equipment: {GetAvailableEquipmentCount()}");
        sb.AppendLine($"Rented equipment: {GetRentedEquipmentCount()}");
        sb.AppendLine($"Unavailable equipment: {GetUnavailableEquipmentCount()}");
        sb.AppendLine($"Active rentals: {GetActiveRentalsCount()}");
        sb.AppendLine($"Overdue rentals: {GetOverdueRentalsCount()}");
        sb.AppendLine($"Total penalties: {GetTotalPenaltiesAmount()} PLN");

        sb.AppendLine();
        sb.AppendLine("=== AVAILABLE EQUIPMENT DETAILS ===");
        var availableEquipment = _dataStore.EquipmentItems
            .Where(e => e.Status == EquipmentStatus.Available)
            .ToList();

        if (availableEquipment.Count == 0)
        {
            sb.AppendLine("No available equipment.");
        }
        else
        {
            foreach (var equipment in availableEquipment)
            {
                sb.AppendLine($"- {equipment.GetDisplayInfo()}");
            }
        }

        sb.AppendLine();
        sb.AppendLine("=== RENTED EQUIPMENT DETAILS ===");
        var rentedEquipment = _dataStore.EquipmentItems
            .Where(e => e.Status == EquipmentStatus.Rented)
            .ToList();

        if (rentedEquipment.Count == 0)
        {
            sb.AppendLine("No rented equipment.");
        }
        else
        {
            foreach (var equipment in rentedEquipment)
            {
                sb.AppendLine($"- {equipment.GetDisplayInfo()}");
            }
        }

        sb.AppendLine();
        sb.AppendLine("=== UNAVAILABLE EQUIPMENT DETAILS ===");
        var unavailableEquipment = _dataStore.EquipmentItems
            .Where(e => e.Status == EquipmentStatus.Unavailable)
            .ToList();

        if (unavailableEquipment.Count == 0)
        {
            sb.AppendLine("No unavailable equipment.");
        }
        else
        {
            foreach (var equipment in unavailableEquipment)
            {
                sb.AppendLine($"- {equipment.GetDisplayInfo()}");
            }
        }

        sb.AppendLine();
        sb.AppendLine("=== ACTIVE RENTALS DETAILS ===");
        var activeRentals = _dataStore.Rentals
            .Where(r => r.IsActive)
            .ToList();

        if (activeRentals.Count == 0)
        {
            sb.AppendLine("No active rentals.");
        }
        else
        {
            foreach (var rental in activeRentals)
            {
                sb.AppendLine(
                    $"- {rental.User.GetFullName()} rented {rental.Equipment.Name} " +
                    $"(Model: {rental.Equipment.Model}), rent date: {rental.RentDate:g}, due date: {rental.DueDate:g}");
            }
        }

        sb.AppendLine();
        sb.AppendLine("=== OVERDUE RENTALS DETAILS ===");
        var overdueRentals = _dataStore.Rentals
            .Where(r => r.IsOverdue)
            .ToList();

        if (overdueRentals.Count == 0)
        {
            sb.AppendLine("No overdue rentals.");
        }
        else
        {
            foreach (var rental in overdueRentals)
            {
                sb.AppendLine(
                    $"- {rental.User.GetFullName()} has overdue rental: {rental.Equipment.Name} " +
                    $"(due date: {rental.DueDate:g})");
            }
        }

        return sb.ToString();
    }
}