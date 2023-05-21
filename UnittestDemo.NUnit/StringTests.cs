using System.Globalization;

namespace UnittestDemo.NUnit;

public class StringTests
{
  [TestCase(null, null)]
  [TestCase("", "")]
  [TestCase("Homer", "Homer")]
  [TestCase("Homer", "homer", true)]
  public void EqualToExample(string target, string expectedValue, bool ignoreCase = false)
  {
    Assert.That(target, Is.EqualTo(expectedValue).IgnoreCase);
    if (ignoreCase)
    {
      return;
    }

    Assert.That(target, Is.EqualTo(expectedValue));
  }

  [TestCase(null, null, null)]
  [TestCase("", "", "")]
  [TestCase("iptal", "IPTAL", "İPTAL")]
  public void EqualToIgnoreCaseExample(string? target, string? expectedValue, string expectedTurkishValue)
  {
    static bool BeEquivalentTo(string? value, string? valueToCompare, CultureInfo cultureInfo) => string.Compare(value, valueToCompare, cultureInfo, CompareOptions.IgnoreCase) == 0;

    Assert.That(target, Is.EqualTo(expectedValue).IgnoreCase);

    Assert.That(BeEquivalentTo(target, expectedTurkishValue, new CultureInfo("tr-TR")), Is.True);
  }

  [Test]
  [SetCulture("tr-TR")]
  public void ToUpperLowerEqualToExample()
  {
    const string IptalLowerCase = "iptal";
    const string IptalUpperCase = "İPTAL";
    Assert.That(IptalLowerCase.ToUpper(), Is.EqualTo(IptalUpperCase));
    Assert.That(IptalLowerCase, Is.EqualTo(IptalUpperCase.ToLower()));
  }

  [TestCase("\r\n")]
  [TestCase("\n")]
  public void ShouldBeIgnoreLineEndingsExample(string ending)
  {
    var target = $"Homer{ending}";
    Assert.That(target.ReplaceLineEndings(string.Empty), Is.EqualTo("Homer"));
  }

  [TestCase(null)]
  [TestCase("")]
  [TestCase("bart")]
  [TestCase("Homer")]
  public void NotEqualToExample(string validValue)
  {
    const string Target = "Bart";

    Assert.That(Target, Is.Not.EqualTo(validValue));
  }

  [TestCase("Homer Simpson", "Homer.*")]
  [TestCase("Homer Simpson", "[hH]omer.*")]
  public void DoesMatchExample(string target, string pattern) => Assert.That(target, Does.Match(pattern));

  [TestCase("Homer Simpson", "homer.*")]
  [TestCase("Homer Simpson", ".*simpson")]
  public void DoesMatchIgnoreCaseExample(string target, string pattern) => Assert.That(target, Does.Match(pattern).IgnoreCase);

  [TestCase("Homer Simpson", "Homer")]
  [TestCase("Homer Simpson", "Simpson")]
  public void ShouldContainExample(string target, string toBeContained) => Assert.That(target, Does.Contain(toBeContained));

  [TestCase(" Hello, World ", "Hello,World")]
  [TestCase("Hello, World", "Hello,World")]
  [TestCase("Hello,\tWorld", "Hello,World")]
  [TestCase(" Hello,\nWorld ", "Hello,World")]
  public void ShouldContainWithoutWhitespaceExample(string value, string expectedValue)
  {
    static string TrimAllWhitespace(string target) => string.Concat(target.Where(c => !char.IsWhiteSpace(c)));

    var targetTrimmed = TrimAllWhitespace(value);
    Assert.That(targetTrimmed, Is.EqualTo(expectedValue));
  }

  [TestCase(null)]
  // [TestCase("")]
  // [TestCase("Homer")]
  public void IsNullExample(string? target) => Assert.That(target, Is.Null);

  // [TestCase(null)]
  [TestCase("")]
  // [TestCase("Homer")]
  public void IsEmptyExample(string? target) => Assert.That(target, Is.Null.Or.Empty);

  [TestCase(null)]
  [TestCase("")]
  // [TestCase("Homer")]
  public void IsNullOrEmptyExample(string? target) => Assert.That(target, Is.Null.Or.Empty);

  [TestCase("Homer", "Home")]
  // [TestCase("Homer", "home")]
  public void DoesStartWithExample(string target, string expectedValue) => Assert.That(target, Does.StartWith(expectedValue));

  [TestCase("Homer", "Home")]
  [TestCase("Homer", "home")]
  public void DoesStartWithIgnoreCaseExample(string target, string expectedValue) => Assert.That(target, Does.StartWith(expectedValue).IgnoreCase);

  [TestCase("Simpson")]
  // [TestCase("simpson")]
  // [TestCase("Homer")]
  public void DoesEndWithExample(string expectedValue)
  {
    const string Target = "Homer Simpson";
    Assert.That(Target, Does.EndWith(expectedValue));
  }

  [TestCase("Simpson")]
  [TestCase("simpson")]
  // [TestCase("Homer")]
  public void DoesEndWithIgnoreCaseExample(string expectedValue)
  {
    var target = "Homer Simpson";
    Assert.That(target, Does.EndWith(expectedValue).IgnoreCase);
  }
}
