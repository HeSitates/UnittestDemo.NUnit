namespace UnittestDemo.NUnit.ConstraintTests;

internal class NoItemTests
{
  [Test]
  public void FromExamples()
  {
    var iarray = new int[] { 1, 2, 3 };
    Assert.That(iarray, Has.None.Null);
    Assert.That(iarray, Has.None.LessThan(0));

    var sarray = new string[] { "a", "b", "c" };
    Assert.That(sarray, Has.None.EqualTo("d"));
  }
}
