namespace UnittestDemo.NUnit.ConstraintTests;

internal class AllItemsTests
{
  [Test]
  public void FromExamples()
  {
    var iarray = new int[] { 1, 2, 3 };
    Assert.That(iarray, Is.All.Not.Null);
    Assert.That(iarray, Is.All.GreaterThan(0));
    Assert.That(iarray, Has.All.GreaterThan(0));

    var sarray = new string[] { "a", "b", "c" };
    Assert.That(sarray, Is.All.InstanceOf<string>());
    Assert.That(sarray, Has.All.InstanceOf<string>());
  }
}
