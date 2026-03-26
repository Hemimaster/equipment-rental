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
        return
            $"Total equipment: {GetTotalEquipmentCount()}\n" +
            $"Available equipment: {GetAvailableEquipmentCount()}\n" +
            $"Rented equipment: {GetRentedEquipmentCount()}\n" +
            $"Unavailable equipment: {GetUnavailableEquipmentCount()}\n" +
            $"Active rentals: {GetActiveRentalsCount()}\n" +
            $"Overdue rentals: {GetOverdueRentalsCount()}\n" +
            $"Total penalties: {GetTotalPenaltiesAmount()} PLN";
    }
}