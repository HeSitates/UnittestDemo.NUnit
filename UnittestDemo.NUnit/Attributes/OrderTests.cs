using System.Runtime.CompilerServices;

namespace UnittestDemo.NUnit.Attributes;

#pragma warning disable S2187
#pragma warning disable S2699 // Add at least one assertion to this test case.

/// <remarks>
/// Using <see cref="ParallelizableAttribute"/> has a huge impact on the order attribute
/// ParallelScope.All: only the order of the starts of the tests is secured.
/// </remarks>
[TestFixture]
public static class OrderTests
{
  private static void WriteAndDelay(string className, int delay, ref int counter, [CallerMemberName] string testName = "")
  {
    TestContext.Progress.WriteLine("Progress {0}.{1} started, counter: {2}", className, testName, counter++);

    if (delay > 0)
    {
      Thread.Sleep(delay);
    }

    TestContext.Progress.WriteLine("Progress {0}.{1} finished, counter: {2}", className, testName, counter++);
  }

  [Parallelizable(ParallelScope.None)]
  public class OrderWithParallelScopeNoneTests
  {
    private const string ClassName = nameof(OrderWithParallelScopeNoneTests);
    private int _counter;

    [Test]
    [Order(1)]
    public void TestA() => WriteAndDelay(ClassName, 5000, ref _counter);

    [Test]
    [Order(2)]
    public void TestB() => WriteAndDelay(ClassName, 1000, ref _counter);

    [Test]
    public void TestC() => WriteAndDelay(ClassName, 1000, ref _counter);

    [Test]
    public void TestD() => WriteAndDelay(ClassName, 0, ref _counter);
  }

  [Parallelizable(ParallelScope.All)]
  public class OrderWithParallelScopeAllTests
  {
    private const string ClassName = nameof(OrderWithParallelScopeAllTests);
    private int _counter;

    [Test]
    [Order(1)]
    public void TestA() => WriteAndDelay(ClassName, 5000, ref _counter);

    [Test]
    [Order(2)]
    public void TestB() => WriteAndDelay(ClassName, 1000, ref _counter);

    [Test]
    public void TestC() => WriteAndDelay(ClassName, 1000, ref _counter);

    [Test]
    public void TestD() => WriteAndDelay(ClassName, 0, ref _counter);
  }

  [Parallelizable(ParallelScope.Children)]
  public class OrderWithParallelScopeChildrenTests
  {
    private const string ClassName = nameof(OrderWithParallelScopeChildrenTests);
    private int _counter;

    [Test]
    [Order(1)]
    public void TestA() => WriteAndDelay(ClassName, 5000, ref _counter);

    [Test]
    [Order(2)]
    public void TestB() => WriteAndDelay(ClassName, 1000, ref _counter);

    [Test]
    public void TestC() => WriteAndDelay(ClassName, 1000, ref _counter);

    [Test]
    public void TestD() => WriteAndDelay(ClassName, 0, ref _counter);
  }

  [Parallelizable(ParallelScope.ContextMask)]
  public class OrderWithParallelScopeContextMaskTests
  {
    private const string ClassName = nameof(OrderWithParallelScopeContextMaskTests);
    private int _counter;

    [Test]
    [Order(1)]
    public void TestA() => WriteAndDelay(ClassName, 5000, ref _counter);

    [Test]
    [Order(2)]
    public void TestB() => WriteAndDelay(ClassName, 1000, ref _counter);

    [Test]
    public void TestC() => WriteAndDelay(ClassName, 1000, ref _counter);

    [Test]
    public void TestD() => WriteAndDelay(ClassName, 0, ref _counter);
  }
}
