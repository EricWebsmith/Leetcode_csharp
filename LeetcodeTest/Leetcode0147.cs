namespace Leetcode0147;

/// <summary>
/// Runtime: 116 ms, faster than 61.04% of C# online submissions for Insertion Sort List.
/// Memory Usage: 39.2 MB, less than 31.17% of C# online submissions for Insertion Sort List.
/// </summary>
public class Solution
{
    private void Insert(ListNode head, ListNode newNode)
    {
        ListNode current = head;
        while (current != null)
        {
            ListNode next = current.next;
            if(next == null)
            {
                current.next = newNode;
                return;
            }

            if(next.val > newNode.val)
            {
                current.next = newNode;
                newNode.next = next;
                return;
            }

            current = next;
        }
    }

    public ListNode InsertionSortList(ListNode head)
    {
        Queue<ListNode> queue = new Queue<ListNode>();

        ListNode newHead = new ListNode(int.MinValue);
        ListNode current = head;
        while (current != null)
        {
            ListNode next = current.next;
            current.next = null;
            Insert(newHead, current);

            current = next;
        }

        return newHead.next;
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(string headStr, string expected)
    {
        ListNode root = headStr.LeetcodeToListNode();
        ListNode actual = new Solution().InsertionSortList(root);
        Assert.AreEqual(expected, actual.ToLeetcode());

    }

    [TestMethod] public void Test1() { TestBase("[4,2,1,3]", "[1,2,3,4]"); }
    [TestMethod] public void Test2() { TestBase("[-1,5,3,4,0]", "[-1,0,3,4,5]"); }
    [TestMethod] public void Test3() { TestBase("[1]", "[1]"); }
    [TestMethod] public void Test4() { TestBase("[3,2,1]","[1,2,3]"); }
}