using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Leetcode2062;

public class Solution
{

    public int CountVowelSubstrings(string word)
    {
        int result = 0;
        HashSet<char> vowels = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u' };
        Dictionary<char, int> charInts = new Dictionary<char, int>();
        charInts.Add('a', 1);
        charInts.Add('e', 2);
        charInts.Add('i', 4);
        charInts.Add('o', 8);
        charInts.Add('u', 16);

        int aeiou = 1 + 2 + 4 + 8 + 16;


        for(int i=0; i<word.Length-4; i++)
        {
            int temp = 0;
            for(int j=i;j<word.Length; j++)
            {
                char ch = word[j];
                if (!charInts.ContainsKey(ch))
                {
                    break;
                }
                int chInt = charInts[ch];
                temp = temp | chInt;
                if(temp == aeiou)
                {
                    result++;
                }
            }
            Console.WriteLine($"{i} {word[i]} {result}");
        }

        return result;
    }

}

[TestClass]
public class SolutionTest
{
    private void TestBase(string word, int expected)
    {
        int actual = (new Solution()).CountVowelSubstrings(word);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test01() { TestBase("aeiouu", 2);}
    [TestMethod] public void Test02() { TestBase("unicornarihan", 0); }
    [TestMethod] public void Test03() { TestBase("cuaieuouac", 7); }
    [TestMethod] public void Test04() { TestBase("bbaeixoubb", 0); }
    [TestMethod] public void Test05() { TestBase("bbbbbbbb", 0); }
    [TestMethod] public void Test06() { TestBase("aa", 0); }
    [TestMethod] public void Test07() { TestBase("poazaeuioauoiioaouuouaui", 31); }
    [TestMethod] public void Test08() { TestBase("duuebuaeeeeeeuaoeiueaoui", 81); }
}