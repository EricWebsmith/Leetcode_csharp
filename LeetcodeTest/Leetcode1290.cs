namespace Leetcode1290;

/// <summary>
/// Runtime: 76 ms, faster than 92.54% of C# online submissions for Convert Binary Number in a Linked List to Integer.
/// Memory Usage: 37.4 MB, less than 27.36% of C# online submissions for Convert Binary Number in a Linked List to Integer.
/// https://leetcode.com/submissions/detail/598340449/
/// </summary>
public class Solution
{
    public int GetDecimalValue(ListNode head)
    {
        int ans = 0;
        ListNode current = head;
        while (current != null)
        {
            ans = (ans << 1) + current.val;
            current = current.next;
        }
        return ans;
    }
}