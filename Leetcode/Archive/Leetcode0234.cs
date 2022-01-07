namespace Leetcode0234;

/// <summary>
/// Runtime: 260 ms, faster than 95.90% of C# online submissions for Palindrome Linked List.
/// Memory Usage: 49 MB, less than 92.91% of C# online submissions for Palindrome Linked List.
/// </summary>
public class Solution
{
    public bool IsPalindrome(ListNode head)
    {
        ListNode fast = head;
        ListNode slow = head;
        Stack<int> stack = new Stack<int>();
        while (fast != null && fast.next!=null){
            stack.Push(slow.val);
            slow = slow.next;
            fast = fast.next.next;
        }

        if (fast != null)
        {
            slow = slow.next;
        }

        while (slow != null)
        {
            int val = slow.val;
            int stackVal = stack.Pop();
            if(val != stackVal)
            {
                return false;
            }
            slow = slow.next;
        }

        return stack.Count==0;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string headStr, bool expected)
    {
        ListNode head = headStr.LeetcodeToListNode();
        bool actual = new Solution().IsPalindrome(head);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[1,2,2,1]", true); }
    [TestMethod] public void Test2() { TestBase("[1,2]", false); }
    [TestMethod] public void Test3() { TestBase("[1,2,3,2,1]", true); }
    [TestMethod] public void Test4() { TestBase("[1,2,3,2]", false); }
    [TestMethod] public void Test5() { TestBase("[1]", true); }
    [TestMethod] public void Test6() { TestBase("[1,1]", true); }
    [TestMethod] public void Test7() { TestBase("[1,2,1]", true); }
    [TestMethod] public void Test8() { TestBase("[1,1,2]", false); }
}