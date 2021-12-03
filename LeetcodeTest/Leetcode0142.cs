namespace Leetcode0142;

/// <summary>
/// Runtime: 88 ms, faster than 81.78% of C# online submissions for Linked List Cycle II.
/// Memory Usage: 39.3 MB, less than 63.40% of C# online submissions for Linked List Cycle II.
/// </summary>
public class Solution
{
    public ListNode DetectCycle(ListNode head)
    {
        if (head == null) { return null; }
        ListNode fast = head;
        ListNode slow = head;
        while (fast != null && fast.next != null)
        {
            fast = fast.next.next;
            slow = slow.next;

            if (slow == fast)
            {
                break;
            }
        }

        if (fast == null || fast.next == null)
        {
            return null;
        }

        fast = head;
        while (fast != slow)
        {
            fast = fast.next;
            slow = slow.next;
        }

        return fast;
    }
}

[TestClass]
public class SolutionTests
{
    [DataRow(1, "[3,2,0,-4]", 1)]
    [DataRow(2, "[1,2]", 0)]
    [DataRow(3, "[1]", -1)]
    [DataRow(4, "[0]", -1)]
    [DataRow(5, "[]", -1)]
    [DataRow(6, "[1,2,3,4,5,6,7]", 1)]
    [DataRow(7, "[-21,10,17,8,4,26,5,35,33,-7,-16,27,-12,6,29,-12,5,9,20,14,14,2,13,-24,21,23,-21,5]", 24)]
    [DataTestMethod]
    public void Test(int order, string headStr, int pos)
    {
        ListNode head = headStr.ToListNodeWithCircle(pos);
        ListNode actual = new Solution().DetectCycle(head);
        ListNode expected = head.Get(pos);

        if (actual != expected)
        {
            Console.WriteLine(expected?.val);
            Console.WriteLine(actual?.val);
        }
        Assert.AreEqual(expected, actual);
    }


}