namespace UnittestDemo.NUnit.ConstraintTests;

internal class StartsWithTests
{
  [Test]
  public void FromExamples()
  {
    const string Phrase = "Make your tests fail before passing!";

    Assert.That(Phrase, Does.StartWith("Make"));
    Assert.That(Phrase, Does.StartWith("MAKE").IgnoreCase);
    Assert.That(Phrase, Does.Not.StartWith("Break"));
  }
}
