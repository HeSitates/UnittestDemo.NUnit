namespace UnittestDemo.NUnit.ConstraintTests;

internal class NullTests
{
  [Test]
  public void FromExamples()
  {
    object? anObject = null;
    Assert.That(anObject, Is.Null);

    anObject = new object();
    Assert.That(anObject, Is.Not.Null);
  }
}
