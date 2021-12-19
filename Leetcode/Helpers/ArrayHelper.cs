namespace Leetcode;

public static class ArrayHelper
{
    public static char[][] LeetcodeToCharArray2D(this string s)
    {
        if (s == "[]")
        {
            return new char[][] { };
        }

        string[] list = s.Split("],[");
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

        string t = s.Replace("[", "").Replace("]", "").Replace("'", "");
        string[] list = t.Split(',', StringSplitOptions.RemoveEmptyEntries);
        char[] result = new char[list.Length];
        for (int i = 0; i < list.Length; i++)
        {
            result[i] = list[i][0];
        }
        return result;
    }

    public static int[][] LeetcodeToArray2D(this string s)
    {
        string t = s;
        t = t.Replace(" ", "");
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

    public static void Print2D<T>(this IList<IList<T>> matrix)
    {
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
}

