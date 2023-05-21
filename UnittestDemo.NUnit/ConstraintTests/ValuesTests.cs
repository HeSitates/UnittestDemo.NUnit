namespace UnittestDemo.NUnit.ConstraintTests;

public class ValuesTests
{
  public enum MyEnumType
  {
    Value1,
    Value2 = 10,
  }

  [Test]
  public void MyEnumTest([Values] MyEnumType myEnumArgument)
  {
    var intValue = (int)myEnumArgument;
    switch (myEnumArgument)
    {
      case MyEnumType.Value1:
        Assert.That(intValue, Is.EqualTo(0));
        break;
      case MyEnumType.Value2:
        Assert.That(intValue, Is.EqualTo(10));
        break;
      default:
        throw new ArgumentOutOfRangeException(nameof(myEnumArgument), myEnumArgument, null);
    }
  }

  [Test]
  public void MyBoolTest([Values] bool value)
  {
    Assert.That(value, Is.True.Or.False);
  }
}
