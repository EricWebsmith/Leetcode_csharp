namespace Leetcode5955;

// https://leetcode.com/contest/weekly-contest-271/problems/maximum-fruits-harvested-after-at-most-k-steps/

/// <summary>
/// Runtime: 536 ms
/// </summary>
public class Solution
{
    public int MaxTotalFruits(int[][] fruits, int startPos, int k)
    {
        Dictionary<int, int> fruitDict = new Dictionary<int, int>();

        foreach (int[] fruit in fruits)
        {
            fruitDict.Add(fruit[0], fruit[1]);
        }

        int startFruit = 0;
        if (fruitDict.ContainsKey(startPos))
        {
            startFruit = fruitDict[startPos];
        }

        if (k == 0)
        {
            return startFruit;
        }

        // left sum
        int[] sumLeft = new int[k + 1];
        for (int i = 1; i <= k; i++)
        {

            sumLeft[i] = sumLeft[i - 1];
            int position = startPos - i;
            if (fruitDict.ContainsKey(position))
            {
                sumLeft[i] += fruitDict[position];
            }
        }

        // right sum
        int[] sumRight = new int[k + 1];
        for (int i = 1; i <= k; i++)
        {

            sumRight[i] = sumRight[i - 1];
            int position = startPos + i;
            if (fruitDict.ContainsKey(position))
            {
                sumRight[i] += fruitDict[position];
            }
        }


        int ans = 0;

        // left and turn
        int third = k / 3 + 1;
        for (int left = 0; left <= third; left++)
        {
            // left and turn
            int right = k - left * 2;
            left = Math.Max(left, 0);
            right = Math.Max(right, 0);
            ans = Math.Max(ans, startFruit + sumLeft[left] + sumRight[right]);
        }

        // right and turn
        for (int right = 0; right <= third; right++)
        {
            int left = k - right * 2;
            left = Math.Max(left, 0);
            right = Math.Max(right, 0);
            ans = Math.Max(ans, startFruit + sumLeft[left] + sumRight[right]);
        }

        return ans;
    }
}




[TestClass]
public class SolutionTests
{
    private void TestBase(string fruitsStr, int startPos, int k, int expected)
    {
        int[][] fruits = fruitsStr.LeetcodeToArray2D();
        int actual = new Solution().MaxTotalFruits(fruits, startPos, k);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[[2,8],[6,3],[8,6]]", 5, 4, 9); }
    [TestMethod] public void Test2() { TestBase("[[0,9],[4,1],[5,7],[6,2],[7,4],[10,9]]", 5, 4, 14); }
    [TestMethod] public void Test3() { TestBase("[[0,3],[6,4],[8,5]]", 3, 2, 0); }
    [TestMethod] public void Test4() { TestBase("[[5,6]]", 3, 3, 6); }
    [TestMethod] public void Test5() { TestBase("[[5,6]]", 10, 3, 0); }
    [TestMethod] public void Test6() { TestBase("[[200000,10000]]", 200000, 200000, 10000); }
    [TestMethod] public void Test7() { TestBase("[[200000,10000]]", 200000, 0, 10000); }
    [TestMethod] public void Test8() { TestBase("[[200000,10000]]", 0, 200000, 10000); }
    [TestMethod]
    public void Test9()
    {
        TestBase("[[0,7],[7,4],[9,10],[12,6],[14,8],[16,5],[17,8],[19,4],[20,1],[21,3],[24,3],[25,3],[26,1],[28,10],[30,9],[31,6],[32,1],[37,5],[40,9]]",
            21, 30, 71);
    }
}