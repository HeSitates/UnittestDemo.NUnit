namespace UnittestDemo.NUnit.Attributes;

public class TheoryTests
{
  [DatapointSource]
  private readonly double[] _values = { 0.0, 1.0, -1.0, 42.0 };

  [Theory]
  public void SquareRootDefinition(double num)
  {
    Assume.That(num >= 0.0);

    var sqrt = Math.Sqrt(num);

    Assert.That(sqrt, Is.GreaterThanOrEqualTo(0.0));
    Assert.That(sqrt * sqrt, Is.EqualTo(num).Within(0.000001));
  }

  [Test]
  public void OnlyToRemoveWarning()
  {
    Assert.That(_values, Has.Length.EqualTo(4));
    Assert.That(_values, Has.ItemAt(1).EqualTo(1.0));
  }
}
