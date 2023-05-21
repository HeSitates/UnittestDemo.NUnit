namespace UnittestDemo.NUnit.ConstraintTests;

[TestFixture(Description = "Showcasing the attribute constraint")]
internal class AttributeTests
{
  [Test]
  public void FromExamples()
  {
    Assert.That(typeof(AttributeTests), Has.Attribute(typeof(TestFixtureAttribute)));
    Assert.That(typeof(AttributeTests), Has.Attribute<TestFixtureAttribute>());

    Assert.That(typeof(AttributeTests), Has.Attribute(typeof(TestFixtureAttribute)).Property("Description").EqualTo("Showcasing the attribute constraint"));
    Assert.That(typeof(AttributeTests), Has.Attribute<TestFixtureAttribute>().Property("Author").EqualTo(null));
  }
}
