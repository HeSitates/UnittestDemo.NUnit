namespace UnittestDemo.NUnit.ConstraintTests;

internal class SubPathTests
{
  [Test]
  public void FromExamples()
  {
    Assert.That("/folder1/./junk/../folder2", Is.SubPathOf("/folder1/"));
    Assert.That("/folder1/./junk/../folder2", Is.SubPathOf("/Folder1/").IgnoreCase);
    Assert.That("/folder1/junk/folder2", Is.Not.SubPathOf("/folder1/folder2"));

    Assert.That(@"C:\folder1\folder2\Folder3", Is.SubPathOf(@"C:\Folder1\Folder2").IgnoreCase);
    Assert.That("/folder1/folder2/folder3", Is.Not.SubPathOf("/Folder1/Folder2/Folder3").RespectCase);
  }
}
