using System.Globalization;

namespace UnittestDemo.NUnit.Attributes;

/// <remarks>These test are only to see the effect of the <see cref="SetCultureAttribute"/>.</remarks>
internal class SetCultureTests
{
  [TestCaseSource(nameof(SetOfDates))]
  [SetCulture("nl-NL")]
  public void DutchDatesExample(DateTime target)
  {
    var ds = $"{target}";
    TestContext.WriteLine(ds);

    const string Format = "dd-MM-yyyy HH:mm:ss";
    var parseResult = DateTime.TryParseExact(ds, Format, CultureInfo.CurrentCulture, DateTimeStyles.None, out var output);
    Assert.That(parseResult, Is.True);
    Assert.That(target, Is.EqualTo(output));
  }

  [TestCaseSource(nameof(SetOfDates))]
  [SetCulture("tr-TR")]
  public void TurkishDatesExample(DateTime target)
  {
    var ds = $"{target}";
    TestContext.WriteLine(ds);

    const string Format = "d.MM.yyyy HH:mm:ss";
    var parseResult = DateTime.TryParseExact(ds, Format, CultureInfo.CurrentCulture, DateTimeStyles.None, out var output);
    Assert.That(parseResult, Is.True);
    Assert.That(target, Is.EqualTo(output));
  }

  [TestCaseSource(nameof(SetOfDates))]
  [SetCulture("en-US")]
  public void AmericanDatesExample(DateTime target)
  {
    var ds = $"{target}";
    TestContext.WriteLine(ds);

    const string Format = "M/d/yyyy h:mm:ss tt";
    var parseResult = DateTime.TryParseExact(ds, Format, CultureInfo.CurrentCulture, DateTimeStyles.None, out var output);
    Assert.That(parseResult, Is.True);
    Assert.That(target, Is.EqualTo(output));
  }

  private static IEnumerable SetOfDates()
  {
    yield return new TestCaseData(new DateTime(2023, 4, 1, 1, 2, 3));
    yield return new TestCaseData(new DateTime(2023, 4, 9, 21, 10, 22));
    yield return new TestCaseData(new DateTime(2023, 12, 9, 11, 11, 11));
    yield return new TestCaseData(new DateTime(2023, 12, 19, 22, 22, 22));
  }
}
