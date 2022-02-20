namespace Leetcode0023;


public class Solution
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        int n = lists.Length;
        ListNode prehead = new ListNode(-1);
        ListNode current = prehead;
        ListNode[] heads = lists.ToArray();

        while (true)
        {

            int headIndex = -1;
            int min = int.MaxValue;
            for(int i = 0;i<n;i++)
            {
                if(heads[i] == null)
                {
                    continue;
                }

                if (heads[i].val < min)
                {
                    headIndex = i;
                    min = heads[i].val;
                }
            }

            if(headIndex == -1)
            {
                break;
            }

            current.next = heads[headIndex];
            heads[headIndex] = heads[headIndex].next;
            current = current.next;
        }

        return prehead.next;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase()
    {

    }

    //[TestMethod] public void Test1() { TestBase(); }
    //[TestMethod] public void Test2() { TestBase(); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}