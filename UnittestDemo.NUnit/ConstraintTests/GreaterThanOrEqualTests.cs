namespace UnittestDemo.NUnit.ConstraintTests;

internal class GreaterThanOrEqualTests
{
  [TestCase(7)]
  public void FromExamples(int actual)
  {
    Assert.That(actual, Is.GreaterThanOrEqualTo(3));
    Assert.That(actual, Is.AtLeast(3));
    Assert.That(actual, Is.GreaterThanOrEqualTo(7));
    Assert.That(actual, Is.AtLeast(7));
  }

  [Test]
  public void WithPersonSalaryComparer()
  {
    var p1 = new Person("Smith") { Salary = 10000 };
    var p2 = new Person("Jones") { Salary = 20000 };
    var p3 = new Person("Walker") { Salary = 20000 };
    Assert.That(p2, Is.GreaterThanOrEqualTo(p1).Using(new PersonSalaryComparer()));
    Assert.That(p2, Is.GreaterThanOrEqualTo(p3).Using(new PersonSalaryComparer()));
  }
}
