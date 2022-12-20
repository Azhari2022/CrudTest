using CrudTest.Domain.ValuesObjects;

namespace CrudTest.UnitTest;

public class MobileValidatorTest
{
    [Theory]
    [InlineData("+989121234567", true)]
    [InlineData("00989121234567", true)]
    [InlineData("+234234244", false)]
    [InlineData("+982132852174", false)]

    public void MobileValueObjectTest_WithExpectedResult(string phoneNumber, bool expectedResult)
    {
        bool testResult = MobileValueObject.TryFrom(phoneNumber,out _);
        Assert.Equal(expectedResult, testResult);
    }

   
}