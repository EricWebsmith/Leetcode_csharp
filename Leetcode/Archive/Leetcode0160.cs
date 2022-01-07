namespace Leetcode0160;

/// <summary>
/// Runtime: 116 ms, faster than 91.23% of C# online submissions for Intersection of Two Linked Lists.
/// Memory Usage: 44.9 MB, less than 49.34% of C# online submissions for Intersection of Two Linked Lists.
/// </summary>
public class Solution
{
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        ListNode currentA = headA;
        ListNode currentB = headB;

        while(currentA != null || currentB != null)
        {
            if(currentA == null)
            {
                currentA = headB;
            }
            if(currentB == null)
            {
                currentB = headA;
            }

            if(currentA == currentB)
            {
                return currentA;
            }

            currentA = currentA.next;
            currentB = currentB.next;
        }

        return null;
    }
}

[TestClass]
public class SolutionTests
{

    [TestMethod]
    public void Test1()
    {
        // shared part
        ListNode node4 = new ListNode(4);
        ListNode node2 = new ListNode(2);
        node2.next = node4;

        //a
        ListNode node1 = new ListNode(1);
        node1.next = node2;
        ListNode node9 = new ListNode(9);
        node9.next = node1;
        ListNode headA = new ListNode(1);
        headA.next = node9;

        //b
        ListNode headB = new ListNode(3);
        headB.next = node2;

        ListNode expected = node2;

        ListNode actual = new Solution().GetIntersectionNode(headA, headB);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test2()
    {
        // a
        ListNode headA = "2,6,4".ToListNode();
        // b
        ListNode headB = "[1,5]".ToListNode();

        ListNode actual = new Solution().GetIntersectionNode(headA, headB);
        Assert.IsTrue(null == actual);
    }
}