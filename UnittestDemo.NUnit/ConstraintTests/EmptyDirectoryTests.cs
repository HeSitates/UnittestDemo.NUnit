namespace UnittestDemo.NUnit.ConstraintTests;

internal class EmptyDirectoryTests
{
  [Test]
  public void FromExamples()
  {
    // Get a folder that surely exists and is not empty.
    var actual = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    Assert.That(new DirectoryInfo(actual), Is.Not.Empty);
  }
}
