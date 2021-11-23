namespace Leetcode0952;

public class Solution
{
    int[] parents;
    private int Find(int x)
    {
        if(parents[x] == x)
        {
            return x;
        }
        parents[x] = Find(parents[x]);
        return parents[x];
    }

    private void Union(int small, int big)
    {
        int ps = Find(small);
        int pb = Find(big);   
        if(ps != pb)
        {
            parents[pb] = ps;
        }
    }

    public int LargestComponentSize(int[] nums)
    {

        parents = new int[nums.Max() + 1];
        for(int i = 0; i < parents.Length; i++)
        {
            parents[i] = i;
        }

        foreach(int num in nums)
        {
            for (int i = 2; i < 1+(int)(Math.Pow(num, 0.5)); i++)
            {
                if(num % i == 0)
                {
                    Union(i, num);
                    Union(num / i, num);
                }
            }
        }

        Dictionary<int, int> map = new Dictionary<int, int>();
        foreach(int num in nums)
        {
            int p = Find(num);
            if (map.ContainsKey(p))
            {
                map[p]++;
            }
            else
            {
                map[p] = 1;
            }
        }

        return map.Values.Max();

    }
}

[TestClass]
public class MyTestClass
{


    [DataRow(1, "4,6,15,35", 4)]
    [DataRow(2, "20,50,9,63", 2)]
    [DataRow(3, "2,3,6,7,4,12,21,39", 8)]
    [DataRow(4, "79, 2,3,6,7,4,12,21,39", 8)]
    [DataRow(5, "2, 4, 8, 16, 3, 9, 81, 243, 729", 5)]
    [DataRow(6, "1", 1)]
    [DataTestMethod]
    public void Test(int order, string numsStr, int expected)
    {
        int[] nums = Helper.Convert1D(numsStr);
        int actual = (new Solution()).LargestComponentSize(nums);
        Assert.AreEqual(expected, actual);
    }

    [DataRow(10, 8)]
    [DataRow(100, 89)]
    [DataRow(1000)]
    [DataRow(10000)]
    [DataRow(100000)]
    [TestMethod]
    public void Test_1_to_n(int n, int expected = -1)
    {
        int[] nums = new int[n];
        for (int i = 0; i < n; i++)
        {
            nums[i] = i + 1;
        }

        int actual = (new Solution()).LargestComponentSize(nums);
        if (expected > 0)
        {
            Assert.AreEqual(expected, actual);
        }

        Console.WriteLine(actual);
    }

    [DataRow(10, 8)]
    [DataRow(100, 89)]
    [DataRow(1000)]
    [DataRow(10000)]
    [DataRow(100000)]
    [TestMethod]
    public void Test_n_to_1(int n, int expected = -1)
    {
        int[] nums = new int[n];
        for (int i = 0; i < n; i++)
        {
            nums[i] = n - i;
        }

        int actual = (new Solution()).LargestComponentSize(nums);
        if (expected > 0)
        {
            Assert.AreEqual(expected, actual);
        }

        Console.WriteLine(actual);
    }


    [TestMethod]
    public void Test_10000()
    {
        int n = 100000;
        int[] nums = new int[n];
        for (int i = 0; i < n; i++)
        {
            nums[i] = i + 1;
        }

        for(int i = 0; i < 2;i++)
        {
            int actual = (new Solution()).LargestComponentSize(nums);
            Console.WriteLine(actual);
        }
        
    }
}