namespace UnittestDemo.NUnit.ConstraintTests;

internal class DictionaryContainsValueTests
{
  [Test]
  public void FromExamples()
  {
    IDictionary<int, int> idict = new Dictionary<int, int> { { 1, 4 }, { 2, 5 } };

    Assert.That(idict, Contains.Value(4));
    Assert.That(idict, Does.ContainValue(5));
    Assert.That(idict, Does.Not.ContainValue(3));
  }
}
