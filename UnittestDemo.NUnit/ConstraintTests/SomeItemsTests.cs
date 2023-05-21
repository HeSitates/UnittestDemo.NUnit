namespace UnittestDemo.NUnit.ConstraintTests;

internal class SomeItemsTests
{
  [Test]
  public void FromExamples()
  {
    var iarray = new int[] { 1, 2, 3 };
    Assert.That(iarray, Has.Some.GreaterThan(2));

    var sarray = new string[] { "a", "b", "c" };
    Assert.That(sarray, Has.Some.Length.EqualTo(1));
  }
}
