namespace UnittestDemo.NUnit.Attributes;

[TestFixture]
[TestOf(typeof(Pet))]
public class TestOfTests
{
  [Test]
  [TestOf(typeof(Cat))]
  public void TestCat()
  {
    var sut = new Cat { Name = "Miau" };
    Assert.That(sut, Is.AssignableTo<Pet>());
    Pet pet = sut;
    Assert.That(pet.Name, Is.EqualTo("Miau"));
  }

  [Test(TestOf = typeof(Dog))]
  public void TestDog()
  {
    var sut = new Dog { Name = "Woef" };
    Assert.That(sut, Is.AssignableTo<Pet>());
    Pet pet = sut;
    Assert.That(pet.Name, Is.EqualTo("Woef"));
  }
}
