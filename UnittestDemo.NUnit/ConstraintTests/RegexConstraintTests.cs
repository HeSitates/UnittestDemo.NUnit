namespace UnittestDemo.NUnit.ConstraintTests;

public class RegexConstraintTests
{
  [TestCase("Homer Simpson", "Homer.*")]
  [TestCase("Homer Simpson", "[hH]omer.*")]
  public void DoesMatchExample(string target, string pattern)
  {
    Assert.That(target, Does.Match(pattern));
  }

  [TestCase("Homer Simpson", "homer.*")]
  [TestCase("Homer Simpson", ".*simpson")]
  public void DoesMatchIgnoreCaseExample(string target, string pattern)
  {
    Assert.That(target, Does.Match(pattern).IgnoreCase);
  }
}
