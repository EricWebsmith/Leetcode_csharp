namespace Leetcode5935;

// https://leetcode.com/contest/biweekly-contest-67/problems/find-good-days-to-rob-the-bank/

public class Solution
{
    public IList<int> GoodDaysToRobBank(int[] security, int time)
    {
        int n = security.Length;
        int[] decreasing = new int[n];
        for (int i = 1; i < n; i++)
        {
            if(security[i] <= security[i - 1])
            {
                decreasing[i] = decreasing[i - 1] + 1;
            }
        }

        int[] increasing = new int[n];
        for(int i = n-2; i >= 0; i--)
        {
            if(security[i] <= security[i +1])
            {
                increasing[i] = increasing[i+1] + 1;
            }
        }

        List<int> ans = new List<int>();
        for(int i = 0; i < n; i++)
        {
            if(decreasing[i]>=time && increasing[i] >= time)
            {
                ans.Add(i);
            }
        }

        return ans.ToArray();
    }
}

