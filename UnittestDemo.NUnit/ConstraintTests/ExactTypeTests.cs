namespace UnittestDemo.NUnit.ConstraintTests;

internal class ExactTypeTests
{
  [Test]
  public void FromExamples()
  {
    Assert.That("Hello", Is.TypeOf(typeof(string)));
    Assert.That("Hello", Is.Not.TypeOf(typeof(int)));

    Assert.That("World", Is.TypeOf<string>());

    var cat = new Cat();
    Assert.That(cat, Is.TypeOf<Cat>());
    Assert.That(cat, Is.Not.TypeOf<Pet>());
    Assert.That(cat, Is.InstanceOf<Pet>());
    Assert.That(cat, Is.AssignableTo<Pet>());
  }
}
