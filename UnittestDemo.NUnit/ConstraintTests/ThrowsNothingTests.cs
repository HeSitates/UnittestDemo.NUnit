namespace UnittestDemo.NUnit.ConstraintTests;

internal class ThrowsNothingTests
{
  [Test]
  public void FromExamples()
  {
    Assert.That(() => SomeMethod("Ok"), Throws.Nothing);
  }

  private static void SomeMethod(string? myParam)
  {
    if (myParam == null)
    {
      throw new ArgumentException("This is a message", nameof(myParam));
    }

    Console.WriteLine(myParam);
  }
}
