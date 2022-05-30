namespace Leetcode00369;

public class Solution
{
    private int PlusOneInner(ListNode node)
    {
        if(node.next == null)
        {
            if (node.val == 9)
            {
                node.val = 0;
                return 1;
            } else
            {
                node.val ++;
            }
        } 
        else
        {
            int carry = PlusOneInner(node.next);
            if (carry == 0)
            {
                return 0;
            }
            else if(carry == 1 && node.val<9) 
            {
                node.val++;
                return 0;
            }
            else
            {
                node.val = 0;
                return 1;
            }
        }
        return 0;
    }

    public ListNode PlusOne(ListNode head)
    {
        int carry = PlusOneInner(head);
        if(carry == 1)
        {
            ListNode newHead = new ListNode(1);
            newHead.next = head;
            return newHead;
        }

        return head;
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(string headStr, string expected)
    {
        ListNode head = headStr.LeetcodeToListNode();
        ListNode actual = new Solution().PlusOne(head);
        Assert.AreEqual(expected, actual.ToLeetcode());
    }

    [TestMethod] public void Test1() { TestBase("[1,2,3]", "[1,2,4]"); }
    [TestMethod] public void Test2() { TestBase("[0]", "[1]"); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}

/*
 Runtime: 83 ms, faster than 96.08% of C# online submissions for Plus One Linked List.
Memory Usage: 38.1 MB, less than 19.61% of C# online submissions for Plus One Linked List.
 */