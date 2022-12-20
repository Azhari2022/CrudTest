using CrudTest.Domain.Validators;
using Throw;

namespace CrudTest.Domain.ValuesObjects;

public class EmailValueObject : ValueOf<string?, EmailValueObject>
{
    protected override void Validate()
    {
        TryValidate().Throw().IfFalse();
    }
    protected override bool TryValidate()
    {
        return Value != null && EmailValidator.IsValid(Value);
    }
}