namespace UnittestDemo.NUnit.ConstraintTests;

internal class SameAsTests
{
  [Test]
  public void FromExamples()
  {
    var ex1 = new InvalidOperationException();

    // ReSharper disable once InlineTemporaryVariable
    var ex2 = ex1;

    Assert.That(ex2, Is.SameAs(ex1));

    var ex3 = new InvalidOperationException();
    Assert.That(ex3, Is.Not.SameAs(ex1));
    Assert.That(ex3, Is.Not.SameAs(ex2));
  }

  [Test]
  [SuppressMessage("Assertion", "NUnit2010:Use EqualConstraint for better assertion messages in case of failure", Justification = "Just to demonstrate.")]
  public void ExampleWithRecord()
  {
    var t1 = new Test("Some text");
    var t2 = new Test("Some text");

    Assert.That(t1 == t2, Is.True);
    Assert.That(t1, Is.EqualTo(t2));
    Assert.That(t1, Is.Not.SameAs(t2));
    Assert.That(t1.Name, Is.EqualTo("Some text"));
  }

  private record Test
  {
    public Test(string name) => Name = name;

    public string Name { get; set; }
  }
}
