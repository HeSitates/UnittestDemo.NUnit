namespace UnittestDemo.NUnit.Attributes;

public class SequentialTests
{
  [Test]
  [Sequential]
  public void FromExamples(
    [Values(1, 2, 3)] int x,
    [Values("A", "B")] string s)
  {
    Assert.Pass("{0} {1}", x, s);
  }
}
