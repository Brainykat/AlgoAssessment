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
      return value.ToLower().Count(c => vowels.Contains(c));
    }
    /*
      =======================================================================================================
        Qualified assesment Q1
        All tests passed
      =======================================================================================================
     */
    public static int ArrayPacking(List<int> integers)
    {
      //integers.Sort();
      string res = "";
      for (int i = integers.Count; i >= 0; i--)
      {
        string binary = Convert.ToString(integers[i], 2);
        binary = binary.PadLeft(8, '0');
        res = res + binary;
      }
      return Convert.ToInt32(res, 2);
    }
    /*
     * Background
Markdown is a formatting syntax used by many documents (these instructions, for example!) because of its plain-text simplicity and its ability to be translated directly into HTML.

Task
Let's write a simple markdown parser function that will take in a single line of markdown and be translated into the appropriate HTML. To keep it simple, we'll support only one feature of markdown in atx syntax: headers.

Headers are designated by (1-6) hashes followed by a space, followed by text. The number of hashes determines the header level of the HTML output.

Specifications
Challenge.MarkdownParser(markdown)
Transforms given string into correct header form

Parameters
markdown: string - String to be changed into markdown format

Return Value
string - Formatted string

Examples
markdown	Return Value
"# Header"	"<h1>Header</h1>"
"## Header"	"<h2>Header</h2>"
"###### Header"	"<h6>Header</h6>"
Additional Rules
Header content should only come after the initial hashtag(s) plus a space character.

Invalid headers should just be returned as the markdown that was recieved, no translation necessary.

Spaces before and after both the header content and the hashtag(s) should be ignored in the resulting output.
     */
    public static string MarkdownParser(string markdown)
    {
      if (string.IsNullOrWhiteSpace(markdown)) return markdown;
      markdown = markdown.Trim();
      Console.WriteLine(markdown);
      int firstSpaceLocation = markdown.IndexOf(" ", StringComparison.Ordinal);
      if (firstSpaceLocation < 0) return markdown;
      var subString = markdown.Substring(0, firstSpaceLocation);
      if (string.IsNullOrWhiteSpace(subString)) return markdown;
      int n = subString.Length;
      if(n<1) return markdown;
      for (int i = 1; i < n; i++)
      {
        if (subString[i] != '#') return markdown;
      }
      switch (subString.Length)
      {
        case 1: return $"<h1>{markdown.Substring(firstSpaceLocation).Trim()}</h1>";
        case 2: return $"<h2>{markdown.Substring(firstSpaceLocation).Trim()}</h2>";
        case 3: return $"<h3>{markdown.Substring(firstSpaceLocation).Trim()}</h3>";
        case 4: return $"<h4>{markdown.Substring(firstSpaceLocation).Trim()}</h4>";
        case 5: return $"<h5>{markdown.Substring(firstSpaceLocation).Trim()}</h5>";
        case 6: return $"<h6>{markdown.Substring(firstSpaceLocation).Trim()}</h6>";
        default:return markdown;
      }
    }
    /*
     Task
Write a function that takes a string input, and returns the first character that is not repeated anywhere in the string. Characters in strings consist of printable characters.

As an added challenge, upper- and lowercase letters are considered the same character, but the function should return the correct case for the initial letter. For example, the input 'sTreSS' should return 'T'.

If a string contains all repeating characters, it should return the empty string ("").

Documentation
Challenge.FirstNonRepeatingLetter(s)
Parameters
s: string - a string to be parsed

Returns
string - the first character that is not repeated anywhere in the string.

Examples
s	returns
string	string
Example #1	"stress"	"t"
Example #2	"STreSS"	"T"
Example #1 Explanation:
In the input 'stress', the function should return 't', since the letter t only occurs once in the string, and occurs first in the string.*/
    public static string FirstNonRepeatingLetter(string str)
    {
      if (string.IsNullOrWhiteSpace(str)) return "";
      int n = str.Length;
      for (int i = 0; i < n-1; i++)
      {
        var subStr = str.Remove(i, 1);// str.Substring(i);
        if (!subStr.ToLower().Contains(str.ToLower()[i]))
        {
          return str[i].ToString();
        }
      }
      return "";
    }
    /*
     * Morse Code
Overview
Morse Code is delivered in a series signals which are referred to as dashes (-) or dots (.). To keep things simple for the purposes of this challenge we'll only decode letters with a maximum length of three signals.

Morse Code Graph

Here is the Morse Code dichotomic search table courtesy of Wikipedia

Morse Code Examples
-.- translates to K
... translates to S
.- translates to A
-- translates to M
. translates to E

Background
You've started work as morse code translator. Unfortunately some of the signals aren't as distinguishable as others and there are times where a . seems indistinguishable from -. In these cases you write down a ? so that you can figure out what all the posibilities of that letter for that word are later.

Task
Write a function possibilities that will take a string signals and return an array of possible characters that the Morse code signals could represent.

Specification
Challenge.Possibilities(signals)
Parameters
signals: string - The Morse code signals that needs to be parsed. The may contain one or more unknown signals (?).

Return Value
List<string> - The list of possible letters for the given group of signals. Letters will always be ordered from how they appear on the chart, from left to right.

Constraints
There will be no more than 3 characters within signals.

0 - 3 unknown signals may be given.

Examples
signals	Return Value
"."	["E"]
"-"	["T"]
"-."	["N"]
"..."	["S"]
"..-"	["U"]
"?"	["E","T"]
".?"	["I","A"]
"?-?"	["R","W","G","O"]

     */
    public static string[] Possibilities(string signals)
    {
      var res = new string[] { };
      if (string.IsNullOrWhiteSpace(signals)) return new string[] { "E", "T" };
      switch (signals.Length)
      {
        case 1:
          {
            if (signals[0] == '?') return new string[] { "E", "T" };
            if (signals[0] == '.') return new string[] { "E" };
            if (signals[0] == '-') return new string[] { "E" };
            break;
          }
        case 2:
          {
            if (signals == "?.") return new string[] { "I", "N" };
            if (signals == "?-") return new string[] { "A", "M" };
            if (signals == "??") return new string[] {"I", "A", "N","M" };
            if (signals == ".?") return new string[] { "I", "A" };
            if (signals == "..") return new string[] { "I" };
            if (signals == ".-") return new string[] { "A" };
            if (signals == "-?") return new string[] { "N", "M" };
            if (signals == "--") return new string[] { "M" };
            if (signals == "-.") return new string[] { "N", };
            break;
          }
        case 3:
          {
            //  ?
            if (signals == "???") return new string[] { "S","U","R","W","D","K","G","O"};
            if (signals == "?.?") return new string[] { "S", "U", "D", "K" };
            if (signals == "?-?") return new string[] { "R", "W", "G", "O" };
            if (signals == "??.") return new string[] { "S", "R", "D", "G" };
            if (signals == "??-") return new string[] { "U", "W", "K", "O" };
            if (signals == "?..") return new string[] { "S","D"};
            if (signals == "?--") return new string[] { "W","O" };
            if (signals == "?-.") return new string[] { "R","G"};
            if (signals == "?.-") return new string[] { "U", "K"};
            //  .
            if (signals == ".??") return new string[] { "S", "U", "R", "W" };
            if (signals == ".?-") return new string[] { "U","W" };
            if (signals == ".?.") return new string[] { "S","R"};
            if (signals == "..?") return new string[] { "S", "U" };
            if (signals == "...") return new string[] { "S"};
            if (signals == "..-") return new string[] { "U"};
            if (signals == ".-?") return new string[] {"R", "W"};
            if (signals == ".--") return new string[] { "W"};
            if (signals == ".-.") return new string[] {"R"};
            //  -
            if (signals == "-??") return new string[] { "D", "K", "G", "O" };
            if (signals == "-?-") return new string[] { "K", "O" };
            if (signals == "-?.") return new string[] { "D","G" };
            if (signals == "--?") return new string[] { "G", "O" };
            if (signals == "--.") return new string[] { "G" };
            if (signals == "---") return new string[] {  "O" };
            if (signals == "-.?") return new string[] { "D", "K"};
            if (signals == "-.-") return new string[] { "K"};
            if (signals == "-..") return new string[] { "D"};

            break;
          }
        default:
          break;
      }
      return res;
    }
  }
}
