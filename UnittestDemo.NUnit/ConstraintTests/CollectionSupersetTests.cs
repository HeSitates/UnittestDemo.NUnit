namespace UnittestDemo.NUnit.ConstraintTests;

internal class CollectionSupersetTests
{
  [Test]
  public void FromExamples()
  {
    var iarray = new int[] { 1, 2, 3 };
    Assert.That(iarray, Is.SupersetOf(new int[] { 1, 3 }));
    Assert.That(iarray, Is.SupersetOf(new int[] { 3, 2 }));
    Assert.That(iarray, Is.SupersetOf(new int[] { 3, 1, 2 }));
  }
}
