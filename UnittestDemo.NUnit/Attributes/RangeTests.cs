namespace UnittestDemo.NUnit.Attributes;

public class RangeTests
{
  [Test]
  public void FromExamplesWithInteger(
    [Values(1, 2)] int x,
    [Range(0, 3)] int i)
  {
    Assert.Pass("{0} {1}", x, i);
  }

  [Test]
  public void FromExamplesWithIntegerAndStep(
    [Values(1, 2)] int x,
    [Range(0, 6, 2)] int i)
  {
    Assert.Pass("{0} {1}", x, i);
  }

  [Test]
  public void FromExamplesWithLong(
    [Values(1, 2)] int x,
    [Range(0, 3)] long i)
  {
    Assert.Pass("{0} {1}", x, i);
  }

  [Test]
  public void FromExamplesWithLongAndStep(
    [Values(1, 2)] int x,
    [Range(0, 6, 2)] long i)
  {
    Assert.Pass("{0} {1}", x, i);
  }

  [Test]
  public void FromExamplesWithDouble(
    [Values(1, 2)] int x,
    [Range(0.2, 0.7, 0.2)] double d)
  {
    Assert.Pass("{0} {1:g2}", x, d);
  }
}
