namespace Leetcode0316;


public class Solution
{
    public string RemoveDuplicateLetters(string s)
    {
        int n = s.Length;
        Dictionary<char, int> lookup = new Dictionary<char, int>();
        for(int i = 0; i < n; i++)
        {
            lookup[s[i]] = i;
        }

        List<char> stack = new List<char>();
        HashSet<char> seen = new HashSet<char>();

        for(int i = 0;i < n; i++)
        {
            if(seen.Contains(s[i]))
            {
                continue;
            }

            while(stack.Count>0 && stack.Last() > s[i] && lookup[stack[stack.Count - 1]] > i)
            {
                seen.Remove(stack.Last());
                stack.RemoveAt(stack.Count-1);
            }

            stack.Add(s[i]);
            seen.Add(s[i]);
        }

        return new String(stack.ToArray());
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