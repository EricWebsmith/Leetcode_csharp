namespace Leetcode1356;


public class Solution
{
    Dictionary<int, int> numberBitMap = new Dictionary<int, int>();

    private int Compare(int a, int b)
    {
        int bitCompare = numberBitMap[a] - numberBitMap[b];
        if (bitCompare != 0)
        {
            return bitCompare;  
        }

        return a - b;
    }

    private int CountBits(int a)
    {
        int count = 0;
        while(a != 0)
        {
            count++;
            a &= a - 1;
        }
        return count;
    }

    public int[] SortByBits(int[] arr)
    {
        int n = arr.Length;
        for(int i = 0; i < n; i++)
        {
            numberBitMap[arr[i]] = CountBits(arr[i]);
        }

        Array.Sort(arr, Compare);
        return arr;
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


/*
Runtime: 136 ms, faster than 97.96% of C# online submissions for Sort Integers by The Number of 1 Bits.
Memory Usage: 44.6 MB, less than 28.57% of C# online submissions for Sort Integers by The Number of 1 Bits. 
 */