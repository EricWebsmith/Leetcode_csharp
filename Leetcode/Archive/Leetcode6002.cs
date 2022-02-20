using System.Collections;

namespace Leetcode6002;


public class Bitset
{
    int n = 0;
    BitArray list = new BitArray(0);
    int ones = 0;

    public Bitset(int size)
    {
        n = size;
        list = new BitArray(n);
    }

    public void Fix(int idx)
    {
        if(list.Get(idx))
        {
            return;
        }
        ones++;
        list.Set(idx, true);
    }

    public void Unfix(int idx)
    {
        if (!list.Get(idx))
        {
            return;
        }
        list.Set(idx, false);
        ones--;
    }

    public void Flip()
    {
        list.Not();
        ones = n - ones;
    }

    public bool All()
    {
        return ones == n;
    }

    public bool One()
    {
        return ones > 0;
    }

    public int Count()
    {
        return ones;
    }

    public string ToString()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            if (list[i])
            {
                sb.Append('1');
            }
            else
            {
                sb.Append('0');
            }
        }
        return sb.ToString();
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