namespace UnittestDemo.NUnit.ConstraintTests;

internal class FileOrDirectoryExistsTests
{
  [Test]
  public void FromExamples()
  {
    var dirStr = Path.GetTempPath();

    Assert.That(dirStr, Does.Exist);

    Assert.That(new DirectoryInfo(dirStr), Does.Exist);

    var fileStr = Path.GetTempFileName();

    Assert.That(fileStr, Does.Exist);

    Assert.That(new FileInfo(fileStr), Does.Exist);

    File.Delete(fileStr);
    Assert.That(fileStr, Does.Not.Exist);
  }
}
