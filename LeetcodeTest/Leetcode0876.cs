using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode0876;


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

    public ListNode MiddleNode(ListNode head)
    {
        ListNode slowPointer = head;
        ListNode fastPointer = head;
        while (fastPointer != null && fastPointer.next!=null)
        {
            slowPointer = slowPointer.next;
            fastPointer = fastPointer.next.next;
        }
        return slowPointer;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[] nums, int expected)
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
        ListNode middleNode = solution.MiddleNode(head);
        Assert.AreEqual(expected, middleNode.val);
    }

    [TestMethod] public void Test1() { TestBase(new int[] { 1, 2, 3, 4, 5 }, 3); }
    [TestMethod] public void Test2() { TestBase(new int[] { 1, 2, 3, 4, 5, 6 }, 4); }

}
