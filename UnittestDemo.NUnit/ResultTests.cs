namespace UnittestDemo.NUnit;

[SuppressMessage("Assertion", "NUnit2010:Use EqualConstraint for better assertion messages in case of failure", Justification = "Just to demonstrate.")]
public class ResultTests
{
  [TestCase(null, "Unknown error")]
  [TestCase("", "Unknown error")]
  [TestCase("Hatsikidee")]
  public void SetErrormessageShouldReturnSuccessIsFalse(string errorMessage, string expectedErrorMessage = "")
  {
    if (string.IsNullOrWhiteSpace(expectedErrorMessage))
    {
      expectedErrorMessage = errorMessage;
    }

    // Arrange
    var sut = Result<string>.SetErrorMessage(errorMessage);

    // Act
    // Assert
    Assert.That(sut, Is.Not.Null);
    Assert.That(sut.GetType().GetGenericTypeDefinition() == typeof(Result<>), Is.True);
    Assert.That(sut.GetType().GetGenericTypeDefinition(), Is.EqualTo(typeof(Result<>)));
    Assert.That(sut.Success, Is.False);
    Assert.That(sut.ErrorMessage, Is.EqualTo(expectedErrorMessage));
  }

  [TestCase(null, "Something went wrong.", "Something went wrong.")]
  [TestCase("", "Something went wrong.", "Something went wrong.")]
  [TestCase("Ok", "Something went wrong.", "Ok: Something went wrong.")]
  public void SetErrormessageShouldReturnSuccessIsFalse(string errorMessage, string exceptionMessage, string expectedErrorMessage)
  {
    // Arrange
    var ex = new InvalidOperationException(exceptionMessage);
    var sut = Result<string>.SetErrorMessage(errorMessage, ex);

    // Act
    // Assert
    Assert.That(sut, Is.Not.Null);
    Assert.That(sut.GetType().GetGenericTypeDefinition() == typeof(Result<>), Is.True);
    Assert.That(sut.Success, Is.False);
    Assert.That(sut.ErrorMessage, Is.EqualTo(expectedErrorMessage));
  }

  [TestCaseSource(nameof(TestResults))]
  public void SetSuccessShouldReturnSuccessIsTrue<T>(T value, Type expectedType)
  {
    //// Arrange
    var sut = Result<T>.SetSuccess(value);

    // Act
    // Assert
    Assert.That(sut, Is.Not.Null);
    Assert.That(sut.GetType().GetGenericTypeDefinition() == typeof(Result<>), Is.True);
    Assert.That(sut, Is.TypeOf(typeof(Result<T>)));
    Assert.That(sut.Success, Is.True);
    Assert.That(sut.ErrorMessage, Is.Empty);
    Assert.That(sut.Value, Is.Not.Null);
    Assert.That(sut.Value, Is.TypeOf(typeof(T)));
    Assert.That(sut.Value, Is.TypeOf(expectedType));
  }

  private static IEnumerable TestResults()
  {
    yield return new TestCaseData("2BH-EH", typeof(string)).SetName("string");
    yield return new TestCaseData(2, typeof(int)).SetName("int");
    yield return new TestCaseData(new Cat { Name = "Kitty" }, typeof(Cat)).SetName("Cat");
  }
}
