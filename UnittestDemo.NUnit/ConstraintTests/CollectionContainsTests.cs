using System.Collections.ObjectModel;

namespace UnittestDemo.NUnit.ConstraintTests;

internal class CollectionContainsTests
{
  [TestCaseSource(nameof(SetOfIntegers))]
  public void FromExamplesWithIntegers(ICollection<int> list)
  {
    Assert.That(list, Has.Member(3));
    Assert.That(list, Does.Contain(3));
    Assert.That(list, Has.Some.EqualTo(3));
  }

  [TestCaseSource(nameof(SetOfStrings))]
  public void FromExamplesWithStrings(ICollection<string> list)
  {
    Assert.That(list, Has.Member("b"));
    Assert.That(list, Contains.Item("c"));
    Assert.That(list, Has.No.Member("x"));
    Assert.That(list, Has.Some.EqualTo("a"));
  }

  private static IEnumerable SetOfIntegers()
  {
    yield return new TestCaseData(arg: new int[] { 1, 2, 3 }).SetName("With int[]");
    yield return new TestCaseData(new List<int> { 1, 2, 3 }).SetName("With List<int>");
    yield return new TestCaseData(new Collection<int> { 1, 2, 3 }).SetName("With Collection<int>");
  }

  private static IEnumerable SetOfStrings()
  {
    yield return new TestCaseData(arg: new string[] { "a", "b", "c" }).SetName("With string[]");
    yield return new TestCaseData(new List<string> { "a", "b", "c" }).SetName("With List<string>");
    yield return new TestCaseData(new Collection<string> { "a", "b", "c" }).SetName("With Collection<string>");
  }
}
