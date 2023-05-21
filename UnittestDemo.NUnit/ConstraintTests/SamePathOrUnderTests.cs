namespace UnittestDemo.NUnit.ConstraintTests;

internal class SamePathOrUnderTests
{
  [Test]
  public void FromExamples()
  {
    const string Folder1Folder2 = "/folder1/./junk/../folder2";
    Assert.That(Folder1Folder2, Does.Not.Exist);

    Assert.That(Folder1Folder2, Is.SamePathOrUnder("/folder1/folder2"));

    Assert.That("/folder1/junk/../folder2/./folder3", Is.SamePathOrUnder("/folder1/folder2"));
    Assert.That("/folder1/junk/folder2/folder3", Is.Not.SamePathOrUnder("/folder1/folder2"));

    Assert.That(@"C:\folder1\folder2\folder3", Is.SamePathOrUnder(@"C:\Folder1\Folder2").IgnoreCase);
    Assert.That("/folder1/folder2/folder3", Is.Not.SamePathOrUnder("/Folder1/Folder2").RespectCase);
  }
}
