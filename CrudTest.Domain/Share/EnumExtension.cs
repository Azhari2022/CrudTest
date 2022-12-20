namespace CrudTest.Domain.Share;

public static class EnumExtension
{
    public static int Int(this Enum en)
    {
        return Convert.ToInt32(en);
    }
}