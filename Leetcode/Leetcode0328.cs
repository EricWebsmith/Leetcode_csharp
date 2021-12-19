namespace Leetcode0328;

/// <summary>
/// Runtime: 80 ms, faster than 91.26% of C# online submissions for Odd Even Linked List.
/// Memory Usage: 39.1 MB, less than 43.99% of C# online submissions for Odd Even Linked List.
/// </summary>
public class Solution
{
    public ListNode OddEvenList(ListNode head)
    {
        if(head == null) { return head; }
        if(head.next == null) { return head; }

        ListNode oddPointer = head;
        // head is odd head, so we do not need an odd head.
        ListNode evenPointer = head.next;
        ListNode evenHead = evenPointer;

        ListNode current = evenPointer.next;

        bool odd = true;
        while (current != null)
        {
            if(odd)
            {
                oddPointer.next = current;
                oddPointer = oddPointer.next;
            }
            else
            {
                evenPointer.next = current;
                evenPointer = evenPointer.next;
            }
            current = current.next;
            odd = !odd;
        }

        oddPointer.next = evenHead;
        evenPointer.next = null;

        return head;
    }
}

[TestClass]
public class SolutionTests
{
    [DataRow(1, "[1,2,3,4,5]", "[1,3,5,2,4]")]
    [DataRow(2, "[2,1,3,5,6,4,7]", "[2,3,6,7,1,5,4]")]
    [DataRow(3, "[1,2,3,4,5,6]", "[1,3,5,2,4,6]")]
    [DataRow(4, "[]", "[]")]
    [DataRow(5, "[2,4,6,1,3,1]", "[2,6,3,4,1,1]")]
    [DataRow(6, "[1]", "[1]")]
    [DataTestMethod]
    public void Test(int order, string headStr, string expectedStr)
    {
        ListNode head = headStr.ToListNode();
        ListNode actual = new Solution().OddEvenList(head);
        string actualStr = actual.ToStr();
        Assert.AreEqual(expectedStr, actualStr);
    }
}