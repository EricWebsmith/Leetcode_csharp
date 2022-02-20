namespace Leetcode6013;


public class Solution
{
    public ListNode MergeNodes(ListNode head)
    {
        ListNode preHead = new ListNode(-1);
        ListNode ans = preHead;
        ListNode current = head.next;
        int val = 0;
        while (current != null)
        {
            if(current.val == 0)
            {
                ans.next = new ListNode(val);
                ans = ans.next;
                val = 0;
            }
            else
            {
                val += current.val;
            }
            current = current.next;
        }

        return preHead.next;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string headStr, string expected)
    {
        ListNode head = headStr.LeetcodeToListNode();
        string actual = new Solution().MergeNodes(head).ToLeetcode();
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[0,3,1,0,4,5,2,0]", "[4,11]"); }
    [TestMethod] public void Test2() { TestBase("[0,1,0,3,0,2,2,0]", "[1,3,4]"); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}