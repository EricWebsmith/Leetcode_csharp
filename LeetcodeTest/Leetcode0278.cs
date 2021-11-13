using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leetcode0278;

public class VersionControl
{
    public int Bad { get; private set; }
    public int N { get; private set; }
    public VersionControl(int n, int bad)
    {
        N = n;
        Bad = bad;
    }
    public bool IsBadVersion(int version) { return version >= Bad; }
}

public class Solution : VersionControl
{
    public Solution(int n, int bad) : base(n, bad) { }

    public int FirstBadVersion(int n)
    {
        int mid = n / 2;
        long lo = 1;
        long hi = n;
        while (lo <= hi)
        {
            if (!this.IsBadVersion(mid - 1) && this.IsBadVersion(mid))
            {
                return mid;
            }
            else if (this.IsBadVersion(mid))
            {
                hi = mid - 1;
            }
            else
            {
                lo = mid + 1;

            }

            mid = (int)((lo + hi) / 2);
        }

        return mid;
    }
}


[TestClass]
public class Leetcode0278
{
    [TestMethod]
    public void Test1()
    {
        Solution solution = new Solution(5, 4);
        int result = solution.FirstBadVersion(5);
        Assert.AreEqual(4, result);
    }

    [TestMethod]
    public void Test2()
    {
        Solution solution = new Solution(1, 1);
        int result = solution.FirstBadVersion(1);
        Assert.AreEqual(1, result);
    }


    [TestMethod]
    public void Test3()
    {
        Solution solution = new Solution(2126753390, 1702766719);
        int result = solution.FirstBadVersion(2126753390);
        Assert.AreEqual(1702766719, result);
    }
}
