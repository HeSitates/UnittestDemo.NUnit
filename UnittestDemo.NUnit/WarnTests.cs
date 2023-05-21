namespace UnittestDemo.NUnit;

internal class WarnTests
{
  [Test]
  public void FromExamples()
  {
    // Use Warn with reversed condition
    Warn.If(2 + 2 != 5);
    Warn.If(() => 2 + 2 != 5);
    Warn.If(2 + 2, Is.Not.EqualTo(5));
    Warn.If(() => 2 + 2, Is.Not.EqualTo(5).After(500));

    // Use Warn with original condition
    Warn.Unless(2 + 2 == 5);
    Warn.Unless(() => 2 + 2 == 5);
    Warn.Unless(2 + 2, Is.EqualTo(5));
    Warn.Unless(() => 2 + 2, Is.EqualTo(5).After(500));

    // Issue a warning message
    Assert.Warn("Warning message");
  }
}
