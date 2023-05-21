namespace UnittestDemo.NUnit.ConstraintTests;

internal class DictionaryContainsKeyTests
{
  [Test]
  public void FromExamples()
  {
    IDictionary<int, int> idict = new Dictionary<int, int> { { 1, 4 }, { 2, 5 } };

    Assert.That(idict, Contains.Key(1));
    Assert.That(idict, Contains.Key(1).WithValue(4));

    Assert.That(idict, Does.ContainKey(2));

    Assert.That(idict, Does.Not.ContainKey(3));
  }
}
