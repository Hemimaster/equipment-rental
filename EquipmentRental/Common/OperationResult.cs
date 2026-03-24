namespace EquipmentRental.Common;

public class OperationResult
{
    public bool Success { get; set; }

    public string Message { get; set; }


    public OperationResult(bool success, string message)
    {
        Success = success;
        Message = message;
    }


    public static OperationResult Ok(string message)
    {
        return new OperationResult(true, message);
    }


    public static OperationResult Fail(string message)
    {
        return new OperationResult(false, message);
    }
}