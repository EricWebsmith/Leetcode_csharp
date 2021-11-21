namespace Leetcode0706;

public class MyHashMap
{
    int[] l = new int[1000000];


    public MyHashMap()
    {
        for(int i = 0; i <l.Length; i++)
        {
            l[i] = -1;
        }
    }

    public void Put(int key, int value)
    {
        l[key] = value;
    }

    public int Get(int key)
    {
        return l[key];
    }

    public void Remove(int key)
    {
        l[key] = -1;
    }
}
