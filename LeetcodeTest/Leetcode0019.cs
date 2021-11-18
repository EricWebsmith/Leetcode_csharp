namespace Leetcode0019;


// Definition for singly-linked list.
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode preHead = new ListNode(0);
        preHead.next = head;
        ListNode slowPointer = preHead;
        ListNode fastPointer = preHead;

        int index = 0;
        while (fastPointer != null)
        {

            fastPointer = fastPointer.next;
            if (index > n)
            {
                slowPointer = slowPointer.next;
            }
            index++;
        }


        ListNode deleted = slowPointer.next;
        if (slowPointer.next != null)
        {
            slowPointer.next = slowPointer.next.next;
        }



        return deleted;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[] nums, int n, int expected)
    {
        // Build linkNode
        ListNode head = new ListNode(nums[0]);
        ListNode current = head;
        for (int i = 1; i < nums.Length; i++)
        {
            ListNode node = new ListNode(nums[i]);
            current.next = node;
            current = node;
        }

        Solution solution = new Solution();
        ListNode listNode = solution.RemoveNthFromEnd(head, n);
        Assert.AreEqual(expected, listNode.val);

    }

    //[TestMethod] public void Test1() { TestBase(new int[] { 1, 2, 3, 4, 5 }, 2, 4); }
    //[TestMethod] public void Test2() { TestBase(new int[] { 1 }, 1, 1); }

    //[TestMethod] public void Test3() { TestBase(new int[] { 1, 2 }, 1, 1); }
    //[TestMethod] public void Test4() { TestBase(new int[] { 1, 2 }, 2, 2); }

}
