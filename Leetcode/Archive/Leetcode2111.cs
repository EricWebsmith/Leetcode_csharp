namespace Leetcode2111;


public class Solution
{
    private void BinaryInsertLeft(List<int> list, int num)
    {
        int lo = 0;
        int hi = list.Count - 1;
        int mid = (lo + hi) / 2;
        while (lo < hi)
        {
            if(list[mid] > num)
            {
                hi = mid;
            }
            else
            {
                lo = mid + 1;
            }
            mid = (lo + hi) / 2;
        }
        list[mid] = num;
    }

    public int KIncreasing(int[] arr, int k)
    {
        int n = arr.Length;
        List<int>[] lists = new List<int>[k];
        for(int kk = 0; kk < k; kk++)
        {
            lists[kk] = new List<int> { arr[kk] };
        }

        for(int i = k; i < n; i++)
        {
            int kk = i % k;
            if (arr[i] >= lists[kk].Last())
            {
                lists[kk].Add(arr[i]);
            }
            else
            {
                BinaryInsertLeft(lists[kk], arr[i]);
            }
            
        }

        return n - lists.Select(list=>list.Count).Sum();
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string arrStr, int k, int expected)
    {
        int[] arr = arrStr.LeetcodeToArray();
        int actual = new Solution().KIncreasing(arr, k);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[5,4,3,2,1]", 1, 4); }
    [TestMethod] public void Test2() { TestBase("[4,1,5,2,6,2]",2, 0); }
    [TestMethod] public void Test3() { TestBase("[4,1,5,2,6,2]", 3, 2); }
    [TestMethod] public void Test4() { TestBase("[1,2,3,4]",2,0); }
    [TestMethod] public void Test5() { TestBase("[1]",1,0); }
    [TestMethod] public void Test6() { TestBase("[7,7,7,7,7,7,7,7,7,7,7,7,7,]", 1, 0); }
    [TestMethod] public void Test7() { TestBase("[2,2,2,2,2,1,1,4,4,3,3,3,3,3]", 1, 4); }
    [TestMethod] public void Test_Performance1() { TestBase("[100000...1]",1,99999); }
    [TestMethod] public void Test_Performance2() { TestBase("[1...100000]",1,0); }
    
}