namespace UnittestDemo.NUnit.ConstraintTests;

internal class CollectionSubsetTests
{
  [Test]
  public void FromExamples()
  {
    var iarray = new int[] { 1, 3 };
    Assert.That(iarray, Is.SubsetOf(new int[] { 1, 3 }));
    Assert.That(iarray, Is.SubsetOf(new int[] { 1, 2, 3 }));
    Assert.That(iarray, Is.SubsetOf(new int[] { 3, 1 }));
    Assert.That(iarray, Is.SubsetOf(new int[] { 3, 1, 4 }));

    Assert.That(iarray, Is.Not.SubsetOf(new int[] { 4 }));
  }
}
