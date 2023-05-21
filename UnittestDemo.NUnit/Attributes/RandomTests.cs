namespace UnittestDemo.NUnit.Attributes;

public class RandomTests
{
  [Test]
  public void FromExamples(
    [Values(1, 2, 3)] int x,
    [Random(-1.0, 1.0, 5)] double d)
  {
    Assert.Pass("{0} {1:g2}", x, d);
  }
}
