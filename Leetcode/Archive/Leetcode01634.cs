namespace Leetcode01634;

public class PolyNode
{
    public int coefficient, power;
    public PolyNode next;

    public PolyNode(int coefficient = 0, int power = 0, PolyNode next = null)
    {
        this.coefficient = coefficient;
        this.power = power;
        this.next = next;
    }
}


public class Solution
{
    int GetNextPower(PolyNode current1, PolyNode current2)
    {
        if(current1 == null && current2 == null)
        {
            return -1;
        }
        if(current1 == null)
        {
            return current2.power;
        }
        if(current2 == null)
        {
            return current1.power;
        }

        return Math.Max(current1.power, current2.power);
    }

    public PolyNode AddPoly(PolyNode poly1, PolyNode poly2)
    {
        if (poly1 == null) { return poly2; }
        if (poly2 == null) { return poly1; }
        Dictionary<int, int> dict = new Dictionary<int, int>();
        PolyNode current1 = poly1;
        PolyNode current2 = poly2;
        int power = Math.Max(current1.power, current2.power);
        while(power > -1)
        {
            int currentEfficient = 0;
            if (current1!=null && current1.power == power)
            {
                currentEfficient += current1.coefficient;
                current1 = current1.next;
            }

            if (current2!=null && current2.power == power)
            {
                currentEfficient += current2.coefficient;
                current2 = current2.next;
            }
            dict.Add(power, currentEfficient);

            power = GetNextPower(current1, current2);
        }

        PolyNode head = new PolyNode();
        PolyNode curor = head;
        foreach(KeyValuePair<int, int> kv in dict)
        {
            if (kv.Value == 0)
            {
                continue;
            }

            curor.next = new PolyNode(kv.Value, kv.Key);
            curor = curor.next;
        }

        return head.next;
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
Runtime: 235 ms, faster than 94.59% of C# online submissions for Add Two Polynomials Represented as Linked Lists.
Memory Usage: 62 MB, less than 5.41% of C# online submissions for Add Two Polynomials Represented as Linked Lists.
 */