namespace UnittestDemo.NUnit.ConstraintTests;

internal class SubstringTests
{
  [Test]
  public void FromExamples()
  {
    const string Phrase = "Make your tests fail before passing!";

    Assert.That(Phrase, Does.Contain("tests fail"));
    Assert.That(Phrase, Does.Not.Contain("tests pass"));
    Assert.That(Phrase, Does.Contain("make").IgnoreCase);
  }
}
