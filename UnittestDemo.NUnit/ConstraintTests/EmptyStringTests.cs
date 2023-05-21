namespace UnittestDemo.NUnit.ConstraintTests;

internal class EmptyStringTests
{
  [Test]
  [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1122:Use string.Empty for empty strings", Justification = "Just demo here")]
  public void FromExamples()
  {
    Assert.That("", Is.Empty);
    Assert.That(string.Empty, Is.Empty);
    Assert.That("A String", Is.Not.Empty);
  }
}
