namespace Leetcode6021;


public class Solution
{
    public long MaximumSubsequenceCount(string text, string pattern)
    {
        int n = text.Length;
        char a = pattern[0];
        char b = pattern[1];
        
        if(a == b)
        {
            long count = 0;
            for(int i = 0; i < n; i++)
            {
                if(a == text[i])
                {
                    count++;
                }
            }
            return count * (count + 1) / 2;
        }

        long aCount = 0;
        long bCount = 0;

        long ans = 0;

        for (int i = 0; i < n; i++)
        {
            if(b == text[i])
            {
                bCount++;
                ans += aCount;
            } 
            else if(a == text[i])
            {
                aCount++;
            }
        }

        if (aCount > bCount)
        {
            ans += aCount;
        }
        else
        {
            ans += bCount;
        }

        return ans;

    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string text, string pattern, int expected)
    {
        long actual = new Solution().MaximumSubsequenceCount(text, pattern);
        Assert.AreEqual(expected, actual);
    }

    string text1 = "vnedkpkkyxelxqptfwuzcjhqmwagvrglkeivowvbjdoyydnjrqrqejoyptzoklaxcjxbrrfmpdxckfjzahparhpanwqfjrpbslsyiwbldnpjqishlsuagevjmiyktgofvnyncizswldwnngnkifmaxbmospdeslxirofgqouaapfgltgqxdhurxljcepdpndqqgfwkfiqrwuwxfamciyweehktaegynfumwnhrgrhcluenpnoieqdivznrjljcotysnlylyswvdlkgsvrotavnkifwmnvgagjykxgwaimavqsxuitknmbxppgzfwtjdvegapcplreokicxcsbdrsyfpustpxxssnouifkypwqrywprjlyddrggkcglbgcrbihgpxxosmejchmzkydhquevpschkpyulqxgduqkqgwnsowxrmgqbmltrltzqmmpjilpfxocflpkwithsjlljxdygfvstvwqsyxlkknmgpppupgjvfgmxnwmvrfuwcrsadomyddazlonjyjdeswwznkaeaasyvurpgyvjsiltiykwquesfjmuswjlrphsdthmuqkrhynmqnfqdlwnwesdmiiqvcpingbcgcsvqmsmskesrajqwmgtdoktreqssutpudfykriqhblntfabspbeddpdkownehqszbmddizdgtqmobirwbopmoqzwydnpqnvkwadajbecmajilzkfwjnpfyamudpppuxhlcngkign";
    string pattern1 = "rr";

    [TestMethod] public void Test1() { TestBase(text1, pattern1, 496); }
    [TestMethod] public void Test2() { TestBase("abdcdbc", "ac",4); }
    [TestMethod] public void Test3() { TestBase("aabb", "ab", 6); }
    [TestMethod] public void Test4() { TestBase("aaaaaa", "aa", 21); }

}