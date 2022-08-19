namespace Leetcode;

public static class ArrayHelper
{
    public static char[][] LeetcodeToCharArray2D(this string s)
    {
        if (s == "[]")
        {
            return new char[][] { };
        }

        s = s.Replace(",", "");

        string[] list = s.Split("][");
        char[][] result = new char[list.Length][];
        for (int i = 0; i < list.Length; i++)
        {
            char[] arr = LeetcodeToCharArray(list[i]);
            result[i] = arr;
        }
        return result;
    }

    public static char[] LeetcodeToCharArray(this string s)
    {
        if (s == "[]")
        {
            return new char[] { };
        }

        string t = s.Replace("[", "").Replace("]", "").Replace("\"", "").Replace("'", "").Replace(",", "");

        return t.ToArray();
    }

    public static int[][] LeetcodeToArray2D(this string s)
    {
        string t = s;
        t = t.Replace(" ", "");
        t = t.Replace("\r", "");
        t = t.Replace("\n", "");
        if (t == "[]")
        {
            return new int[][] { };
        }

        string[] list = t.Split("],[");
        int[][] result = new int[list.Length][];
        for (int i = 0; i < list.Length; i++)
        {
            int[] arr = LeetcodeToArray(list[i]);
            result[i] = arr;
        }
        return result;
    }

    private static int[] LeetcodeToArray3Dots(this string s)
    {
        string[] arr = s.Split("...");
        int start = int.Parse(arr[0]);
        int end = int.Parse(arr[1]);
        int step = start < end ? 1 : -1;
        int n = Math.Abs(end - start) + 1;
        int[] intArr = new int[n];
        for (int i = 0; i < n; i++)
        {
            intArr[i] = start + step * i;
        }
        return intArr;
    }

    public static int[] LeetcodeToArray(this string s)
    {
        if (s == "[]")
        {
            return new int[] { };
        }

        string t = s.Replace("[", "").Replace("]", "");

        //
        if (t.Contains("..."))
        {
            return LeetcodeToArray3Dots(t);
        }
        //
        string[] list = t.Split(',', StringSplitOptions.RemoveEmptyEntries);
        int[] result = new int[list.Length];
        for (int i = 0; i < list.Length; i++)
        {
            result[i] = int.Parse(list[i]);
        }
        return result;
    }

    public static double[] LeetcodeToDoubleArray(this string s)
    {
        if (s == "[]")
        {
            return new double[] { };
        }

        string t = s.Replace("[", "").Replace("]", "");

        //
        //if (t.Contains("..."))
        //{
        //    return LeetcodeToArray3Dots(t);
        //}
        //
        string[] list = t.Split(',', StringSplitOptions.RemoveEmptyEntries);
        double[] result = new double[list.Length];
        for (int i = 0; i < list.Length; i++)
        {
            result[i] = double.Parse(list[i]);
        }
        return result;
    }

    public static string ToLeetcode(this IList<int> arr)
    {
        if (arr == null)
        {
            return "[]";
        }

        string s = string.Empty;
        for (int i = 0; i < arr.Count; i++)
        {
            s += $"{arr[i]},";
        }
        s = s.Trim(' ', ',');
        s = "[" + s + "]";
        return s;
    }

    public static string ToLeetcode(this IList<long> arr)
    {
        if (arr == null)
        {
            return "[]";
        }

        string s = string.Empty;
        for (int i = 0; i < arr.Count; i++)
        {
            s += $"{arr[i]},";
        }
        s = s.Trim(' ', ',');
        s = "[" + s + "]";
        return s;
    }


    public static string ToLeetcode(this IList<IList<int>> arr)
    {
        if (arr == null)
        {
            return "[]";
        }

        string s = string.Empty;
        for (int i = 0; i < arr.Count; i++)
        {
            s += $"{ToLeetcode(arr[i])},";
        }
        s = s.Trim(' ', ',');
        s = "[" + s + "]";
        return s;
    }

    /// <summary>
    /// This replace false and true to 0 and 1.
    /// </summary>
    /// <param name="matrix"></param>
    public static void Print2D(this IList<IList<bool>> matrix)
    {
        Console.WriteLine("-----Print 2D------");
        for (int y = 0; y < matrix.Count; y++)
        {
            string p = string.Empty;
            for (int x = 0; x < matrix[y].Count; x++)
            {
                if (matrix[y][x])
                {
                    p += "1,";
                }
                else
                {
                    p += "0,";
                }
                
            }
            p = p.Trim(' ', ',');
            p = "[" + p + "]";
            Console.WriteLine(p);
        }
    }

    public static void Print2D<T>(this IList<IList<T>> matrix)
    {
        Console.WriteLine("-----Print 2D------");
        for (int y = 0; y < matrix.Count; y++)
        {
            string p = string.Empty;
            for (int x = 0; x < matrix[y].Count; x++)
            {
                p += $"{matrix[y][x]},";
            }
            p = p.Trim(' ', ',');
            p = "[" + p + "]";
            Console.WriteLine(p);
        }
    }

    public static void PrintListOfArray<T>(this IList<T[]> matrix)
    {
        for (int y = 0; y < matrix.Count; y++)
        {
            string p = string.Empty;
            for (int x = 0; x < matrix[y].Length; x++)
            {
                p += $"{matrix[y][x]},";
            }
            p = p.Trim(' ', ',');
            p = "[" + p + "]";
            Console.WriteLine(p);
        }
    }

    public static void Print1D<T>(this IList<T> nums)
    {
        string p = string.Empty;
        for (int i = 0; i < nums.Count; i++)
        {
            p += $"{nums[i]}, ";
        }
        Console.WriteLine(p);
    }

    public static string[] LeetcodeToStringArray(this string s)
    {
        string t = s.Replace("[", "").Replace("]", "");
        string[] arr = t.Split(',');
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = arr[i].Trim('"');
        }
        return arr;
    }

    public static string[][] LeetcodeToStringArray2D(this string s)
    {
        if (s == "[]")
        {
            return new string[][] { };
        }

        string[] list = s.Split("],[");
        string[][] result = new string[list.Length][];
        for (int i = 0; i < list.Length; i++)
        {
            string[] arr = LeetcodeToStringArray(list[i]);
            result[i] = arr;
        }
        return result;
    }
}

