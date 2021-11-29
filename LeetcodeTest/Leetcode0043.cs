namespace Leetcode0043;

public class Solution
{
    public string Multiply(string num1, string num2)
    {
        Dictionary<char, int> convertor = new Dictionary<char, int>();
        convertor.Add('0', 0);
        convertor.Add('1', 1);
        convertor.Add('2', 2);
        convertor.Add('3', 3);
        convertor.Add('4', 4);
        convertor.Add('5', 5);
        convertor.Add('6', 6);
        convertor.Add('7', 7);
        convertor.Add('8', 8);
        convertor.Add('9', 9);

        Dictionary<int, char> reverseConvertor = new Dictionary<int, char>();
        reverseConvertor.Add(0, '0');
        reverseConvertor.Add(1, '1');
        reverseConvertor.Add(2, '2');
        reverseConvertor.Add(3, '3');
        reverseConvertor.Add(4, '4');
        reverseConvertor.Add(5, '5');
        reverseConvertor.Add(6, '6');
        reverseConvertor.Add(7, '7');
        reverseConvertor.Add(8, '8');
        reverseConvertor.Add(9, '9');


        int[] num1List = new int[num1.Length];
        for (int i = 0; i < num1.Length; i++)
        {
            num1List[i] = convertor[num1[num1.Length - 1 - i]];
        }

        int[] num2List = new int[num2.Length];
        for (int j = 0; j < num2.Length; j++)
        {
            num2List[j] = convertor[num2[num2.Length - 1 - j]];
        }

        int[] results = new int[num1.Length + num2.Length];
        for (int i = 0; i < num1List.Length; i++)
        {
            for (int j = 0; j < num2List.Length; j++)
            {
                results[i + j] += num1List[i] * num2List[j];
            }
        }

        // carry
        int remainder = 0;
        int shift = 0;
        for (int k = 0; k < results.Length; k++)
        {
            results[k] += shift;
            shift = results[k] / 10;
            results[k] = results[k] % 10;

        }

        // print
        bool start = false;
        List<char> chars = new List<char>();
        for (int k = results.Length - 1; k >= 0; k--)
        {
            if (results[k] > 0) { start = true; }
            if (start) { chars.Add(reverseConvertor[results[k]]); }
        }

        if (!start) { return "0"; }

        return string.Join(string.Empty, chars.ToArray());

    }
}

[TestClass]
public class Tests
{
    [DataRow(1, "2", "3", "6")]
    [DataRow(2, "123", "456", "56088")]
    [DataRow(3, "0", "456", "0")]
    [DataRow(4, "0", "0", "0")]
    [DataRow(5, "25", "0", "0")]
    [DataRow(6, "10", "10", "100")]
    [DataRow(7, "10", "10", "100")]
    [DataRow(8, "100", "100", "10000")]
    [DataRow(9, "1000000000000000000000000000000000000", 
        "1000000000000000000000000000000000000", 
        "1000000000000000000000000000000000000000000000000000000000000000000000000")]
    [DataTestMethod]
    public void Test(int order, string num1, string num2, string expected)
    {
        string actual = new Solution().Multiply(num1, num2);
        Assert.AreEqual(expected, actual);
    }
}