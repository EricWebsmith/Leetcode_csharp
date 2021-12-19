namespace Leetcode0024;

/// <summary>
/// Runtime: 72 ms, faster than 98.13% of C# online submissions for Swap Nodes in Pairs.
/// Memory Usage: 37.1 MB, less than 63.35% of C# online submissions for Swap Nodes in Pairs.
/// </summary>
public class Solution
{
    public ListNode SwapPairs(ListNode head)
    {
        if(head == null) { return null; }
        if(head.next == null) { return head; }
        ListNode slow = new ListNode(-1);
        slow.next = head;
        ListNode odd = head;
        ListNode even = head.next;
        head = head.next;
        while(odd != null && even != null)
        {
            ListNode next = even.next;
            slow.next = even ;
            even.next = odd;
            odd.next = next;
            slow = odd;

            if(next!=null && next.next != null)
            {
                odd = next;
                even = next.next;
            }
            else
            {
                break;
            }
            
        }

        return head;
    }
}

[TestClass]
public class SolutionTests
{
    [DataRow(1, "[1,2,3,4]", "[2,1,4,3]")]
    [DataRow(2, "[]", "[]")]
    [DataRow(3, "[1]", "[1]")]
    [DataRow(4, "[1,2,3,4,5]", "[2,1,4,3,5]")]
    [DataRow(5, "[1,2,3,4,5,6]", "[2,1,4,3,6,5]")]
    [DataTestMethod]
    public void Test(int order, string headStr, string expected)
    {
        ListNode head = headStr.ToListNode();
        ListNode actual = new Solution().SwapPairs(head);
        Console.WriteLine($"{expected==actual.ToStr()} {expected} {actual.ToStr()}");
        Assert.AreEqual(expected, actual.ToStr());
    }

}
