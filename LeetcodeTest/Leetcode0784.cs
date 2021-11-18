namespace Leetcode0784;

public class Solution
{
    
    private List<char> Copy(List<char> oldList)
    {
        List<char> newList = new List<char>();
        foreach(char c in oldList)
        {
            newList.Add(c);
        }
        return newList;
    }

    public IList<string> LetterCasePermutation(string s)
    {
        List<List<char>> results = new List<List<char>>();
        results.Add(new List<char>());
        foreach (char c in s)
        {


            if (c>='0' && c<='9')
            {
                foreach (List<char> iList in results)
                {
                    iList.Add(c);
                }
            }
            else
            {
                char lowerChar = Char.ToLower(c);
                char upperChar = Char.ToUpper(c);
                int count = results.Count;
                for (int i=0;i< count; i++)
                {
                    List<char> iList = results[i];
                    // copy a list and put the upper case at the end.
                    List<char> upperList = Copy(iList);
                    upperList.Add(upperChar);
                    results.Add(upperList);
                    //append the small case char to the end of existing lists
                    iList.Add(lowerChar);
                }

            }
        }

        List<string> finalResults = new List<string>();
        foreach(var list in results)
        {
            finalResults.Add(String.Join(null, list.ToArray()));
        }

        return finalResults;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(string s, int expected)
    {
        Solution solution = new Solution();
        IList<string> actual = solution.LetterCasePermutation(s);
        Assert.AreEqual(expected, actual.Count);
    }

    [TestMethod] public void Test1() { TestBase("a1b2", 4); }
    [TestMethod] public void Test2() { TestBase("3z4",2); }
    [TestMethod] public void Test3() { TestBase("leetcode", 256); }
    [TestMethod] public void Test4() { TestBase("1314", 1); }
    [TestMethod] public void Test5() { TestBase("C", 2); }


}
