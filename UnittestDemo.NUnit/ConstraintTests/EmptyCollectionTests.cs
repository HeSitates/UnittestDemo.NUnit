using System.Collections.ObjectModel;

namespace UnittestDemo.NUnit.ConstraintTests;

internal class EmptyCollectionTests
{
  [TestCaseSource(nameof(EmptyExamples))]
  public void EmptyFromExamples(ICollection collection)
  {
    Assert.That(collection, Is.Empty);
  }

  [TestCaseSource(nameof(NonEmptyExamples))]
  public void NotEmptyFromExamples(ICollection collection)
  {
    Assert.That(collection, Is.Not.Empty);
  }

  private static IEnumerable EmptyExamples()
  {
    yield return new TestCaseData(Array.Empty<int>()).SetName("Array of int");
    yield return new TestCaseData(new List<int>()).SetName("List of int");
    yield return new TestCaseData(new Collection<string>()).SetName("Collection of string");
  }

  private static IEnumerable NonEmptyExamples()
  {
    yield return new TestCaseData(new int[] { 1, 2, 3 }).SetName("Array of int");
    yield return new TestCaseData(new List<int> { 1, 2, 3 }).SetName("List of int");
    yield return new TestCaseData(new Collection<string> { "1", "2", "3" }).SetName("Collection of string");
  }
}
