namespace Leetcode1217;

/// <summary>
/// Runtime: 80 ms, faster than 80.65% of C# online submissions for Minimum Cost to Move Chips to The Same Position.
/// Memory Usage: 37.1 MB, less than 38.71% of C# online submissions for Minimum Cost to Move Chips to The Same Position.
/// </summary>
public class Solution
{
    public int MinCostToMoveChips(int[] position)
    {
        int odd = 0;
        int even = 0;
        for (int i = 0; i < position.Length; i++)
        {
            if(position[i] % 2 == 0)
            {
                even++;
            }
            else
            {
                odd++;
            }

            
        }

        return Math.Min(odd, even);
    }
}


