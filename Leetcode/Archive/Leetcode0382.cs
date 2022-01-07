namespace Leetcode0382;

///Runtime: 124 ms, faster than 91.46% of C# online submissions for Linked List Random Node.
///Memory Usage: 44.5 MB, less than 37.80% of C# online submissions for Linked List Random Node.
public class Solution {

    Random random = new Random();
    List<int> dp = new List<int>();
    public Solution(ListNode head) {
        ListNode cur = head;
        while(cur!=null){
            dp.Add(cur.val);
            cur = cur.next;
        }
    }
    
    public int GetRandom() {
        
        int index = random.Next(dp.Count);
        return dp[index];
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase()
    {

    }

    [TestMethod] public void Test1() { TestBase(); }
    [TestMethod] public void Test2() { TestBase(); }
    [TestMethod] public void Test3() { TestBase(); }
    [TestMethod] public void Test4() { TestBase(); }

}