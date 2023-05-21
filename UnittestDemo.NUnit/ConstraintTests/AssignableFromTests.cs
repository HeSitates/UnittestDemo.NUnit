namespace UnittestDemo.NUnit.ConstraintTests;

internal class AssignableFromTests
{
  [Test]
  public void FromExamples()
  {
    Assert.That("Hello", Is.AssignableFrom(typeof(string)));
    Assert.That(5, Is.Not.AssignableFrom(typeof(string)));
  }
}
