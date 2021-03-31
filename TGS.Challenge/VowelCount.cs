using System;
using System.Collections.Generic;
using System.Linq;

namespace TGS.Challenge
{
  /*
      Devise a function that takes a string & returns the number of 
      vowels (aeiou) in that string.

      "Hi there!" = 3
      "What do you mean?"  = 6

      There are accompanying unit tests for this exercise, ensure all tests pass & make
      sure the unit tests are correct too.
   */
  public class VowelCount
  {
    public int Count(string value)
    {
      if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException($"Supply the first word {value}");
      var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
      return value.Count(c => vowels.Contains(c));
    }
  }
}
