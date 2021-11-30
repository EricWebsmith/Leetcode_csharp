namespace Leetcode0002;

/// <summary>
/// Runtime: 88 ms, faster than 93.17% of C# online submissions for Add Two Numbers.
/// Memory Usage: 41.1 MB, less than 40.25% of C# online submissions for Add Two Numbers.
/// </summary>
public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {

        ListNode l3 = new ListNode(-1);
        ListNode l3_head = l3;

        int carry = 0;
        while (l1 != null && l2 != null)
        {
            int val = l1.val + l2.val + carry;
            carry = val / 10;
            val = val % 10;

            ListNode newNode = new ListNode(val);

            l3.next = newNode;

            l1 = l1.next;
            l2 = l2.next;
            l3 = l3.next;
        }

        if (l1 == null && l2 == null)
        {

        }
        else if (l1 == null)
        {
            l3.next = l2;
        }
        else if (l2 == null)
        {
            l3.next = l1;
        }

        // deal with carry
        while (carry == 1)
        {
            if (l3.next == null)
            {
                ListNode last = new ListNode(1);
                l3.next = last;
                break;
            }
            else
            {
                l3 = l3.next;
                l3.val += carry;
                carry = l3.val / 10;
                l3.val = l3.val % 10;
            }
        }

        return l3_head.next;
    }
}

[TestClass]
public class SolutionTests
{
    [DataRow(1, "[2,4,3]", "[5,6,4]", "[7,0,8]")]
    [DataRow(2, "[0]", "[0]", "[0]")]
    [DataRow(3, "[9,9,9,9,9,9,9]", "[9,9,9,9]", "[8,9,9,9,0,0,0,1]")]
    [DataRow(4, "[5]", "[5]", "[0,1]")]
    [DataTestMethod]
    public void Test(int order, string l1Str, string l2Str, string expectedStr)
    {
        ListNode l1 = l1Str.ToListNode();
        ListNode l2 = l2Str.ToListNode();
        ListNode actual = new Solution().AddTwoNumbers(l1, l2);
        Assert.AreEqual(expectedStr, actual.ToStr());
    }
}