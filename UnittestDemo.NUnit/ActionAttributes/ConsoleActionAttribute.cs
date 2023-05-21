using NUnit.Framework.Interfaces;

namespace UnittestDemo.NUnit.ActionAttributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Assembly, AllowMultiple = true)]
public class ConsoleActionAttribute : Attribute, ITestAction
{
  private readonly string _message;

  public ConsoleActionAttribute(string message)
  {
    _message = message;
  }

  public ActionTargets Targets => ActionTargets.Test;

  public void BeforeTest(ITest test) => WriteToConsole("Before", test);

  public void AfterTest(ITest test) => WriteToConsole("After", test);

  private void WriteToConsole(string eventMessage, ITest details)
  {
    var fixtureName = details.Fixture != null ? details.Fixture.GetType().Name : "{no fixture}";
    var methodName = details.Method != null ? details.Method.Name : "{no method}";
    TestContext.WriteLine(
      "{0} {1}: {2}, from {3}.{4}. TestCaseCount: {5}",
      eventMessage,
      details.IsSuite ? "Suite" : "Case",
      _message,
      fixtureName,
      methodName,
      details.TestCaseCount);
  }
}
