namespace Leetcode5942;

// 2094
// https://leetcode.com/contest/weekly-contest-270/problems/finding-3-digit-even-numbers/

public class Solution
{
    List<int> current = new List<int>();
    List<int> rest = new List<int>();
    int[] digits;
    HashSet<int> results = new HashSet<int>();

    private void Build()
    {
        if(current.Count == 3)
        {
            int number = current[0] * 100 + current[1] * 10 + current[2];
            results.Add(number);
            return;
        }

        int restCount = rest.Count;
        for(int i=0;i<restCount;i++)
        {
            int v = rest[i];
            if(current.Count == 0 && v ==0) { continue; }
            if (current.Count == 2 && v % 2 == 1) { continue; }
            
            current.Add(v);
            rest.RemoveAt(i);
            Build();
            current.RemoveAt(current.Count - 1);    
            rest.Insert(i, v);
        }
    }

    public int[] FindEvenNumbers(int[] digits)
    {
        Array.Sort(digits);
        this.digits = digits;
        rest = digits.ToList();
        Build();

        return results.ToArray();
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(string digitsStr, string expected)
    {
        int[] digits = digitsStr.LeetcodeToArray();
        int[] actual = new Solution().FindEvenNumbers(digits);
        Assert.AreEqual(expected, actual.ToLeetcode());
    }

    [TestMethod] public void Test1() { TestBase("[2,1,3,0]", "[102,120,130,132,210,230,302,310,312,320]"); }
    [TestMethod] public void Test2() { TestBase("[2,2,8,8,2]", "[222,228,282,288,822,828,882]"); }
    [TestMethod] public void Test3() { TestBase("[3,7,5]", "[]"); }
    [TestMethod] public void Test4() { TestBase("[0,2,0,0]", "[200]"); }
    [TestMethod] public void Test5() { TestBase("[0,0,0]", "[]"); }
}
