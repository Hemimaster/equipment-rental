using System.Collections.Generic;
using System.Linq;
using EquipmentRental.Common;
using EquipmentRental.Data;
using EquipmentRental.Domain;

namespace EquipmentRental.Services;

public class EquipmentService
{
     private readonly DataStore _dataStore;


    public EquipmentService(DataStore dataStore)
    {
        _dataStore = dataStore;
    }

    public OperationResult AddLaptop(string name, string brand, string model, int ramGb, string processor)
    {
        int id = _dataStore.GenerateEquipmentId();

        var laptop = new Laptop(id, name, brand, model, ramGb, processor);

        _dataStore.EquipmentItems.Add(laptop);

        return OperationResult.Ok("Laptop added successfully.");
    }

    public OperationResult AddProjector(string name, string brand, string model, string resolution, int lumens)
    {
        int id = _dataStore.GenerateEquipmentId();

        var projector = new Projector(id, name, brand, model, resolution, lumens);

        _dataStore.EquipmentItems.Add(projector);

        return OperationResult.Ok("Projector added successfully.");
    }

    public OperationResult AddCamera(string name, string brand, string model, int megapixels, string lensType)
    {
        int id = _dataStore.GenerateEquipmentId();

        var camera = new Camera(id, name, brand, model, megapixels, lensType);

        _dataStore.EquipmentItems.Add(camera);

        return OperationResult.Ok("Camera added successfully.");
    }

    public Equipment? GetById(int equipmentId)
    {
        return _dataStore.EquipmentItems.FirstOrDefault(e => e.Id == equipmentId);
    }

    public List<Equipment> GetAllEquipment()
    {
        return _dataStore.EquipmentItems;
    }

    public List<Equipment> GetAvailableEquipment()
    {
        return _dataStore.EquipmentItems
            .Where(e => e.Status == EquipmentStatus.Available)
            .ToList();
    }

    public OperationResult MarkAsUnavailable(int equipmentId)
    {
        var equipment = GetById(equipmentId);

        if (equipment == null)
        {
            return OperationResult.Fail("Equipment not found.");
        }

        equipment.MarkAsUnavailable();

        return OperationResult.Ok("Equipment marked as unavailable.");
    }

    public OperationResult MarkAsAvailable(int equipmentId)
    {
        var equipment = GetById(equipmentId);

        if (equipment == null)
        {
            return OperationResult.Fail("Equipment not found.");
        }

        equipment.MarkAsAvailable();

        return OperationResult.Ok("Equipment marked as available.");
    }   
}