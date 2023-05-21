namespace UnittestDemo.NUnit.ConstraintTests;

internal class InstanceOfTypeTests
{
  [Test]
  public void FromExamples()
  {
    Assert.That("Hello", Is.InstanceOf(typeof(string)));
    Assert.That(5, Is.Not.InstanceOf(typeof(string)));

    Assert.That(5, Is.Not.InstanceOf<string>());

    var cat = new Cat();
    Assert.That(cat, Is.InstanceOf<Cat>());
    Assert.That(cat, Is.InstanceOf<Pet>());
    Assert.That(cat, Is.AssignableTo<Pet>());
  }
}
