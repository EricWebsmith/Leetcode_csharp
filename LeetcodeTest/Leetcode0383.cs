namespace Leetcode0383;

public class Solution
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        if(ransomNote.Length > magazine.Length)
        {
            return false;
        }

        Dictionary<char, int> cache = new Dictionary<char, int>();


        int magazineIndex = 0;
        foreach(char r in ransomNote)
        {
            // first search cache.
            if (cache.ContainsKey(r) && cache[r] > 0)
            {
                cache[r]--;
                continue;
            }

            // then search magazine
            char m = magazine[magazineIndex];
            while(m != r && magazineIndex<magazine.Length)
            {
                // if m is not r
                // put m to cache.
                cache[m] = cache.ContainsKey(m) ? cache[m] + 1 : 1;
                magazineIndex++;
                if (magazineIndex == magazine.Length)
                {
                    return false;
                }
                m = magazine[magazineIndex];
            }

            magazineIndex++;
        }
        return true;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(string ransomNote, string magazine, bool expected)
    {
        Solution solution = new Solution();
        bool actual = solution.CanConstruct(ransomNote, magazine);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("a", "b", false); }
    [TestMethod] public void Test2() { TestBase("aa", "ab", false); }
    [TestMethod] public void Test3() { TestBase("aa", "aab", true); }
    [TestMethod] public void Test4() { TestBase("bhjdigif", "dbjdhdehgbcdjjgadeegdbegehjffie", false); }

}
