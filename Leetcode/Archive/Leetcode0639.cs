namespace Leetcode0639;

public class Solution
{
    private int OneStep(string s, int start)
    {
        if (s[start] == '*')
        {
            return 9;
        }
        return s[start] != '0' ? 1 : 0;
    }

    private int TwoSteps(string s, int start)
    {
        if (s[start] == '0')
        {
            return 0;
        }

        if (s[start] == '*')
        {
            if (s[start + 1] == '*')
            {
                return 15;
            }

            if (s[start + 1] > '6')
            {
                return 1;
            }
            return 2;
        }

        if (s[start] == '1')
        {
            if (s[start + 1] == '*')
            {
                return 9;
            }
            return 1;
        }

        if (s[start] == '2')
        {
            if (s[start + 1] == '*')
            {
                return 6;
            }

            if (s[start + 1] > '6')
            {
                return 0;
            }
            return 1;
        }

        return 0;
    }

    public int NumDecodings(string s)
    {
        //if (s[0] == '0')
        //{
        //    return 0;
        //}

        if (s.Length == 1)
        {
            return OneStep(s, 0);
        }

        long a = 1;
        long b = OneStep(s, 0);
        long c = 0;

        for (int i = 2; i <= s.Length; i++)
        {
            c = a * TwoSteps(s, i - 2) + b * OneStep(s, i - 1);
            c = c % 1000000007;
            a = b;
            b = c;
            
        }
        return (int)(c % 1000000007);
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(string s, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.NumDecodings(s);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test01() { TestBase("*", 9); }
    [TestMethod] public void Test02() { TestBase("1*", 18); }
    [TestMethod] public void Test03() { TestBase("2*", 15); }

    [TestMethod] public void Test04() { TestBase("10", 1); }
    [TestMethod] public void Test05() { TestBase("20", 1); }
    [TestMethod] public void Test06() { TestBase("100", 0); }
    [TestMethod] public void Test07() { TestBase("1", 1); }

    [TestMethod] public void Test08() { TestBase("27", 1); }
    [TestMethod] public void Test09() { TestBase("228", 2); }
    [TestMethod] public void Test10() { TestBase("611", 2); }
    [TestMethod] public void Test11() { TestBase("12", 2); }
    [TestMethod] public void Test12() { TestBase("226", 3); }
    [TestMethod] public void Test13() { TestBase("0", 0); }
    [TestMethod] public void Test14() { TestBase("**", 96); }
    [TestMethod] public void Test15_long() { TestBase("7*9*3*6*3*0*5*4*9*7*3*7*1*8*3*2*0*0*6*", 196465252); }
    [TestMethod] public void Test16_3stars() { TestBase("***", 999); }
    [TestMethod] public void Test17_4stars() { TestBase("****", 10431); }
    [TestMethod] public void Test18_5stars() { TestBase("*****", 108864); }

    [TestMethod] public void Test19_6starts() { TestBase("******", 1136241); }
    [TestMethod] public void Test20_7starts() { TestBase("*******", 11859129); }
    [TestMethod] public void Test21_8starts() { TestBase("********", 123775776); }
    [TestMethod] public void Test22_9starts() { TestBase("*********", 291868912); }
    [TestMethod]
    public void Test23_very_long()
    {
        TestBase(
            "1*6*7*1*9*6*2*9*2*3*3*6*3*2*2*4*7*2*9*6*0*6*4*4*1*6*9*0*5*9*2*5*7*7*0*6*9*7*1*5*5*9*3*0*4*9*2*6*2*5*7*6*1*9*4*5*8*4*7*4*2*7*1*2*1*9*1*3*0*6*"
            , 1);
    }

}

/*
 
 "*"
"*********"
"7*9*3*6*3*0*5*4*9*7*3*7*1*8*3*2*0*0*6*"
"1*6*7*1*9*6*2*9*2*3*3*6*3*2*2*4*7*2*9*6*0*6*4*4*1*6*9*0*5*9*2*5*7*7*0*6*9*7*1*5*5*9*3*0*4*9*2*6*2*5*7*6*1*9*4*5*8*4*7*4*2*7*1*2*1*9*1*3*0*6*"
 */