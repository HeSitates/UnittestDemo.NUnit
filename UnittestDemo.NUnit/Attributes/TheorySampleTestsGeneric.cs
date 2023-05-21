namespace UnittestDemo.NUnit.Attributes;

[TestFixture(typeof(int))]
[TestFixture(typeof(double))]
[SuppressMessage("Usage", "IDE0052:Remove unread private member", Justification = "False positive")]
public class TheorySampleTestsGeneric<T>
{
  [Datapoint]
  private readonly double[] _arrayDouble1 = { 1.2, 3.4, 5.6, 7.8 };

  [Datapoint]
  private readonly double[] _arrayDouble2 = { 9.0, 10.1, 11.2, 12.3 };

  [Datapoint]
  private readonly int[] _arrayInt = { 0, 1, 2, 3 };

  [Theory]
  public void TestGenericForArbitraryArray(T[] array)
  {
    Assert.That(array, Has.Length.EqualTo(4));
  }
}
