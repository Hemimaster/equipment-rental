using EquipmentRental.Domain;

namespace EquipmentRental.Services;

public class RentalPolicy
{
    public int GetMaxActiveRentals(User user)
    {
        return user.UserType switch
        {
            UserType.Student => 2,
            UserType.Employee => 5,
            _ => 0
        };
    }

    public bool CanUserRentMore(User user, int currentActiveRentals)
    {
        int maxActiveRentals = GetMaxActiveRentals(user);
        return currentActiveRentals < maxActiveRentals;
    }

    public string GetLimitExceededMessage(User user)
    {
        int maxActiveRentals = GetMaxActiveRentals(user);
        return $"{user.GetFullName()} has reached the maximum number of active rentals: {maxActiveRentals}.";
    }
}