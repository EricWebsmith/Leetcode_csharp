namespace Leetcode0946;


public class Solution
{
    public bool ValidateStackSequences(int[] pushed, int[] popped)
    {
        int n = pushed.Length;
        Stack<int> stack = new Stack<int>();
        int pushIndex = 0;
        int popIndex = 0;
        //push
        while(pushIndex < popped.Length)
        {
            if(pushed[pushIndex] == popped[popIndex])
            {
                pushIndex++;
                popIndex++;
            }
            else if(stack.Count>0 && stack.Peek() == popped[popIndex])
            {
                stack.Pop();
                popIndex++;
            } 
            else
            {
                stack.Push(pushed[pushIndex]);
                pushIndex++;
            }
        }

        //pop
        for(; popIndex < n; popIndex++)
        {
            if(stack.Peek() == popped[popIndex])
            {
                stack.Pop();
            }
            else
            {
                return false;
            }
        }

        return true;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string pushedStr, string poppedStr, bool expected)
    {
        int[] pushed = pushedStr.LeetcodeToArray();
        int[] popped = poppedStr.LeetcodeToArray();
        bool actual = new Solution().ValidateStackSequences(pushed, popped);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[1,2,3,4,5]", "[4,5,3,2,1]", true); }
    [TestMethod] public void Test2() { TestBase("[1,2,3,4,5]", "[4,3,5,1,2]", false); }
    [TestMethod] public void Test3() { TestBase("[1,2,3,4,5]", "[4,3,5,2,1]", true); }
    [TestMethod] public void Test4() { TestBase("[1]", "[1]", true); }
    [TestMethod] public void Test5() { TestBase("[1,2]", "[1,2]", true); }
    [TestMethod] public void Test6() { TestBase("[1,2]", "[2,1]", true); }
    [TestMethod] public void Test7() { TestBase("[2,1,0]", "[1,2,0]", true); }

    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}


/*
 Runtime: 88 ms, faster than 100.00% of C# online submissions for Validate Stack Sequences.
Memory Usage: 42.4 MB, less than 15.87% of C# online submissions for Validate Stack Sequences.
 */