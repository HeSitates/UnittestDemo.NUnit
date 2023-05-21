namespace UnittestDemo.NUnit;

public class MultipleAssertsTests
{
  [Test]
  public void MultipleAssertsDemo()
  {
    var result = SomeCalculator.DoCalculation();

    Assert.Multiple(() =>
    {
      Assert.That(result.RealPart, Is.EqualTo(5.2));
      Assert.That(result.ImaginaryPart, Is.EqualTo(3.9));
    });
  }
}
