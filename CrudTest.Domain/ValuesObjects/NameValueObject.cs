using CrudTest.Domain.Validators;
using Throw;

namespace CrudTest.Domain.ValuesObjects
{
    public class NameValueObject : ValueOf<string?, NameValueObject>
    {
        protected override void Validate()
        {
            TryValidate().Throw().IfFalse();
        }
        protected override bool TryValidate()
        {
            return Value != null && NameValidator.IsValid(Value);
        }
    }

}