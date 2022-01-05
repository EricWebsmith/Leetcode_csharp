namespace Leetcode0131;

/// <summary>
/// Runtime: 504 ms, faster than 89.03% of C# online submissions for Palindrome Partitioning.
/// Memory Usage: 59.2 MB, less than 92.83% of C# online submissions for Palindrome Partitioning.
/// </summary>
public class Solution
{
    int n;
    string s;
    IList<IList<string>> result = new List<IList<string>>();
    List<string> current = new List<string> ();
    bool[][] palindromeMatrix;

    private void Dfs(int i)
    {
        if (i >= n)
        {
            result.Add(current.ToArray());
            return;
        }

        for (int j = i; j < n; j++)
        {
            if (IsPalindrome(i, j))
            {
                current.Add(s.Substring(i, j - i + 1));
                Dfs(j+1);
                current.RemoveAt(current.Count - 1);
            }
        }
    }

    private bool IsPalindrome(int start, int end)
    {
        return palindromeMatrix[start][end];
    }

    private void BuildPalindromeMatrix()
    {
        palindromeMatrix = new bool[n][];
        for(int i = 0; i < n; i++)
        {
            palindromeMatrix[i] = new bool[n];
        }

        // odd, aba
        for (int i = 0; i < n; i++)
        {
            palindromeMatrix[i][i] = true;
            int step = 1;
            while (i - step >= 0 && i + step < n)
            {
                if(s[i-step] != s[i + step])
                {
                    break;
                }
                palindromeMatrix[i - step][i + step] = true;
                step++;
            }

            if (i+1<n && s[i] == s[i + 1])
            {
                palindromeMatrix[i][i+1] = true;
                step = 1;
                while (i - step >= 0 && i + step+1 < n)
                {
                    if (s[i - step] != s[i + step+1])
                    {
                        break;
                    }
                    palindromeMatrix[i - step][i + step+1] = true;
                    step++;
                }
            }
        }
    }

    public IList<IList<string>> Partition(string s)
    {
        this.s = s;
        n = s.Length;

        BuildPalindromeMatrix();
        Dfs(0);
        return result;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string s, int expected)
    {
        var actual = new Solution().Partition(s);
        Assert.AreEqual(expected, actual.Count);

        actual.Print2D();
    }

    [TestMethod] public void Test1() { TestBase("aab", 2); }
    [TestMethod] public void Test2() { TestBase("a", 1); }
    [TestMethod] public void Test3() { TestBase("aabb", 4); }
    //[TestMethod] public void Test4() { TestBase(); }
}