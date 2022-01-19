namespace Leetcode0849.For
{
    /// <summary>
    /// Runtime: 92 ms, faster than 92.50% of C# online submissions for Maximize Distance to Closest Person.
    /// Memory Usage: 41.4 MB, less than 33.33% of C# online submissions for Maximize Distance to Closest Person.
    /// </summary>
    public class Solution
    {
        public int MaxDistToClosest(int[] seats)
        {
            int n = seats.Length;
            int left = 0;
            int right = n - 1;
            int maxDistance = 0;


            for(; seats[right] == 0; right--) { }
            maxDistance = Math.Max(maxDistance, n - 1 - right);

            for(;seats[left] == 0; left++) { }
            maxDistance = Math.Max(maxDistance, left - 0);

            int lastLeft = left;
            for (int i = left; i <= right; i++)
            {
                if (seats[i] == 1)
                {
                    maxDistance = Math.Max(maxDistance, (i - lastLeft) / 2);
                    lastLeft = i;
                }
            }

            return maxDistance;
        }
    }


    [TestClass]
    public class SolutionTests
    {
        private void TestBase(string seatsStr, int expected)
        {
            int[] seats = seatsStr.LeetcodeToArray();
            int actual = new Solution().MaxDistToClosest(seats);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod] public void Test1() { TestBase("[1,0,0,0,1,0,1]", 2); }
        [TestMethod] public void Test2() { TestBase("[1,0,0,0]", 3); }
        [TestMethod] public void Test3() { TestBase("[0,1]", 1); }
        [TestMethod] public void Test4() { TestBase("[1,0,0,0,0,1]", 2); }
        [TestMethod] public void TestPerformace()
        {
            for(int i = 0; i < 10000; i++)
            {
                Test1();
                Test2();
                Test3();
                Test4();
            }
        }
    }
}


namespace Leetcode0849.While
{
    /// <summary>
    /// Runtime: 96 ms, faster than 83.33% of C# online submissions for Maximize Distance to Closest Person.
    /// Memory Usage: 41.3 MB, less than 36.67% of C# online submissions for Maximize Distance to Closest Person.
    /// </summary>
    public class Solution
    {
        public int MaxDistToClosest(int[] seats)
        {
            int n = seats.Length;
            int left = 0;
            int right = n - 1;
            int maxDistance = 0;

            while (seats[right] == 0)
            {
                right--;
            }
            maxDistance = Math.Max(maxDistance, n - 1 - right);

            while (seats[left] == 0)
            {
                left++;
            }
            maxDistance = Math.Max(maxDistance, left - 0);

            int lastLeft = left;
            while (left <= right)
            {
                if (seats[left] == 1)
                {
                    maxDistance = Math.Max(maxDistance, (left - lastLeft) / 2);
                    lastLeft = left;
                }
                left++;
            }

            return maxDistance;
        }
    }


    [TestClass]
    public class SolutionTests
    {
        private void TestBase(string seatsStr, int expected)
        {
            int[] seats = seatsStr.LeetcodeToArray();
            int actual = new Solution().MaxDistToClosest(seats);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod] public void Test1() { TestBase("[1,0,0,0,1,0,1]", 2); }
        [TestMethod] public void Test2() { TestBase("[1,0,0,0]", 3); }
        [TestMethod] public void Test3() { TestBase("[0,1]", 1); }
        [TestMethod] public void Test4() { TestBase("[1,0,0,0,0,1]", 2); }
        [TestMethod]
        public void TestPerformace()
        {
            for (int i = 0; i < 10000; i++)
            {
                Test1();
                Test2();
                Test3();
                Test4();
            }
        }
    }
}
