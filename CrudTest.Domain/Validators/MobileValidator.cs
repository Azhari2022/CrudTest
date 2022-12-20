using CrudTest.Domain.Common;
using PhoneNumbers;

namespace CrudTest.Domain.Validators;

public static class MobileValidator
{
    public static bool IsValid(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;
        return ulong.TryParse(value, out var number) && IsValid(number);
    }

    public static bool IsValid(ulong value)
    {
        try
        {
            if (MobileUtil.Instance.GetNumberType(MobileUtil.Instance.Parse($"+{value}", null)) ==
                PhoneNumberType.MOBILE)
                return MobileUtil.Instance.IsValidNumber(MobileUtil.Instance.Parse($"+{value}", null));
        }
        catch
        {
            // ignored
        }

        return false;
    }
}