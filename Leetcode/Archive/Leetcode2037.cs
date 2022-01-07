namespace Leetcode2037;

public class Solution
{
    public int MinMovesToSeat(int[] seats, int[] students)
    {
        Array.Sort(seats);
        Array.Sort(students);

        int result = 0;
        for (int i = 0; i < seats.Length; i++)
        {
            result+=(Math.Abs(students[i] - seats[i]));
        }

        return result;
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, new int[] { 3, 1, 5 }, new int[] { 2, 7, 4 }, 4)]
    [DataRow(2, new int[] { 4, 1, 5, 9 }, new int[] { 1, 3, 2, 6 }, 7)]
    [DataRow(3, new int[] { 2, 2, 6, 6 }, new int[] { 1, 3, 2, 6 }, 4)]
    [DataRow(4, new int[] { 2 }, new int[] { 1 }, 1)]
    [DataTestMethod]
    public void Test(int order, int[] seats, int[] students, int expected)
    {
        int actual = (new Solution()).MinMovesToSeat(seats, students);
        Assert.AreEqual(expected, actual);
    }
}