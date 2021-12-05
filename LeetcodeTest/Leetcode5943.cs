namespace Leetcode5943;

// 2095

public class Solution
{
    public ListNode DeleteMiddle(ListNode head)
    {
        if(head.next == null)
        {
            return null;
        }

        ListNode slow = head;
        ListNode fast = head.next;

        fast = fast.next;

        while (fast != null && fast.next!=null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        if(slow.next == null)
        {
            return head;
        }

        slow.next = slow.next.next;

        return head;
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(string headStr, string expected)
    {
        ListNode head = headStr.LeetcodeToListNode();
        ListNode actual = new Solution().DeleteMiddle(head);
        Assert.AreEqual(expected, actual.ToLeetcode());
    }

    [TestMethod] public void Test1() { TestBase("[1,3,4,7,1,2,6]", "[1,3,4,1,2,6]"); }
    [TestMethod] public void Test2() { TestBase("[1,2,3,4]", "[1,2,4]"); }
    [TestMethod] public void Test3() { TestBase("[2,1]", "[2]"); }
    [TestMethod] public void Test4() { TestBase("[1]", "[]"); }
}