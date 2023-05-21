using NUnit.Framework.Constraints;

namespace UnittestDemo.NUnit.ConstraintTests;

internal class ReusableTests
{
  [Test]
  [Explicit("Only to demonstrate")]
  public void FromExamplesNormalConstraintFailsWhenReused()
  {
    Constraint myConstraint = Is.Not.Null;
    IResolveConstraint myConstraint2 = Is.Not.Null;

    Assert.Multiple(() =>
    {
      Assert.That("not a null", myConstraint);       // Passes, of course
      Assert.That("also not a null", myConstraint);  // Fails! What's that about?

      Assert.That("not a null", myConstraint2);      // Passes
      Assert.That("also not a null", myConstraint2); // Fails! What's that about?
    });
  }

  [Test]
  public void FromExamplesAndConstraintSucceedsWhenReused()
  {
    Constraint myConstraint = new AndConstraint(new NotConstraint(new NullConstraint()), new ExactTypeConstraint(typeof(string)));
    Assert.That("not a null", myConstraint); // Passes
    Assert.That("also not a null", myConstraint); // Passes
  }

  [TestCaseSource(nameof(ConstraintExamples))]
  public void FromExamplesReusableConstraintDoesNotFailWhenReused(IResolveConstraint myConstraint)
  {
    Assert.That("not a null", myConstraint); // Passes
    Assert.That("also not a null", myConstraint); // Passes
  }

  private static IEnumerable ConstraintExamples()
  {
    ReusableConstraint myConstraint = Is.Not.Null;
    yield return new TestCaseData(myConstraint).SetName("With variable");
    yield return new TestCaseData(new ReusableConstraint(Is.Not.Null)).SetName("With new");
    yield return new TestCaseData(new ReusableConstraint(Is.Not.Null.And.TypeOf<string>())).SetName("With new and two constraints");

    Constraint myConstraint2 = new AndConstraint(new NotConstraint(new NullConstraint()), new ExactTypeConstraint(typeof(string)));
    yield return new TestCaseData(myConstraint2).SetName("With and constraint");
  }
}
