namespace UnittestDemo.NUnit;

public class EnvironmentTests
{
  private List<DictionaryEntry> _environmentVariables;

  [OneTimeSetUp]
  public void OneTimeSetUp() =>
    _environmentVariables = Environment.GetEnvironmentVariables()
      .Cast<DictionaryEntry>()
      .OrderBy(ev => ev.Key)
      .ToList();

  [Test]
  public void Example()
  {
    Assert.Multiple(() =>
    {
      Assert.That(_environmentVariables, Is.Not.Null);
      Assert.That(_environmentVariables, Is.Not.Empty);
    });

    // Running test with nunit3-console does not read the .runsettings file, so exclude thoses tests.
    if (!UnitTestDetector.IsRunningFromMicrosoftTest && !UnitTestDetector.IsRunningFromReSharper)
    {
      AssertAndNullValue(_environmentVariables, "ANewVar");
      return;
    }

    // Environment variable from demo.runsettings
    //// This fails when run from commandline! AssertAndTestValue(environmentVariables, "DOTNET_ROOT", "C:\\ProgramFiles\\dotnet");
    AssertAndTestValue(_environmentVariables, "ANewVar", "dotnet");
    AssertAndTestValue(_environmentVariables, "HOMEDRIVE", "D:");

    if (UnitTestDetector.IsRunningFromReSharper)
    {
      AssertAndTestValue(_environmentVariables, "RESHARPER_TESTRUNNER", "Run", "Debug");
    }
    else
    {
      AssertAndNullValue(_environmentVariables, "RESHARPER_TESTRUNNER");
    }

    if (Environment.UserInteractive)
    {
      foreach (var ev in _environmentVariables)
      {
        Console.WriteLine("{0}: {1}", ev.Key, ev.Value);
      }
    }
  }

  [Test]
  [Platform(Exclude = "Linux,Unix,MacOsX")]
  public void ExampleWithWindowsSystemVariables()
  {
    Assert.Multiple(() =>
    {
      Assert.That(_environmentVariables, Is.Not.Null);
      Assert.That(_environmentVariables, Is.Not.Empty);
    });

    // Real environment variables - could fail if systemdrive is not c:
    AssertAndTestValue(_environmentVariables, "SystemDrive", "C:");
    AssertAndTestValue(_environmentVariables, "SystemRoot", "C:\\Windows");
    AssertAndTestValue(_environmentVariables, "ALLUSERSPROFILE", "C:\\ProgramData");
  }

  private static void AssertAndTestValue(List<DictionaryEntry> variables, string key, string expectedValueA, string? expectedValueB = null)
  {
    var keyValue = variables.Find(ev => string.Equals(ev.Key.ToString(), key, StringComparison.CurrentCultureIgnoreCase));
    Assert.Multiple(() =>
    {
      Assert.That(keyValue.Value, Is.Not.Null);
      if (!string.IsNullOrEmpty(expectedValueB))
      {
        Assert.That(keyValue.Value, Is.EqualTo(expectedValueA).IgnoreCase.Or.EqualTo(expectedValueB).IgnoreCase);
      }
      else
      {
        Assert.That(keyValue.Value, Is.EqualTo(expectedValueA).IgnoreCase);
      }
    });
  }

  private static void AssertAndNullValue(List<DictionaryEntry> variables, string key)
  {
    var keyValue = variables.Find(ev => string.Equals(ev.Key.ToString(), key, StringComparison.CurrentCultureIgnoreCase));
    Assert.That(keyValue.Value, Is.Null);
  }
}
