namespace LeetcodeTest;

public static class Helper
{
    public static int[][] Convert2D(string s)
    {
        if (s == "[]")
        {
            return new int[][] { };
        }

        //string t = s.Replace("[[", "").Replace("]]", "");
        string[] list = s.Split("],[");
        int[][] result = new int[list.Length][];
        for (int i = 0; i < list.Length; i++)
        {
            int[] arr = Convert1D(list[i]);
            result[i] = arr;
        }
        return result;
    }

    public static int[] Convert1D(string s)
    {
        if (s == "[]")
        {
            return new int[] { };
        }

        string t = s.Replace("[", "").Replace("]", "");
        string[] list = t.Split(',', StringSplitOptions.RemoveEmptyEntries);
        int[] result = new int[list.Length];
        for (int i = 0; i < list.Length; i++)
        {
            result[i] = int.Parse(list[i]);
        }
        return result;
    }

    //public static void Print2D<T>(T[][] matrix)
    //{
    //    for (int y = 0; y < matrix.Length; y++)
    //    {
    //        string p = string.Empty;
    //        for (int x = 0; x < matrix[y].Length; x++)
    //        {
    //            p += $"{matrix[y][x]}, ";
    //        }
    //        Console.WriteLine(p);
    //    }
    //}

    public static void Print2D<T>(IList<IList<T>> matrix)
    {
        for (int y = 0; y < matrix.Count; y++)
        {
            string p = string.Empty;
            for (int x = 0; x < matrix[y].Count; x++)
            {
                p += $"{matrix[y][x]},";
            }
            p = p.Trim(' ',',');
            p = "[" + p + "]";
            Console.WriteLine(p);
        }
    }

    public static void Print1D(int[] nums)
    {
        string p = string.Empty;
        for (int i = 0; i < nums.Length; i++)
        {
            p += $"{nums[i]}, ";
        }
        Console.WriteLine(p);
    }

}

