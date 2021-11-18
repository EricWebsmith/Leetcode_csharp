namespace LeetcodeTest0141;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x)
    {
        val = x;
        next = null;
    }
}

public class Solution
{
    public bool HasCycle0(ListNode head)
    {
        HashSet<ListNode> list = new HashSet<ListNode>();
        while (head != null)
        {
            if (list.Contains(head))
            {
                return true;
            }
            list.Add(head);
            head = head.next;
        }
        return false;
    }

    public bool HasCycle(ListNode head)
    {
        if(head == null)
        {
            return false;
        }
        ListNode fast = head;
        ListNode slow = head;

        while (slow != null)
        {
            if(fast.next != null)
            {
                fast = fast.next.next;
            }
            else
            {
                return false;
            }

            if(fast == null)
            {
                return false;
            }

            slow = slow.next;
            if(slow == fast)
            {
                return true;
            }
        }

        return true;
    }
}