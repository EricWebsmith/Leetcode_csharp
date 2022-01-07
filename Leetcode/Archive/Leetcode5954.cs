namespace Leetcode5954;


public class Solution
{
    public int MinimumRefill(int[] plants, int capacityA, int capacityB)
    {
        int n = plants.Length;
        int aliceIndex = 0;
        int aliceWater = capacityA;
        int bobIndex = n - 1;
        int bobWater = capacityB;
        int refills  = 0;   
        while (aliceIndex <= bobIndex)
        {
            if(aliceIndex == bobIndex)
            {
                if(aliceWater >= plants[aliceIndex] || bobWater >= plants[bobIndex])
                {
                    break;
                }
                else
                {
                    refills++;
                    break;
                }
            }
            else
            {
                if(aliceWater< plants[aliceIndex])
                {
                    aliceWater = capacityA;
                    refills++;
                }
                if(bobWater< plants[bobIndex])
                {
                    bobWater = capacityB;
                    refills++;
                }
            }
            //alice
            if(aliceWater >= plants[aliceIndex])
            {
                aliceWater -= plants[aliceIndex];
                aliceIndex++;
            }

            //bob
            if (bobWater >= plants[bobIndex])
            {
                bobWater -= plants[bobIndex];
                bobIndex--;
            }

        }

        return refills;
    }
}





[TestClass]
public class SolutionTests
{
    private void TestBase(string plantsStr, int capacityA, int capacityB, int expected)
    {
        int[] plants = plantsStr.LeetcodeToArray();
        int actual = new Solution().MinimumRefill(plants, capacityA, capacityB);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[2,2,3,3]", 5, 5, 1); }
    [TestMethod] public void Test2() { TestBase("[2,2,3,3]", 3, 4, 2); }
    [TestMethod] public void Test3() { TestBase("[5]", 10, 8, 0); }
    [TestMethod] public void Test4() { TestBase("[1,2,4,4,5]", 6, 5, 2); }
    [TestMethod] public void Test5() { TestBase("[2,2,5,2,2]", 5, 5, 1); }
    [TestMethod] public void Test6() { TestBase("[2,1,1]", 2, 2, 0); }
    [TestMethod] public void Test7() { TestBase("[274,179,789,417,293,336,133,334,569,355,813,217,80,933,961,271,294,933,49,980,685,470,186,11,157,889,299,493,215,807,588,464,218,248,391,817,32,606,740,941,505,533,289,306,490]", 
        996, 1172, 23); }
}