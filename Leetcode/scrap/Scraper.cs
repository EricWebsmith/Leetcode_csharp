using System.IO;

namespace Leetcode.Scrap;

[TestClass]
public class Scraper
{

    [TestMethod]
    public void T1()
    {
        string filename = "D:\\projects\\Leetcode_csharp\\Leetcode\\test\\Leetcode0417.cs";
        using (StreamWriter sw = new StreamWriter(filename))
        {
            sw.Write("Hello World");
        }
        Console.WriteLine("Done");
    }
}
