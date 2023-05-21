namespace UnittestDemo.NUnit.ConstraintTests;

internal class CollectionOrderedTests
{
  [Test]
  public void FromSimpleOrderingExamples()
  {
    var iarray = new int[] { 1, 2, 3 };
    Assert.That(iarray, Is.Ordered);

    var sarray = new string[] { "c", "b", "a" };
    Assert.That(sarray, Is.Ordered.Descending);
  }

  [Test]
  public void FromPropertyBasedOrderingExamples()
  {
    var sarray = new string[] { "a", "aa", "aaa" };
    Assert.That(sarray, Is.Ordered.By(nameof(sarray.Length)));

    var sarray2 = new string[] { "aaa", "aa", "a" };
    Assert.That(sarray2, Is.Ordered.Descending.By(nameof(sarray2.Length)));
  }

  [Test]
  public void PropertyBasedOrderingWithObjects()
  {
    var exampleClasses = new ExampleClass[] { new ExampleClass(1, "A"), new ExampleClass(3, "A"), new ExampleClass(2, "B"), new ExampleClass(1, "C") };
    Assert.That(exampleClasses, Is.Ordered.Using(new ExampleClassComparer()));

    var exampleClasses1 = exampleClasses.OrderBy(ec => ec.Id).ToArray();
    Assert.That(exampleClasses1, Is.Ordered.By(nameof(ExampleClass.Id)));
    Assert.That(exampleClasses1, Is.Ordered.By(nameof(ExampleClass.Id)).Ascending);
    Assert.That(exampleClasses1, Is.Ordered.Ascending.By(nameof(ExampleClass.Id)));

    var exampleClasses2 = exampleClasses.OrderByDescending(ec => ec.Id).ToArray();
    Assert.That(exampleClasses2, Is.Ordered.By(nameof(ExampleClass.Id)).Descending);
    Assert.That(exampleClasses2, Is.Ordered.Descending.By(nameof(ExampleClass.Id)));

    var exampleClasses3 = exampleClasses.OrderBy(ec => ec.Name).ThenByDescending(ec => ec.Id).ToArray();
    Assert.That(exampleClasses3, Is.Ordered.By(nameof(ExampleClass.Name)));
    Assert.That(exampleClasses3, Is.Ordered.By(nameof(ExampleClass.Name)).By(nameof(ExampleClass.Id)).Descending);
    Assert.That(exampleClasses3, Is.Ordered.By(nameof(ExampleClass.Name)).Then.Descending.By(nameof(ExampleClass.Id)));
  }

  private class ExampleClass
  {
    public ExampleClass(int id, string name)
    {
      Id = id;
      Name = name;
    }

    public int Id { get; }

    public string Name { get; }

    public int Demo => FirstChar * FirstChar;

    private int FirstChar => Name.FirstOrDefault();
  }

  private class ExampleClassComparer : IComparer<ExampleClass>
  {
    public int Compare(ExampleClass? a, ExampleClass? b)
    {
      if (a != null && b != null)
      {
        return a.Demo.CompareTo(b.Demo);
      }

      return a switch
      {
        null when b == null => 0,
        null => -1,
        _ => 1,
      };
    }
  }
}
