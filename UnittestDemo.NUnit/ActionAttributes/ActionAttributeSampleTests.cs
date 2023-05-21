namespace UnittestDemo.NUnit.ActionAttributes;

[TestFixture]
public class ActionAttributeSampleTests
{
  [ConsoleAction("Hello")]
  [TestCase("02", TestName = "With parameter 02")]
  [TestCase("01")]
  public void SimpleTest(string number)
  {
    Console.WriteLine("Test run {0}.", number);
    Assert.That(number, Is.Not.Empty);
  }
}
