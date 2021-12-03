namespace Leetcode0082;

/// <summary>
/// Runtime: 84 ms, faster than 78.99% of C# online submissions for Remove Duplicates from Sorted List II.
/// Memory Usage: 38.9 MB, less than 33.70% of C# online submissions for Remove Duplicates from Sorted List II.
/// </summary>
public class Solution
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        if(head == null) { return null; }

        ListNode prehead = new ListNode(-1);
        prehead.next = head;

        ListNode slow = prehead;
        ListNode fast = head;
        while (fast.next != null)
        {
            if (fast.val == fast.next.val)
            {
                int val = fast.val;
                while (fast != null && fast.val == val)
                {

                    fast = fast.next;
                }
                slow.next = fast;
                if (fast == null) { return prehead.next; }
                // fast = fast.next;

            }
            else
            {

                slow = fast;
                fast = fast.next;
            }


        }

        return prehead.next;
    }
}

[TestClass]
public class SolutionTests
{
    [DataRow(1, "[1,2,3,3,4,4,5]", "[1,2,5]")]
    [DataRow(2, "[1,1,1,2,3]", "[2,3]")]
    [DataRow(3, "[1,1,1,2,2,3]", "[3]")]
    [DataRow(4, "[1,2,2,2,3]", "[1,3]")]
    [DataRow(5, "[]", "[]")]
    [DataTestMethod]
    public void Test(int order, string headStr, string expected)
    {
        ListNode head = headStr.ToListNode();
        var actual = new Solution().DeleteDuplicates(head);
        Assert.AreEqual(expected, actual.ToStr());
    }
}
