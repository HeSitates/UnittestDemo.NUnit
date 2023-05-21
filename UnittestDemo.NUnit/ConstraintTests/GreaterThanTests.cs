namespace UnittestDemo.NUnit.ConstraintTests;

internal class GreaterThanTests
{
  [Test]
  public void FromExamples()
  {
    Assert.That(7, Is.GreaterThan(3));
    Assert.That(42, Is.Positive);

    var p1 = new Person("Smith") { Salary = 10000 };
    var p2 = new Person("Jones") { Salary = 20000 };
    Assert.That(p2, Is.GreaterThan(p1).Using(new PersonSalaryComparer()));
  }
}
