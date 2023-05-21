namespace UnittestDemo.NUnit.ConstraintTests;

internal class RangeTests
{
  [Test]
  public void FromExamples()
  {
    Assert.That(42, Is.InRange(1, 100));

    var iarray = new int[] { 1, 2, 3 };
    Assert.That(iarray, Is.All.InRange(1, 3));

    var list = new List<Person>
    {
      new Person("Smith") { Salary = 10000 },
      new Person("Jones") { Salary = 20000 },
      new Person("Walker") { Salary = 20000 },
    };

    Assert.That(list.Select(p => p.Salary).ToArray(), Is.All.InRange(10000, 20000));
  }
}
