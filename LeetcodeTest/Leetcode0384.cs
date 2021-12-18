namespace Leetcode0384;

public class Solution
{
    int[] origin;

    public Solution(int[] nums)
    {
        this.origin = nums;
    }

    public int[] Reset()
    {
        return origin;
    }

    public int[] Shuffle()
    {
        Random r = new Random();
        return origin.OrderBy(c=>r.Next()).ToArray();

    }
}