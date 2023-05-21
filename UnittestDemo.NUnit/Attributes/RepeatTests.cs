namespace UnittestDemo.NUnit.Attributes;

public class RepeatTests
{
  private const int NumberOfRepeats = 50;
  private int _counter = 0;

  [Test]
  [Repeat(NumberOfRepeats)]
  public void FromExamples()
  {
    /*
     * Do not use Assert.Pass in combination with the repeat attribute as it will stop the repetition of the test.
     */
    var currentRepeatCount = TestContext.CurrentContext.CurrentRepeatCount;
    Assert.That(currentRepeatCount, Is.EqualTo(_counter++));
    Assert.That(currentRepeatCount, Is.InRange(0, NumberOfRepeats - 1));
  }
}
