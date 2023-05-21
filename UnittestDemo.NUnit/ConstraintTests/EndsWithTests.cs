namespace UnittestDemo.NUnit.ConstraintTests;

internal class EndsWithTests
{
  [Test]
  public void FromExamples()
  {
    const string Phrase = "Make your tests fail before passing!";

    Assert.That(Phrase, Does.EndWith("!"));
    Assert.That(Phrase, Does.EndWith("PASSING!").IgnoreCase);
  }
}
