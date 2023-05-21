namespace UnittestDemo.NUnit.ConstraintTests;

internal class LessThanTests
{
  [Test]
  public void FromExamples()
  {
    Assert.That(3, Is.LessThan(7));
    Assert.That(-5, Is.Negative);

    var p1 = new Person("Smith") { Salary = 10000 };
    var p2 = new Person("Jones") { Salary = 20000 };
    Assert.That(p1, Is.LessThan(p2).Using(new PersonSalaryComparer()));
  }
}
