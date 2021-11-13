using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leetcode704;

namespace LeetcodeTest
{
    [TestClass]
    public class LeetcodeTest704
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] nums = { -1, 0, 3, 5, 9, 12 };
            Solution solution = new Solution();
            var result = solution.Search(nums, 9);
            Assert.AreEqual(4, result);

        }
    }
}