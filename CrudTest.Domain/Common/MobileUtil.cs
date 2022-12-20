using PhoneNumbers;

namespace CrudTest.Domain.Common;

public static class MobileUtil
{
    public static readonly PhoneNumberUtil Instance;
    static MobileUtil()
    {
        Instance = PhoneNumberUtil.GetInstance();
    }
}
