namespace UnittestDemo.NUnit.Attributes;

internal class PairwiseTests
{
  [Test]
  [Pairwise]
  public void FromExamples(
    [Values("a", "b", "c")] string a,
    [Values("+", "-")] string b,
    [Values("x", "y")] string c)
  {
    Assert.Pass("{0} {1} {2}", a, b, c);
  }
}
