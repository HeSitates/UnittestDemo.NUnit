namespace UnittestDemo.NUnit.ConstraintTests;

internal class EqualTests
{
  [Test]
  public void FromExamplesComparingNumerics()
  {
    Assert.That(5.0, Is.EqualTo(5));
    Assert.That(5, Is.EqualTo(5.0));
    Assert.That(5.5, Is.EqualTo(5).Within(0.51));
    Assert.That(5.51, Is.EqualTo(5.5).Within(1.5).Percent);

    Assert.That(2 + 2, Is.EqualTo(4.0));
    Assert.That(2 + 2, Is.EqualTo(4));
    Assert.That(2 + 2, Is.Not.EqualTo(5));
  }

  [Test]
  public void FromExamplesComparingFloatingPointValues()
  {
    Assert.That(2.1 + 1.2, Is.EqualTo(3.3).Within(.0005));
    var actual = double.PositiveInfinity;
    Assert.That(actual, Is.EqualTo(double.PositiveInfinity));

    actual = double.NegativeInfinity;
    Assert.That(actual, Is.EqualTo(double.NegativeInfinity));

    actual = double.NaN;
    Assert.That(actual, Is.EqualTo(double.NaN));

    // Ulp stands for "unit in the last place" and describes the minimum amount a given value can change. For any integers, an ulp is 1 whole digit.
    // For floating point values, the accuracy of which is better for smaller numbers and worse for larger numbers, an ulp depends on the size of the number.
    // Using ulps for comparison of floating point results instead of fixed tolerances is safer because it will automatically compensate for the added inaccuracy of larger numbers.
    Assert.That(4.01, Is.EqualTo(4.0099999999999998).Within(1).Ulps);
    Assert.That(20000000000000004.0, Is.EqualTo(20000000000000000.0).Within(1).Ulps);
  }

  [Test]
  public void FromExamplesComparingStrings()
  {
    Assert.That("Hello!", Is.Not.EqualTo("HELLO!"));
    Assert.That("Hello!", Is.EqualTo("HELLO!").IgnoreCase);

    var expected = new string[] { "Hello", "World" };
    var actual = new string[] { "HELLO", "world" };
    Assert.That(actual, Is.Not.EqualTo(expected));
    Assert.That(actual, Is.EqualTo(expected).IgnoreCase);
  }

  [Test]
  [Explicit("Test fails. Only to demonstrate NoClip")]
  public void FromExamplesComparingStringsFailingWithNoClip() => Assert.Multiple(() =>
  {
    Assert.That("Hello, this is a long string to demonstrate NoClip!", Is.EqualTo("Hello, this is a long string to demonstrate NoClip, this is a longer string!!"));
    Assert.That("Hello, this is a long string to demonstrate NoClip!", Is.EqualTo("Hello, this is a long string to demonstrate NoClip, this is a longer string!!").NoClip);
  });

  [Test]
  public void FromExamplesComparingDateTimesAndTimeSpans()
  {
    var now = DateTime.Now;
    var later = now + TimeSpan.FromHours(1.0);

    Assert.That(later, Is.EqualTo(now).Within(TimeSpan.FromHours(3.0)));
    Assert.That(later, Is.EqualTo(now).Within(3).Hours);
  }

  [Test]
  public void FromExamplesComparingArraysCollectionsAndIEnumerables()
  {
    var i3 = new int[] { 1, 2, 3 };
    var d3 = new double[] { 1, 2.0, 3.0 };
    Assert.That(i3, Is.EqualTo(d3));

    d3[0] = 1.00000000001;
    Assert.That(i3, Is.EqualTo(d3).Within(0.1));

    var iunequal = new int[] { 1, 3, 2 };
    Assert.That(i3, Is.Not.EqualTo(iunequal));

    var array2X2 = new int[,] { { 1, 2 }, { 3, 4 } };
    var array4 = new int[] { 1, 2, 3, 4 };
    Assert.That(array2X2, Is.Not.EqualTo(array4));
    Assert.That(array2X2, Is.EqualTo(array4).AsCollection);
  }
}
