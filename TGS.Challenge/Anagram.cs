using System;

namespace TGS.Challenge
{
  /*
        Devise a function that checks if 1 word is an anagram of another, if the words are anagrams of
        one another return true, else return false

        "Anagram": An anagram is a type of word play, the result of rearranging the letters of a word or
        phrase to produce a new word or phrase, using all the original letters exactly once; for example
        orchestra can be rearranged into carthorse.

        areAnagrams("horse", "shore") should return true
        areAnagrams("horse", "short") should return false

        NOTE: Punctuation, including spaces should be ignored, e.g.

        horse!! shore = true
        horse  !! shore = true
          horse? heroes = true

        There are accompanying unit tests for this exercise, ensure all tests pass & make
        sure the unit tests are correct too.
     */
  public class Anagram
  {
    public bool AreAnagrams(string word1, string word2)
    {
      if (string.IsNullOrWhiteSpace(word1)) throw new ArgumentException($"Supply the first word {word1}");
      if (string.IsNullOrWhiteSpace(word2)) throw new ArgumentException($"Supply the second word {word2}");
      word1 = word1.RemoveCharacters();
      word2 = word2.RemoveCharacters();
      var wordOneCharArr = word1.ToArray();
      var wordTwoCharArr = word2.ToArray();
      Array.Sort(wordOneCharArr);
      Array.Sort(wordTwoCharArr);
      return new string(wordOneCharArr) == new string(wordTwoCharArr);
    }
    
  }
  public static class CharacterRemover
  {
    public static string RemoveCharacters(this string s)
    { 
      char[] unwantedCharacters = new char[] { ' ', '!', '?', '-', '_', '(', ')', '"', ':', ';', '\'' };
      return s == null ? null : string.Join(string.Empty, s.Split(unwantedCharacters));
    }
    public static Char[] ToArray(this string s) => s.ToLower().ToCharArray();
  }
}
