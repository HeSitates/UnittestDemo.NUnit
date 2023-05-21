namespace UnittestDemo.NUnit.ConstraintTests;

[SuppressMessage("Usage", "S125:Commented out code is an example how to NOT use it.", Justification = "Example how to not use it.")]
internal class AnyOfTests
{
  [Test]
  public void FromExamples()
  {
    const int Item = 42;
    Assert.That(Item, Is.AnyOf(0, -1, 42, 100));

    /*
     * Note: Is.AnyOf(iarray) does not work!
     * var iarray = new int[] { 0, -1, 42, 100 };
     * Assert.That(Item, Is.AnyOf(iarray));
     *
     * Use
     * Assert.That(iarray, Does.Contain(Item));
     */
  }
}
