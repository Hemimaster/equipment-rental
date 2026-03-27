using EquipmentRental.Data;
using EquipmentRental.Services;

var dataStore = new DataStore();
var userService = new UserService(dataStore);
var equipmentService = new EquipmentService(dataStore);
var rentalPolicy = new RentalPolicy();
var penaltyCalculator = new PenaltyCalculator();
var rentalService = new RentalService(dataStore, userService, equipmentService, rentalPolicy, penaltyCalculator);
var reportService = new ReportService(dataStore);

Console.WriteLine("=================================");
Console.WriteLine("        EQUIPMENT RENTAL");
Console.WriteLine("=================================");

Console.WriteLine("\n=== ADD USERS ===");
Console.WriteLine(userService.AddStudent("Jan", "Kowalski", "S12345", "Computer Science").Message);
Console.WriteLine(userService.AddEmployee("Anna", "Nowak", "E54321", "IT Department").Message);

Console.WriteLine("\n=== USERS ===");
foreach (var user in userService.GetAllUsers())
{
    Console.WriteLine(user.GetDisplayInfo());
}

Console.WriteLine("\n=== ADD EQUIPMENT ===");
Console.WriteLine(equipmentService.AddLaptop("Dell Latitude", "Dell", "7420", 16, "Intel i7").Message);
Console.WriteLine(equipmentService.AddProjector("Epson Projector", "Epson", "EB-X49", "1920x1080", 3600).Message);
Console.WriteLine(equipmentService.AddCamera("Canon Camera", "Canon", "EOS 250D", 24, "Standard Lens").Message);

Console.WriteLine("\n=== ALL EQUIPMENT ===");
foreach (var equipment in equipmentService.GetAllEquipment())
{
    Console.WriteLine(equipment.GetDisplayInfo());
}

Console.WriteLine("\n=== AVAILABLE EQUIPMENT ===");
foreach (var equipment in equipmentService.GetAvailableEquipment())
{
    Console.WriteLine(equipment.GetDisplayInfo());
}

Console.WriteLine("\n=== CORRECT RENTAL ===");
Console.WriteLine(rentalService.RentEquipment(1, 1, 5).Message);

Console.WriteLine("\n=== INVALID OPERATION: EQUIPMENT NOT AVAILABLE ===");
Console.WriteLine(rentalService.RentEquipment(2, 1, 3).Message);

Console.WriteLine("\n=== SECOND RENTAL FOR STUDENT ===");
Console.WriteLine(rentalService.RentEquipment(1, 2, 2).Message);

Console.WriteLine("\n=== INVALID OPERATION: LIMIT EXCEEDED ===");
Console.WriteLine(rentalService.RentEquipment(1, 3, 1).Message);

Console.WriteLine("\n=== ACTIVE RENTALS FOR USER 1 ===");
foreach (var rental in rentalService.GetActiveRentalsForUser(1))
{
    Console.WriteLine(rental.GetDisplayInfo());
}

Console.WriteLine("\n=== RETURN ON TIME ===");
var firstRental = rentalService.GetRentalById(1);
if (firstRental != null)
{
    Console.WriteLine(rentalService.ReturnEquipment(1, firstRental.DueDate).Message);
}

Console.WriteLine("\n=== RENT CAMERA FOR EMPLOYEE ===");
Console.WriteLine(rentalService.RentEquipment(2, 3, 1).Message);

Console.WriteLine("\n=== SIMULATE OVERDUE RENTAL ===");
var thirdRental = rentalService.GetRentalById(3);
if (thirdRental != null)
{
    thirdRental.DueDate = DateTime.Now.AddDays(-2);
    Console.WriteLine("Rental 3 due date moved to the past for demo purposes.");
}

Console.WriteLine("\n=== OVERDUE RENTALS ===");
foreach (var rental in rentalService.GetOverdueRentals())
{
    Console.WriteLine(rental.GetDisplayInfo());
}

Console.WriteLine("\n=== LATE RETURN WITH PENALTY ===");
if (thirdRental != null)
{
    Console.WriteLine(rentalService.ReturnEquipment(3, DateTime.Now).Message);
}

Console.WriteLine("\n=== MARK EQUIPMENT AS UNAVAILABLE ===");
Console.WriteLine(equipmentService.MarkAsUnavailable(1).Message);

Console.WriteLine("\n=== ALL RENTALS ===");
foreach (var rental in rentalService.GetAllRentals())
{
    Console.WriteLine(rental.GetDisplayInfo());
}

Console.WriteLine("\n=== ACTIVE RENTALS ===");
foreach (var rental in rentalService.GetActiveRentals())
{
    Console.WriteLine(rental.GetDisplayInfo());
}

Console.WriteLine("\n=== FINAL EQUIPMENT STATE ===");
foreach (var equipment in equipmentService.GetAllEquipment())
{
    Console.WriteLine(equipment.GetDisplayInfo());
}

Console.WriteLine("\n=== FINAL REPORT ===");
Console.WriteLine(reportService.GenerateSummaryReport());