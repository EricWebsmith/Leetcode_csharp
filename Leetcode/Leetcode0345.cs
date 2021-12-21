namespace Leetcode0345;

/// <summary>
/// Runtime: 84 ms, faster than 89.79% of C# online submissions for Reverse Vowels of a String.
/// Memory Usage: 40.5 MB, less than 44.68% of C# online submissions for Reverse Vowels of a String.
/// </summary>
public class Solution
{
    public string ReverseVowels(string s)
    {
        int n = s.Length;
        char[] arr = s.ToCharArray();
        int lo = 0;
        int hi = n - 1;
        HashSet<char> vowels = new HashSet<char>();
        vowels.Add('a');
        vowels.Add('i');
        vowels.Add('u');
        vowels.Add('e');
        vowels.Add('o');
        vowels.Add('A');
        vowels.Add('I');
        vowels.Add('U');
        vowels.Add('E');
        vowels.Add('O');
        while (lo < hi)
        {
            while (lo < n && lo<hi)
            {
                if(!vowels.Contains(arr[lo]))
                {
                    lo++;
                }
                else
                {
                    break;
                }
            }

            while (hi > 0 && lo<hi)
            {
                if (!vowels.Contains(arr[hi]))
                {
                    hi--;
                }
                else
                {
                    break;
                }
            }

            char temp = arr[lo];
            arr[lo] = arr[hi];
            arr[hi] = temp;

            hi--;
            lo++;
        }

        return new string(arr);
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string s, string expected)
    {
        string actual = new Solution().ReverseVowels(s);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("hello", "holle"); }
    [TestMethod] public void Test2() { TestBase("leetcode", "leotcede"); }
    [TestMethod] public void Test3() { TestBase("book", "book"); }
    [TestMethod] public void Test4() { TestBase("tea", "tae"); }

    [TestMethod] public void TestPerformance()
    {
        StringBuilder sb = new StringBuilder(300000);
        for(int i = 0; i <100000; i++)
        {
            sb.Append("tea");
        }
        new Solution().ReverseVowels(sb.ToString());
    }
}