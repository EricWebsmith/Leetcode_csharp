namespace Leetcode01836;

public class Solution
{
    public ListNode DeleteDuplicatesUnsorted(ListNode head)
    {
        ListNode prehead = new ListNode();
        prehead.next = head;
        HashSet<int> allSet = new HashSet<int>();
        HashSet<int> duplicates = new HashSet<int>();

        ListNode current = head;
        while (current != null)
        {
            if (allSet.Contains(current.val))
            {
                duplicates.Add(current.val);
            }
            allSet.Add(current.val);

            current = current.next;
        }

        current = prehead;
        while(current.next != null)
        {
            if(duplicates.Contains(current.next.val))
            {
                current.next = current.next.next;
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
    private void TestBase(string headStr, string expected)
    {
        ListNode head = headStr.LeetcodeToListNode();
        ListNode actual = new Solution().DeleteDuplicatesUnsorted(head);
        Assert.AreEqual(expected, actual.ToLeetcode());
    }

    [TestMethod] public void Test1() { TestBase("[1,2,3,2]", "[1,3]"); }
    [TestMethod] public void Test2() { TestBase("[2,1,1,2]", "[]"); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}

/*
Runtime: 386 ms, faster than 85.00% of C# online submissions for Remove Duplicates From an Unsorted Linked List.
Memory Usage: 52.1 MB, less than 95.00% of C# online submissions for Remove Duplicates From an Unsorted Linked List. 
 */