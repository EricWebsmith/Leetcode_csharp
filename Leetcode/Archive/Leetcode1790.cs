namespace Leetcode1790;


public class Solution
{
    public bool AreAlmostEqual(string s1, string s2)
    {
        if (s1 == s2)
        {
            return true;
        }

        int n = s1.Length;

        int diffIndex = -1;
        bool swapped = false;
        for (int i = 0; i < n; i++)
        {
            if (s1[i] == s2[i])
            {
                continue;
            }
            if (swapped)
            {
                return false;
            }

            if (diffIndex >= 0)
            {
                if (s1[diffIndex] == s2[i] && s1[i] == s2[diffIndex])
                {
                    swapped = true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                diffIndex = i;
            }
        }

        return swapped;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase()
    {

    }

    //[TestMethod] public void Test1() { TestBase(); }
    //[TestMethod] public void Test2() { TestBase(); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}

/*
 Runtime: 76 ms, faster than 90.55% of C# online submissions for Check if One String Swap Can Make Strings Equal.
Memory Usage: 38.3 MB, less than 15.75% of C# online submissions for Check if One String Swap Can Make Strings Equal.
 */