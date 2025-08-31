namespace UnittestDemo.NUnit.Attributes;

public class SequentialTests
{
  [Test]
  [Sequential]
  public void FromExamples(
    [Values(1, 2, 3)] int x,
    [Values("A", "B")] string s)
  {
    TestContext.Out.WriteLine("{0} {1}", x, s);
    Assert.Pass();
  }
}
