namespace LeetcodeTest;

[DebuggerDisplay("{val}")]
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

public static class ListNodeHelper
{
    public static ListNode LeetcodeToListNode(this string numsStr)
    {
        int[] nums = numsStr.LeetcodeToArray();
        if (nums.Length == 0) { return null; }
        ListNode head = new ListNode();
        head.val = nums[0];
        ListNode pointer = head;

        for (int i = 1; i < nums.Length; i++)
        {
            ListNode newNode = new ListNode(nums[i]);
            pointer.next = newNode;
            pointer = newNode;
        }

        return head;
    }

    public static ListNode Get(this ListNode head, int n)
    {
        if(n == -1) { return null; }

        ListNode current = head;
        for (int i = 1; i <= n; i++)
        {
            current = current.next;
        }

        return current;
    }

    public static ListNode ToListNodeWithCircle(this string numsStr, int pos)
    {
        int[] nums = numsStr.LeetcodeToArray();
        if (nums.Length == 0) { return null; }
        ListNode head = new ListNode();
        head.val = nums[0];
        ListNode pointer = head;

        ListNode circlePos = null;
        if(pos == 0) { circlePos = head; }

        for (int i = 1; i < nums.Length; i++)
        {
            ListNode newNode = new ListNode(nums[i]);

            if (i == pos)
            {
                circlePos = newNode;
            }

            pointer.next = newNode;
            pointer = newNode;
        }

        pointer.next = circlePos;

        return head;
    }

    public static int CompareTo(this ListNode l1, ListNode l2)
    {
        ListNode pointer1 = l1;
        ListNode pointer2 = l2;
        while (pointer1 != null && pointer2 != null)
        {
            if (pointer1.val > pointer2.val)
            {
                return 1;
            }
            else if (pointer1.val < pointer2.val)
            {
                return -1;
            }

            pointer1 = pointer1.next;
            pointer2 = pointer2.next;
        }

        if (pointer1 == null && pointer2 == null)
        {
            return 0;
        }

        if (pointer1 == null)
        {
            return -1;
        }

        if (pointer2 == null)
        {
            return 1;
        }

        return 0;
    }

    public static string ToLeetcode(this ListNode node)
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append('[');
        while (node != null)
        {
            stringBuilder.Append(node.val);
            if (node.next != null)
            {
                stringBuilder.Append(",");
            }
            node = node.next;
        }

        stringBuilder.Append(']');
        return stringBuilder.ToString();
    }
}

