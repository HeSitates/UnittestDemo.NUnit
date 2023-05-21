namespace UnittestDemo.NUnit.ConstraintTests;

internal class EmptyTests
{
  [Test]
  [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1122:Use string.Empty for empty strings", Justification = "Reviewed. Only as an example.")]
  public void FromExamples()
  {
    Assert.That("", Is.Empty);
    Assert.That(new Dictionary<int, int>(), Is.Empty);
    Assert.That(new List<string>(), Is.Empty);
  }

  [Test]
  public void CollectionExample()
  {
    IEnumerable<int> collection = new[] { 1, 2, 5, 8 };

    Assert.That(collection, Is.Not.Empty);
    Assert.That(collection.Count(), Is.EqualTo(4));
    Assert.That(collection.First(), Is.TypeOf<int>());

    // This does not work, although it compiles...
    //// Assert.That(collection, Is.Not.Empty.And.Count.EqualTo(4));
  }
}
