using NUnit.Framework.Constraints;
using NUnit.Framework.Internal;

namespace UnittestDemo.NUnit.ConstraintTests;

internal class DictionaryContainsKeyValuePairConstraintTests
{
  [Test]
  public void FromExamples()
  {
    var dictionary = new Dictionary<string, string>
    {
      { "Hi", "Universe" },
      { "Hola", "Mundo" },
    };

    Assert.That(dictionary, Does.ContainKey("Hi").WithValue("Universe"));
    Assert.That(dictionary, new DictionaryContainsKeyValuePairConstraint("Hi", "Universe"));
    Assert.That(dictionary, new DictionaryContainsKeyValuePairConstraint("HI", "UNIVERSE").IgnoreCase);
    Assert.That(dictionary, new DictionaryContainsKeyValuePairConstraint("HI", "UNIVERSE").Using<string>((x, y) => StringUtil.Compare(x, y, true)));
  }
}
