namespace Leetcode0078_DFS
{
    public class Solution
    {
        IList<IList<int>> results = new List<IList<int>>();
        int[] nums;

        public IList<IList<int>> Subsets(int[] nums)
        {
            Array.Sort(nums);
            this.nums = nums;
            Recurse(new List<int>(), 0);

            return results;
        }

        private void Recurse(List<int> oldOption, int index)
        {
            if (index>=nums.Length)
            {
                results.Add(oldOption);
                return;
            }

            List<int> optionDoNothing = oldOption.ToList();
            List<int> optionAdd=oldOption.ToList();
            optionAdd.Add(nums[index]);

            Recurse(optionDoNothing, index+1);
            Recurse(optionAdd, index + 1);
        }
    }

    [TestClass]
    public class SolutionTest
    {
        [DataRow(1, "[1,2,3]", 8)]
        [DataRow(2, "[0]", 2)]
        [DataTestMethod]
        public void Test(int order, string numsStr, int expected)
        {
            int[] nums = Helper.Convert1D(numsStr);
            IList<IList<int>> actual = new Solution().Subsets(nums);
            Helper.Print2D<int>(actual);
            Assert.AreEqual(expected, actual.Count);
        }
    }
}

namespace Leetcode0078_BFS
{
    public class Solution
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> results = new List<IList<int>>();

            // Array.Sort(nums);

            Queue<List<int>> q = new Queue<List<int>>();
            q.Enqueue(new List<int>());
            while (q.Count > 0)
            {
                List<int> subset = q.Dequeue();
                int lastIndex = -1;
                if (subset.Count > 0)
                {
                    lastIndex = subset.Last();
                }

                for (int i = lastIndex + 1; i < nums.Length; i++)
                {
                    List<int> newSubSet = subset.ToList();
                    newSubSet.Add(i);
                    q.Enqueue(newSubSet);
                }

                List<int> result = new List<int>();
                foreach (int i in subset)
                {
                    result.Add(nums[i]);
                }
                results.Add(result);

            }
            return results;
        }
    }

    [TestClass]
    public class SolutionTest
    {
        [DataRow(1, "[1,2,3]", 8)]
        [DataRow(2, "[0]", 2)]
        [DataTestMethod]
        public void Test(int order, string numsStr, int expected)
        {
            int[] nums = Helper.Convert1D(numsStr);
            IList<IList<int>> actual = new Solution().Subsets(nums);
            Helper.Print2D<int>(actual);
            Assert.AreEqual(expected, actual.Count);
        }
    }
}
