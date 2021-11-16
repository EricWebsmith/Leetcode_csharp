using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode0077;

public class Solution
{
    
    private IList<int> Copy(IList<int> oldList)
    {
        List<int> newList = new List<int>();
        foreach(int v in oldList)
        {
            newList.Add(v);
        }
        return newList;
    }

    public IList<IList<int>> Combine(int n, int k)
    {

        if (k == 1)
        {
            IList<IList<int>> results = new List<IList<int>>();
            for (int i = 1; i <= n; i++)
            {
                List<int> list = new List<int>();
                list.Add(i);
                results.Add(list);
            }
            return results;
        }
        else
        {
            IList<IList<int>> previousResults = Combine(n - 1, k-1);
            IList<IList<int>> results = new List<IList<int>>();
            foreach (IList<int> arr in previousResults)
            {
                int max = arr.Last();
                for(int i = max+1; i <= n; i++)
                {
                    IList<int> newArr = Copy(arr);
                    newArr.Add(i);
                    results.Add((IList<int>)newArr);
                }
            }
            return results;
        }
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int n, int k, int expected)
    {
        Solution solution = new Solution();
        IList<IList<int>> actual = solution.Combine(n, k);
        Assert.AreEqual(expected, actual.Count);
    }

    [TestMethod] public void Test1() { TestBase(4, 2, 6); }
    [TestMethod] public void Test2() { TestBase(1, 1, 1); }
    [TestMethod] public void Test3() { TestBase(3, 2, 3); }
    [TestMethod] public void Test4() { TestBase(5, 5, 1); }


}
