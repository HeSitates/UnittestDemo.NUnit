namespace UnittestDemo.NUnit.ConstraintTests;

internal class SamePathTests
{
  [Test]
  public void FromExamples()
  {
    const string Folder1Folder2 = "/folder1/./junk/../folder2";
    Assert.That(Folder1Folder2, Does.Not.Exist);

    Assert.That(Folder1Folder2, Is.SamePath("/folder1/folder2"));
    Assert.That("/folder1/./junk/../folder2/x", Is.Not.SamePath("/folder1/folder2"));

    Assert.That(@"C:\folder1\folder2", Is.SamePath(@"C:\Folder1\Folder2").IgnoreCase);
    Assert.That("/folder1/folder2", Is.Not.SamePath("/Folder1/Folder2").RespectCase);
  }
}
