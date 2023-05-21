namespace UnittestDemo.NUnit.ConstraintTests;

internal class DelayedTests
{
  [Test]
  public void AfterExample()
  {
    var now = DateTime.Now;
    Assert.That(() => DateTime.Now, Is.EqualTo(now.AddSeconds(4)).Within(TimeSpan.FromSeconds(0.1)).After(4).Seconds);
  }
}
