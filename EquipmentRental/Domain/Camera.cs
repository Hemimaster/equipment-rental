namespace EquipmentRental.Domain;

public class Camera : Equipment
{
    public int Megapixels { get; set; }

    public string LensType { get; set; }


    public Camera(int id, string name, string brand, string model, int megapixels, string lensType)
        : base(id, name, brand, model)
    {
        Megapixels = megapixels;
        LensType = lensType;
    }


    public override string GetDisplayInfo()
    {
        return $"{base.GetDisplayInfo()}, Megapixels: {Megapixels}, Lens type: {LensType}";
    }
}