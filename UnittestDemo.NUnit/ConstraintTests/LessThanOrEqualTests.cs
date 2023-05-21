namespace UnittestDemo.NUnit.ConstraintTests;

internal class LessThanOrEqualTests
{
  [TestCase(3)]
  public void FromExamples(int actual)
  {
    Assert.That(actual, Is.LessThanOrEqualTo(7));
    Assert.That(actual, Is.AtMost(7));
    Assert.That(actual, Is.LessThanOrEqualTo(3));
    Assert.That(actual, Is.AtMost(3));
  }

  [Test]
  public void WithPersonSalaryComparer()
  {
    var p1 = new Person("Smith") { Salary = 10000 };
    var p2 = new Person("Jones") { Salary = 20000 };
    var p3 = new Person("Walker") { Salary = 20000 };
    Assert.That(p1, Is.LessThanOrEqualTo(p2).Using(new PersonSalaryComparer()));
    Assert.That(p2, Is.LessThanOrEqualTo(p3).Using(new PersonSalaryComparer()));
  }
}
