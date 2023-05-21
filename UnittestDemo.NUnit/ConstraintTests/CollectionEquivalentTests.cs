namespace UnittestDemo.NUnit.ConstraintTests;

internal class CollectionEquivalentTests
{
  [Test]
  public void FromExamples()
  {
    var iarray = new int[] { 1, 2, 3 };
    Assert.That(new int[] { 1, 2, 2 }, Is.Not.EquivalentTo(iarray));

    var sarray = new string[] { "a", "b", "c" };
    Assert.That(new string[] { "c", "a", "b" }, Is.EquivalentTo(sarray));
  }
}
