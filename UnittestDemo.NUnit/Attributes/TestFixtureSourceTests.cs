namespace UnittestDemo.NUnit.Attributes;

[TestFixture]
public class TestFixtureSourceTests
{
  [Test]
  public void ToSuppressWarning() => Assert.That("Anything to suppress that this class has no tests", Is.Not.Null);

  [TestFixtureSource(nameof(FixtureArgs))]
  public class TestFixtureSourceTests1
  {
    private static readonly object[] FixtureArgs =
    {
      new object[] { "Question", 1 },
      new object[] { "Answer", 42 },
    };

    private readonly string _word;
    private readonly int _num;

    public TestFixtureSourceTests1(string word, int num)
    {
      _word = word;
      _num = num;
    }

    [Test]
    public void FromExamples() => Assert.Multiple(() =>
    {
      Assert.That(_word, Is.EqualTo("Question").Or.EqualTo("Answer"));
      Assert.That(_num, Is.EqualTo(1).Or.EqualTo(42));
    });
  }

  [TestFixtureSource(typeof(AnotherClass), nameof(AnotherClass.FixtureArgs))]
  public class TestFixtureSourceTests2
  {
    private readonly string _word;
    private readonly int _num;

    public TestFixtureSourceTests2(string word, int num)
    {
      _word = word;
      _num = num;
    }

    [Test]
    public void FromExamples() => Assert.Multiple(() =>
    {
      Assert.That(_word, Is.EqualTo("Question").Or.EqualTo("Answer"));
      Assert.That(_num, Is.EqualTo(1).Or.EqualTo(42));
    });

    private static class AnotherClass
    {
      public static object[] FixtureArgs => new object[] { new object[] { "Question", 1 }, new object[] { "Answer", 42 } };
    }
  }

  [TestFixtureSource(typeof(FixtureArgs))]
  public class TestFixtureSourceTests3
  {
    private readonly string _word;
    private readonly int _num;

    public TestFixtureSourceTests3(string word, int num)
    {
      _word = word;
      _num = num;
    }

    [Test]
    public void FromExamples() => Assert.Multiple(() =>
    {
      Assert.That(_word, Is.EqualTo("Question").Or.EqualTo("Answer"));
      Assert.That(_num, Is.EqualTo(1).Or.EqualTo(42));
    });

    private class FixtureArgs : IEnumerable
    {
      public IEnumerator GetEnumerator()
      {
        yield return new object[] { "Question", 1 };
        yield return new object[] { "Answer", 42 };
      }
    }
  }
}
