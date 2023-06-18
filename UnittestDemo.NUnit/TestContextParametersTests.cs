namespace UnittestDemo.NUnit;

internal class TestContextParametersTests
{
  [Test]
  public void TestContextParametersShouldContainParametersFromRunsettingsFile()
  {
    static void AssertParameter(TestParameters testParameters, string paramName, string expectedValue)
    {
      Assert.Multiple(() =>
      {
        Assert.That(testParameters.Names, Has.Member(paramName));
        Assert.That(testParameters[paramName], Is.EqualTo(expectedValue));
      });
    }

    var testContextParameters = TestContext.Parameters;

    if (!UnitTestDetector.IsRunningFromReSharper)
    {
      Assert.That(testContextParameters.Count, Is.Zero);
      return;
    }

    Assert.Multiple(() =>
    {
      Assert.That(testContextParameters, Is.Not.Null);
      Assert.That(testContextParameters, Is.Not.Empty);
      Assert.That(testContextParameters.Count, Is.EqualTo(3));
    });

    AssertParameter(testContextParameters, "webAppUrl", "http://localhost");
    AssertParameter(testContextParameters, "webAppUserName", "Admin");
    AssertParameter(testContextParameters, "webAppPassword", "Password");
  }
}
