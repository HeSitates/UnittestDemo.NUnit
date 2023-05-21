namespace UnittestDemo.NUnit.ConstraintTests;

internal class NaNTests
{
  [Test]
  public void FromExamplesIsNaN()
  {
    const double ADouble = double.NaN;
    Assert.That(ADouble, Is.NaN);
  }

  [TestCase(double.Epsilon)]
  [TestCase(double.MinValue)]
  [TestCase(double.MaxValue)]
  public void FromExamplesIsNotNaN([Random(-100, 100, 5)] double aDouble)
  {
    Assert.That(aDouble, Is.Not.NaN);
  }
}
