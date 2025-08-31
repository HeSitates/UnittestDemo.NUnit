using System.Collections.ObjectModel;

#pragma warning disable SA1402

[SetUpFixture]
[SuppressMessage("Design", "CA1050:Declare types in namespaces", Justification = "To show different levels of SetUp methods.")]
[SuppressMessage("Design", "S3903: Move into a named namespace", Justification = "To show different levels of SetUp methods.")]
[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "To show different levels of SetUp methods.")]
public class MySetUpClassOutsideOfNamespace : UnittestDemo.NUnit.FlowCounterBase
{
  [OneTimeSetUp]
  public void RunBeforeAnyTests() => TestContext.Out.WriteLine($"{Counter}: OneTimeSetUp {TestContext.CurrentContext.Test.FullName}");

  [OneTimeTearDown]
  public void RunAfterAnyTests() => TestContext.Out.WriteLine($"{Counter}: OneTimeTearDown {TestContext.CurrentContext.Test.FullName}");
}

#pragma warning disable SA1201
namespace UnittestDemo.NUnit
{
  public abstract class FlowCounterBase
  {
    private static int _counter;

    protected static int Counter => _counter++;
  }

  [SetUpFixture]
  public class MySetUpClass : FlowCounterBase
  {
    [OneTimeSetUp]
    public void RunBeforeAnyTests() => TestContext.Out.WriteLine($"{Counter}: OneTimeSetUp {TestContext.CurrentContext.Test.FullName}");

    [OneTimeTearDown]
    public void RunAfterAnyTests() => TestContext.Out.WriteLine($"{Counter}: OneTimeTearDown {TestContext.CurrentContext.Test.FullName}");
  }

  internal class TestFlowTests : FlowCounterBase
  {
    private int _setUpCounter = 1;
    private int _teardownCounter = 1;

    [OneTimeSetUp]
    public void OneTimeSetUp() => TestContext.Out.WriteLine($"{Counter}: OneTimeSetUp {TestContext.CurrentContext.Test.FullName}");

    [OneTimeTearDown]
    public void OneTimeTearDown() => TestContext.Out.WriteLine($"{Counter}: OneTimeTearDown {TestContext.CurrentContext.Test.FullName}");

    [SetUp]
    public void SetUp() => TestContext.Out.WriteLine($"{Counter}: SetUp {TestContext.CurrentContext.Test.Name} - Count: {_setUpCounter++}");

    [TearDown]
    public void TearDown() => TestContext.Out.WriteLine($"{Counter}: TearDown {TestContext.CurrentContext.Test.Name} - Count: {_teardownCounter++}");

    [Test]
    public void Test1()
    {
      TestContext.Out.WriteLine($"{Counter}: {TestContext.CurrentContext.Test.Name}");
      Assert.Pass("Ok\n");
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    public void Test2(int number)
    {
      TestContext.Out.WriteLine($"{Counter}: {TestContext.CurrentContext.Test.Name}");
      TestContext.Progress.WriteLine($"number: {number}");
      Assert.Pass("Ok\n");
    }

    [TestCaseSource(nameof(SetOfStrings))]
    public void Test3(ICollection<string> list)
    {
      TestContext.Out.WriteLine($"{Counter}: {TestContext.CurrentContext.Test.Name}");
      Assert.That(list, Is.Not.Empty);
    }

    private static IEnumerable SetOfStrings()
    {
      yield return new TestCaseData(arg: new string[] { "a", "b", "c" }).SetName("With string[]");
      yield return new TestCaseData(new List<string> { "a", "b", "c" }).SetName("With List<string>");
      yield return new TestCaseData(new Collection<string> { "a", "b", "c" }).SetName("With Collection<string>");
    }
  }
}
