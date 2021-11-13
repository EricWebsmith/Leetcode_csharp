using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode0203;

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
    public ListNode RemoveElements(ListNode head, int val)
    {
        if (head == null)
        {
            return null;
        }
        ListNode? slowPointer = new ListNode(0);
        slowPointer.next = head;
        ListNode preHead = slowPointer;
        ListNode? fastPointer = head;

        while (fastPointer != null)
        {
            if(fastPointer.val == val)
            {
                while(fastPointer != null && fastPointer.val == val)
                {
                    fastPointer = fastPointer.next;
                }
                slowPointer.next = fastPointer;
            }

            slowPointer = slowPointer?.next;
            fastPointer = fastPointer?.next;
        }

        return preHead.next;
    }
}

[TestClass]
public class SolutionTest
{
    private int[] ToArray(ListNode node)
    {
        if (node == null)
        {
            return new int[] { };
        }

        List<int> list = new List<int>();

        while (node != null)
        {
            list.Add(node.val);
            node = node.next;
        }
        return list.ToArray();
    }

    private ListNode ToListNode(int[] arr)
    {
        if (arr.Length == 0) { return null; }
        ListNode head = new ListNode(arr[0]);
        ListNode previousNode = head;

        for (int i = 1; i < arr.Length; i++)
        {
            ListNode node = new ListNode(arr[i]);
            previousNode.next = node;
            previousNode = node;
        }
        return head;
    }

    private void TestBase(int[] head, int val, int[] expected)
    {
        ListNode headNode = ToListNode(head);
        Solution solution = new Solution();
        ListNode newHeadNode = solution.RemoveElements(headNode, val);
        int[] actual = ToArray(newHeadNode);
        Assert.AreEqual(expected.Length, actual.Length);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.AreEqual(expected[i], actual[i]);
        }

    }

    [TestMethod] public void Test1() { TestBase(new int[] { 1, 2, 6, 3, 4, 5, 6 }, 6, new int[] { 1, 2, 3, 4, 5 }); }
    [TestMethod] public void Test2() { TestBase(new int[] { }, 1, new int[] { }); }
    [TestMethod] public void Test3() { TestBase(new int[] { 7, 7, 7, 7 }, 7, new int[] { }); }
    [TestMethod] public void Test4() { TestBase(new int[] { 7, 7, 7, 7 , 1}, 7, new int[] {1 }); }
    [TestMethod] public void Test5() { TestBase(new int[] { 1,7, 7, 7, 7}, 7, new int[] { 1 }); }
}

