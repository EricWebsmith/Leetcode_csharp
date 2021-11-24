namespace Leetcode0376;

/// <summary>
/// We just need to count the tops.
/// A top is a point greater than its two neighbors.
/// 
/// And we need to delete continuous numbers with the same value.
/// </summary>
public class Solution
{
    public int WiggleMaxLength(int[] nums)
    {


        List<int> numList = nums.ToList();
        List<int> blockList = new List<int>();
        for (int i = numList.Count - 1; i >0; i--)
        {
            if(numList[i] == numList[i - 1])
            {
                blockList.Add(i);
            }
        }

        foreach(int blockIndex in blockList)
        {
            numList.RemoveAt(blockIndex);
        }

        if(numList.Count == 1)
        {
            return 1;
        }

        int result = 0;
        for(int i = 1; i<numList.Count-1; i++)
        {
            if (numList[i] > numList[i + 1])
            {
                if(numList[i]>numList[i-1])
                {
                    result++;
                }

                i++;
            }
        }

        result = result * 2 + 1;
        if (numList[0] > numList[1])
        {
            result++;
        }

        if(numList[numList.Count-1]> numList[numList.Count - 2])
        {
            result++;
        }
        
        return result;

    }
}

[TestClass]
public class MyTestClass
{
    [DataRow(1, "1,7,4,9,2,5", 6)]
    [DataRow(2, "1,17,5,10,13,15,10,5,16,8", 7)]
    [DataRow(3, "1", 1)]
    [DataRow(4, "1000", 1)]
    [DataRow(5, "1,1000,1", 3)]
    [DataRow(6, "1000,100,10,1,10,100,1000", 3)]
    [DataRow(7, "1,10,100,1000,100,10,1", 3)]
    [DataRow(8, "0,0", 1)]
    [DataRow(8, "1,0,0,1", 3)]
    [DataTestMethod]
    public void MyTestMethod(int order, string numsStr, int expected)
    {
        int[] nums = Helper.Convert1D(numsStr);
        int actual = (new Solution()).WiggleMaxLength(nums);
        Assert.AreEqual(expected, actual);
    }
}