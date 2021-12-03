namespace LeetcodeTest;

    public static class StringHelper
    {
        public static string[] LeetcodeToStringArray(this string s)
        {
            string t = s.Replace("[", "").Replace("]", "");
            string[] arr = t.Split(',');
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i].Trim('"');
            }
            return arr;
        }
    }
