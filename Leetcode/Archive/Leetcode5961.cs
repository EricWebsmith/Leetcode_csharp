namespace Leetcode5961;


public class Solution
{
    public int PairSum(ListNode head)
    {
        List<int> list = new List<int>();
        ListNode current = head;
        while (current != null)
        {
            list.Add(current.val);
            current = current.next;
        }

        int n = list.Count;
        int maxTwin = int.MinValue;
        for (int i = 0; i < n/2; i++)
        {
            int twin = list[i]+list[n-i-1];
            maxTwin = Math.Max(maxTwin, twin);
        }
        return maxTwin;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string headStr, int expected)
    {
        ListNode head = headStr.LeetcodeToListNode();
        int actual = new Solution().PairSum(head);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[5,4,2,1]", 6); }
    [TestMethod] public void Test2() { TestBase("[4,2,2,3]", 7); }
    [TestMethod] public void Test3() { TestBase("[1,100000]", 100001); }
    [TestMethod] public void Test4() { TestBase("[1,2,3,4,5,6,7,8,9,19]", 20); }

}