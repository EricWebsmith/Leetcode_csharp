namespace Leetcode5952;


public class Solution
{
    public int CountPoints(string rings)
    {
        Dictionary<char, int> colorDict = new Dictionary<char, int>();
        colorDict.Add('R', 1);
        colorDict.Add('G', 2);
        colorDict.Add('B', 4);
        int[] colors = new int[10];
        for (int i = 0; i < rings.Length/2; i++)
        {
            char color = rings[i * 2];
            int position = (rings[i * 2 + 1] - '0');
            colors[position] |= colorDict[color];
        }

        int ans = 0;
        for(int i = 0;i < colors.Length; i++)
        {
            if(colors[i] == 7)
            {
                ans++;
            }
        }

        return ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase()
    {
        // r 1, g 2, b 4

    }

    [TestMethod] public void Test1() { TestBase(); }
    [TestMethod] public void Test2() { TestBase(); }
    [TestMethod] public void Test3() { TestBase(); }
    [TestMethod] public void Test4() { TestBase(); }
}