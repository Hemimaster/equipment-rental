namespace EquipmentRental.Domain;

public class Projector : Equipment
{
    public string Resolution { get; set; }

    public int Lumens { get; set; }

    public Projector(int id, string name, string brand, string model, string resolution, int lumens)
        : base(id, name, brand, model)
    {
        Resolution = resolution;
        Lumens = lumens;
    }

    public override string GetDisplayInfo()
    {
        return $"{base.GetDisplayInfo()}, Resolution: {Resolution}, Lumens: {Lumens}";
    }
}