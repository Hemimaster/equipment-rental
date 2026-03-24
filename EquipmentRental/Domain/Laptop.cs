namespace EquipmentRental.Domain;

public class Laptop : Equipment
{
    public int RamGb { get; set; }

    public string Processor { get; set; }

    public Laptop(int id, string name, string brand, string model, int ramGb, string processor)
        : base(id, name, brand, model)
    {
        RamGb = ramGb;
        Processor = processor;
    }

    public override string GetDisplayInfo()
    {
        return $"{base.GetDisplayInfo()}, RAM: {RamGb} GB, Processor: {Processor}";
    }
}