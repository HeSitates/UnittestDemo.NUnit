namespace UnittestDemo.NUnit.ConstraintTests;

internal class OrTests
{
  [TestCase(1)]
  [TestCase(2)]
  [TestCase(7)]
  [TestCase(10)]
  public void FromExamples(int actual)
  {
    Assert.That(actual, Is.LessThan(3).Or.GreaterThan(6));
    Assert.That(actual, Is.GreaterThan(3).Or.LessThan(11));
  }
}
