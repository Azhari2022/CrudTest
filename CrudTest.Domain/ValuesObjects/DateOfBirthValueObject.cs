using CrudTest.Domain.Validators;
using Throw;

namespace CrudTest.Domain.ValuesObjects;

public class DateOfBirthValueObject : ValueOf<string?, DateOfBirthValueObject>
{
    protected override void Validate()
    {
        TryValidate().Throw().IfFalse();
    }
    protected override bool TryValidate()
    {
        return Value != null && DateOfBirthValidator.IsValid(Value);
    }
    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;
        if (!DateOnly.TryParse(obj.ToString(), out DateOnly objDate1))
            return false;
        if (!DateOnly.TryParse(Value, out DateOnly objDate2))
            return false;
        if (objDate2 == objDate1) return true;
        return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}