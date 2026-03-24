namespace EquipmentRental.Domain;

public class Employee : User
{
    public string EmployeeNumber { get; set; }

    public string Department { get; set; }

    public Employee(int id, string firstName, string lastName, string employeeNumber, string department)
        : base(id, firstName, lastName, UserType.Employee)
    {
        EmployeeNumber = employeeNumber;
        Department = department;
    }

    public override string GetDisplayInfo()
    {
        return $"{base.GetDisplayInfo()}, Employee Number: {EmployeeNumber}, Department: {Department}";
    }
}