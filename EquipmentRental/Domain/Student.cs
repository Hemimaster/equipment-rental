namespace EquipmentRental.Domain;

public class Student : User
{
    public string StudentNumber { get; set; }

    public string Faculty { get; set; }


    public Student(int id, string firstName, string lastName, string studentNumber, string faculty)
        : base(id, firstName, lastName, UserType.Student)
    {
        StudentNumber = studentNumber;
        Faculty = faculty;
    }


    public override string GetDisplayInfo()
    {
        return $"{base.GetDisplayInfo()}, Student Number: {StudentNumber}, Faculty: {Faculty}";
    }
}