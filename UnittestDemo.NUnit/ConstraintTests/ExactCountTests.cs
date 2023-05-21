namespace UnittestDemo.NUnit.ConstraintTests;

internal class ExactCountTests
{
  [Test]
  public void FromExamples()
  {
    var array = new int[] { 1, 2, 3 };

    Assert.That(array, Has.Exactly(3).Items);
    Assert.That(array, Has.Exactly(2).Items.GreaterThan(1));
    Assert.That(array, Has.Exactly(3).LessThan(100));
    Assert.That(array, Has.Exactly(2).Items.EqualTo(1).Or.EqualTo(3));
    Assert.That(array, Has.Exactly(1).EqualTo(1).And.Exactly(1).EqualTo(3));
  }
}
