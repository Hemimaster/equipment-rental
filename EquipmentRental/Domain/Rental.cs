namespace EquipmentRental.Domain;

public class Rental
{
    public int Id { get; set; }

    public User User { get; set; }

    public Equipment Equipment { get; set; }

    public DateTime RentDate { get; set; }

    public int RentalDays { get; set; }

    public DateTime DueDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public decimal PenaltyAmount { get; set; }


    public bool IsReturned => ReturnDate != null;

    public bool IsActive => ReturnDate == null;

    public bool IsOverdue => DateTime.Now > DueDate && ReturnDate == null;

    public bool WasReturnedOnTime => ReturnDate != null && ReturnDate <= DueDate;


    public Rental(int id, User user, Equipment equipment, DateTime rentDate, int rentalDays)
    {
        Id = id;
        User = user;
        Equipment = equipment;
        RentDate = rentDate;
        RentalDays = rentalDays;
        DueDate = rentDate.AddDays(rentalDays);
        ReturnDate = null;
        PenaltyAmount = 0;
    }


    public void MarkAsReturned(DateTime returnDate, decimal penaltyAmount)
    {
        ReturnDate = returnDate;
        PenaltyAmount = penaltyAmount;
    }


    public string GetDisplayInfo()
    {
        string status = IsReturned ? "Returned" : "Active";

        return $"Rental ID: {Id}, User: {User.GetFullName()}, Equipment: {Equipment.Name}, " +
               $"Rent Date: {RentDate.ToShortDateString()}, Due Date: {DueDate.ToShortDateString()}, " +
               $"Status: {status}, Penalty: {PenaltyAmount}";
    }
}