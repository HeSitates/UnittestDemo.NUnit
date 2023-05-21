namespace UnittestDemo.NUnit.ConstraintTests;

internal class PropertyTests
{
  [Test]
  public void FromExamples()
  {
    var p1 = new Person("Smith") { Salary = 10000 };
    Assert.That(p1, Has.Property("LastName").EqualTo("Smith"));

    var p2 = new Person("Jones") { Salary = 20000 };
    Assert.That(p2, Has.Property("Salary").GreaterThan(10000));

    var list = new List<Person> { p1, p2 };
    Assert.That(list, Has.Count.EqualTo(2));
  }
}
