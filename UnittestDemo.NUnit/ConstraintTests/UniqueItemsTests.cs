namespace UnittestDemo.NUnit.ConstraintTests;

internal class UniqueItemsTests
{
  [TestCaseSource(nameof(UniqueLists))]
  public void FromExamples(IEnumerable collection)
  {
    Assert.That(collection, Is.Unique);
  }

  private static IEnumerable UniqueLists()
  {
    yield return new TestCaseData(new int[] { 1, 2, 3 }).SetName("Array of ints");
    yield return new TestCaseData(new List<int> { 1, 2, 3 }).SetName("List of ints");
    yield return new TestCaseData(arg: new string[] { "a", "b", "c" }).SetName("Array of strings");
    yield return new TestCaseData(new List<string> { "a", "b", "c" }).SetName("List of strings");
  }
}
