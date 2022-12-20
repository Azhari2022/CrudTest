namespace CrudTest.Domain.Validators;

public static class DateOfBirthValidator
{
    public static bool IsValid(string? value)
    {
        if (DateOnly.TryParse(value, out DateOnly dateOfBirth))
            return dateOfBirth > DateOnly.MinValue
                && dateOfBirth < DateOnly.FromDateTime(DateTime.UtcNow);
        return false;
    }
}
