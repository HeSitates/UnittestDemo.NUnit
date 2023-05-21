namespace UnittestDemo.NUnit.ConstraintTests;

internal class NotTests
{
  [Test]
  public void FromExamples()
  {
    Assert.That(2 + 2, Is.Not.EqualTo(5));

    var iarray = new int[] { 1, 2, 2, 3 };
    Assert.That(iarray, Is.Not.Unique);
  }
}
