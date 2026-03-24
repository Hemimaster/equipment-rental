namespace EquipmentRental.Services;

public class PenaltyCalculator
{
    private const decimal DailyPenaltyRate = 5m;

    public int GetLateDays(DateTime dueDate, DateTime returnDate)
    {
        DateTime due = dueDate.Date;
        DateTime returned = returnDate.Date;

        if (returned <= due)
        {
            return 0;
        }

        return (returned - due).Days;
    }

    public decimal CalculatePenalty(DateTime dueDate, DateTime returnDate)
    {
        int lateDays = GetLateDays(dueDate, returnDate);
        return lateDays * DailyPenaltyRate;
    }
}