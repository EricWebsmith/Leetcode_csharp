namespace Leetcode1041;

/// <summary>
/// Runtime: 80 ms, faster than 61.65% of C# online submissions for Robot Bounded In Circle.
/// Memory Usage: 37.5 MB, less than 16.92% of C# online submissions for Robot Bounded In Circle.
/// </summary>
public class Solution
{
    private void Act(char a)
    {
        switch (a)
        {
            case 'G':
                x = x + directions[directionIndex][0];
                y = y + directions[directionIndex][1];
                return;
            case 'L':
                directionIndex = (directionIndex + 4 - 1) % 4;
                return;
            case 'R':
                directionIndex = (directionIndex + 4 + 1) % 4;
                return;
        }
    }



    int[][] directions = new int[][]
    {
            new int[] {0, -1}, // north
            new int[] {1, 0}, // east
            new int[] {0, 1}, // south
            new int[] {-1, 0} //west
    };
    int directionIndex = 0;
    int x = 0;
    int y = 0;

    public bool IsRobotBounded(string instructions)
    {
        for(int i = 0; i < 4; i++)
        {
            foreach(char instruction in instructions)
            {
                Act(instruction);
            }
            if(x == 0 && y == 0)
            {
                return true;
            }
        }
        return false;
        
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(string instructions, bool expected)
    {
        bool actual =  new Solution().IsRobotBounded(instructions);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("GGLLGG", true); }
    [TestMethod] public void Test2() { TestBase("GG", false); }
    [TestMethod] public void Test3() { TestBase("GL", true); }
    //[TestMethod] public void Test4() { TestBase(); }

}