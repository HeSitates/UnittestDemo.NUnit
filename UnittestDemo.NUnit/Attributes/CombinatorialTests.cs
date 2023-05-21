namespace UnittestDemo.NUnit.Attributes;

public class CombinatorialTests
{
  [Test]
  [Combinatorial]
  public void FromExamples(
    [Values(1, 2, 3)] int x,
    [Values("A", "B")] string s) => Assert.Pass($"x: {x} - s: {s}");
}
