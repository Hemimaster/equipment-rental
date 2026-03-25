using System.Collections.Generic;
using System.Linq;
using EquipmentRental.Common;
using EquipmentRental.Data;
using EquipmentRental.Domain;

namespace EquipmentRental.Services;

public class UserService
{
    private readonly DataStore _dataStore;

    public UserService(DataStore dataStore)
    {
        _dataStore = dataStore;
    }

    public OperationResult AddStudent(string firstName, string lastName, string studentNumber, string faculty)
    {
        int id = _dataStore.GenerateUserId();

        var student = new Student(id, firstName, lastName, studentNumber, faculty);

        _dataStore.Users.Add(student);

        return OperationResult.Ok("Student added successfully.");
    }

    public OperationResult AddEmployee(string firstName, string lastName, string employeeNumber, string department)
    {
        int id = _dataStore.GenerateUserId();

        var employee = new Employee(id, firstName, lastName, employeeNumber, department);

        _dataStore.Users.Add(employee);

        return OperationResult.Ok("Employee added successfully.");
    }

    public User? GetById(int userId)
    {
        return _dataStore.Users.FirstOrDefault(u => u.Id == userId);
    }

    public List<User> GetAllUsers()
    {
        return _dataStore.Users;
    }

    public bool Exists(int userId)
    {
        return _dataStore.Users.Any(u => u.Id == userId);
    }  
}