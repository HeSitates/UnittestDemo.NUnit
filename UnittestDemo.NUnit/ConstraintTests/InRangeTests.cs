namespace UnittestDemo.NUnit.ConstraintTests;

public class InRangeTests
{
  [Test]
  public void FromExamples()
  {
    Assert.That(42, Is.InRange(1, 100));

    var iarray = new[] { 1, 2, 3 };
    Assert.That(iarray, Is.All.InRange(1, 3));
  }
}
