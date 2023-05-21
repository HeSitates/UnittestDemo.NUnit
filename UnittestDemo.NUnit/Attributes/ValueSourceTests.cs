namespace UnittestDemo.NUnit.Attributes;

public class ValueSourceTests
{
  private static readonly IEnumerable<string> _characters1 = new[] { "A", "B" };
  private static readonly IEnumerable<string> _characters2 = new[] { "C" };

  [Test]
  [Combinatorial]
  public void FromExamples(
    [ValueSource(nameof(SetOfIntegers))] int x,
    [ValueSource(nameof(_characters1))][ValueSource(nameof(_characters2))] string s)
  {
    Assert.Pass($"x: {x} - s: {s}");
  }

  private static IEnumerable SetOfIntegers()
  {
    yield return 1;
    yield return 2;
    yield return 3;
  }
}
