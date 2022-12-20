using CrudTest.Domain.Validators;
using Throw;

namespace CrudTest.Domain.ValuesObjects;

public class MobileValueObject : ValueOf<ulong, MobileValueObject>
{
    protected override void Validate()
    {
        TryValidate().Throw().IfFalse();
    }
    protected override bool TryValidate()
    {
        return MobileValidator.IsValid($"+{Value}");
    }

    public static MobileValueObject From(string? item)
    {
        return From(ulong.Parse(item?.TrimStart('+') ?? string.Empty));
    }

    public static bool TryFrom(string item, out MobileValueObject thisValue)
    {

        return TryFrom(ulong.TryParse(item.TrimStart('+'), out var number) ? number : 0, out thisValue);
    }

    public override string ToString()
    {
        return $"+{Value}";
    }
}

