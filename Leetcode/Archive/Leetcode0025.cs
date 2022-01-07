namespace Leetcode0025;

/// <summary>
/// Runtime: 88 ms, faster than 73.59% of C# online submissions for Reverse Nodes in k-Group.
/// Memory Usage: 40.2 MB, less than 8.52% of C# online submissions for Reverse Nodes in k-Group.
/// </summary>
public class Solution
{
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        if(k == 1) { return head; }
        if(head == null) { return head; }
        if(head.next == null) { return head; }
        ListNode prehead = new ListNode(-1);
        prehead.next = head;
        ListNode precurrent = prehead;
        ListNode current = head;
        List<ListNode> tempList = new List<ListNode>();
        
        while (current != null) {
            tempList.Add(current);

            if (tempList.Count == k)
            {
                ListNode temp = current.next;
                precurrent.next = tempList[k - 1];
                for(int i = k - 2; i >= 0; i--)
                {
                    tempList[i+1].next = tempList[i];
                }
                tempList[0].next = temp;
                precurrent = tempList[0];

                tempList.Clear();

                current = temp;
            }
            else
            {
                current = current.next;
            }

        }

        return prehead.next;
    }
}

[TestClass]
public class SolutionTests
{
    [DataRow(1, "[1,2,3,4,5]", 2, "[2,1,4,3,5]")]
    [DataRow(2, "[1,2,3,4,5]", 3, "[3,2,1,4,5]")]
    [DataRow(3, "[1,2,3,4,5]", 1, "[1,2,3,4,5]")]
    [DataRow(4, "[1]", 1, "[1]")]
    [DataRow(5, "[1,2]", 2, "[2,1]")]
    [DataRow(6, "[1,2,3]", 2, "[2,1,3]")]
    [DataTestMethod]
    public void Test(int order, string headStr,int k, string expected)
    {
        ListNode head = headStr.ToListNode();
        ListNode actual = new Solution().ReverseKGroup(head, k);
        Assert.AreEqual(expected, actual.ToStr());
    }
}
