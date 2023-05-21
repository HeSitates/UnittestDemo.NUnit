namespace UnittestDemo.NUnit.ConstraintTests;

internal class AssignableToTests
{
  [Test]
  public void FromExamples()
  {
    Assert.That("Hello", Is.AssignableTo(typeof(object)));
    Assert.That(5, Is.Not.AssignableTo(typeof(string)));
  }
}
