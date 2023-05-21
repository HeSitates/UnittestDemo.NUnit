﻿using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace UnittestDemo.NUnit.ConstraintTests;

internal class TrueTests
{
  [TestCase("1 == 1")]
  [TestCase("2/4 != 0.25")]
  [TestCase("2%4 == 2")]
  public async Task FromExamples(string expression)
  {
    var result = await CSharpScript.EvaluateAsync(expression);
    Assert.That(result, Is.True);
  }
}
