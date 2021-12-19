namespace Leetcode0343
{
    /// <summary>
    /// First solution is the non-dp way. 
    /// We know that to make the product maximum
    /// The multipliers are to be even distributed.
    /// So we can try different k, everytime, the multiplier is
    /// just n/k.
    /// This is the maximum product given k.
    /// </summary>
    public class Solution
    {
        private int Product(int x, int y)
        {
            int result = 1;
            for (int i = 0; i < y; i++)
            {
                result *= x;
            }
            return result;
        }

        public int IntegerBreak(int n)
        {
            if (n == 2) { return 1; }
            if (n == 3) { return 2; }

            int maxProduct = 1;
            int kMax = n / 2;
            for (int k = 2; k <= kMax; k++)
            {
                int multiplicant = n / k;
                int reminder = n % k;
                int product = Product(multiplicant, k - reminder) * Product(multiplicant + 1, reminder);
                maxProduct = Math.Max(maxProduct, product);
            }

            return maxProduct;
        }
    }

    [TestClass]
    public class SolutionTest
    {
        [TestMethod]
        public void Test()
        {
            Solution solution = new Solution();
            for (int n = 2; n <= 58; n++)
            {
                int result = solution.IntegerBreak(n);
                Console.WriteLine($"{n}: {result}");
            }
        }
    }
}

namespace Leetcode0343Dp
{
    public class Solution
    {
        private int Product(int x, int y)
        {
            int result = 1;
            for (int i = 0; i < y; i++)
            {
                result *= x;
            }
            return result;
        }

        public int IntegerBreak(int n)
        {
            if (n == 2) { return 1; }
            if (n == 3) { return 2; }

            int[] dp = new int[n + 1];
            dp[1] = 1;
            dp[2] = 2;
            dp[3] = 3;
            //dp[4] = 4;


            for (int dpIndex = 4; dpIndex <= n; dpIndex++)
            {
                // cut different multiplier from n
                for (int multiplier = 2; multiplier <= dpIndex; multiplier++)
                {
                    dp[dpIndex] = Math.Max(dp[dpIndex], multiplier * dp[dpIndex - multiplier]);
                }

            }

            return dp[n];
        }
    }

    [TestClass]
    public class SolutionTest
    {
        [TestMethod]
        public void TestDp()
        {
            Solution solution = new Solution();
            for (int n = 2; n <= 58; n++)
            {
                int result = solution.IntegerBreak(n);
                Console.WriteLine($"{n}: {result}");
            }
        }
    }
}
