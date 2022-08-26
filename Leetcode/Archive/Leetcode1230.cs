namespace Leetcode1230;

public class Solution
{
    double[] prob;
    double[][] cache;

    private double Solve(int index, int target)
    {
        if (cache[index][target] != -1)
        {
            return cache[index][target];
        }
        double p = 1;
        if (target == 0)
        {
            for (int i = index; i < prob.Length; i++)
            {
                p *= 1 - prob[i];
            }
        }
        else if (index == prob.Length)
        {
            return 0;
        }
        else
        {
            if (target > 0)
            {
                p = prob[index] * Solve(index + 1, target - 1);
            }

            p += (1 - prob[index]) * Solve(index + 1, target);
        }

        cache[index][target] = p;
        return p;
    }

    public double ProbabilityOfHeads(double[] prob, int target)
    {
        int n = prob.Length;
        this.prob = prob;
        this.cache = new double[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            double[] iCache = new double[target+1];
            Array.Fill(iCache, -1);
            this.cache[i] = iCache;
        }

        double result = Solve(0, target);
        ArrayHelper.Print2D(this.cache);
        return result;

    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(string probStr, int target, double expected)
    {
        double[] prob = probStr.LeetcodeToDoubleArray();
        double actual = new Solution().ProbabilityOfHeads(prob, target);
        //Assert.IsTrue(Math.Abs( expected-actual)<0.00001);
        Assert.AreEqual(expected, actual, 0.000001);
    }

    [TestMethod] public void Test1() { TestBase("[0.4]", 1, 0.4); }
    [TestMethod] public void Test2() { TestBase("[0.5,0.5,0.5,0.5,0.5]", 0, 0.03125); }
    [TestMethod] public void Test3() { TestBase("[1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1]", 99, 0); }
    [TestMethod] public void Test4() { TestBase("[0.2,0.3,0.4,0.5,0.6]", 3, 0.2344); }
    [TestMethod] public void Test5() { TestBase("[0.2,0.3,0.4]", 2, 0.188); }
    [TestMethod] public void Test5_() { TestBase("[0.4,0.3,0.2]", 2, 0.188); }
    [TestMethod] public void Test5__() { TestBase("[0.5, 0.4,0.3,0.2]", 2, 0.188); }
    [TestMethod] public void Test6() { TestBase("[0.2,0.3,0.4]", 3, 0.024); }
    //[TestMethod] public void Test4() { TestBase(); }

}

/*
Runtime: 168 ms, faster than 50.00% of C# online submissions for Toss Strange Coins.
Memory Usage: 57.2 MB, less than 12.50% of C# online submissions for Toss Strange Coins.
 */