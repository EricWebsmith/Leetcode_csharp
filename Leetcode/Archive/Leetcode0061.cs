namespace Leetcode0061;

public class Solution
{
    public ListNode RotateRight(ListNode head, int k)
    {
        if (head == null || k == 0) { return head; }
        ListNode current = head;

        // find count and last
        ListNode last = null;
        int count = 0;
        while (current != null)
        {
            count++;
            if (current.next == null)
            {
                last = current;
            }
            current = current.next;
        }

        k = k % count;
        if (k == 0) { return head; }
        int forward = count - k;
        current = head;

        // find prehead
        ListNode preHead = null;
        int newCount = 0;
        while (current != null)
        {

            newCount++;
            if (newCount == forward)
            {
                preHead = current;
                break;
            }
            current = current.next;
        }

        ListNode newHead = preHead.next;
        preHead.next = null;
        last.next = head;
        return newHead;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string headStr, int k, string expected)
    {
        ListNode head = headStr.LeetcodeToListNode();
        ListNode newHead = new Solution().RotateRight(head, k);
        string actual = newHead.ToLeetcode();
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[1,2,3,4,5]", 2, "[4,5,1,2,3]"); }
    [TestMethod] public void Test2() { TestBase("[0,1,2]", 4, "[2,0,1]"); }
    [TestMethod] public void Test3() { TestBase("[0,1,2]", 1, "[2,0,1]"); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}