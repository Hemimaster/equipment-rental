namespace EquipmentRental.Domain;

public abstract class Equipment
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Brand { get; set; }

    public string Model { get; set; }

    public EquipmentStatus Status { get; set; }

    protected Equipment(int id, string name, string brand, string model)
    {
        Id = id;
        Name = name;
        Brand = brand;
        Model = model;
        Status = EquipmentStatus.Available;
    }

    public void MarkAsAvailable()
    {
        Status = EquipmentStatus.Available;
    }

    public void MarkAsRented()
    {
        Status = EquipmentStatus.Rented;
    }

    public void MarkAsUnavailable()
    {
        Status = EquipmentStatus.Unavailable;
    }

    public virtual string GetDisplayInfo()
    {
        return $"{Name} ({Brand} {Model}) - Status: {Status}";
    }
}