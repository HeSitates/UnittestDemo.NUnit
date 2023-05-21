using System.Reflection;

namespace UnittestDemo.NUnit.ConstraintTests;

internal class ThrowsTests
{
  [Test]
  public void FromExamples()
  {
    Assert.That(() => SomeMethod(), Throws.TypeOf<ArgumentException>());
    Assert.That(() => SomeMethod(), Throws.Exception.TypeOf<ArgumentException>());

    Assert.That(() => SomeMethod(), Throws.TypeOf<ArgumentException>().With.Property("ParamName").EqualTo("myParam"));

    Assert.That(() => SomeMethod(), Throws.ArgumentException);

    Assert.That(OtherMethod, Throws.TargetInvocationException.With.InnerException.TypeOf<ArgumentException>());

    Assert.That(() => throw new ArgumentException("Just an example"), Throws.ArgumentException);
  }

  private static void SomeMethod(string? myParam = null)
  {
    if (myParam == null)
    {
      throw new ArgumentException("This is a message", nameof(myParam));
    }

    Console.WriteLine(myParam);
  }

  private static void OtherMethod() => throw new TargetInvocationException(new ArgumentException("This is a message"));
}
