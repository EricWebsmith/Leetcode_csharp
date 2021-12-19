namespace Leetcode1032;

/**
 * Your StreamChecker object will be instantiated and called as such:
 * StreamChecker obj = new StreamChecker(words);
 * bool param_1 = obj.Query(letter);
 */


public class TrieNode
{
    public Dictionary<char, TrieNode> Children { get; set; } = new Dictionary<char, TrieNode>();
    public bool IsEnd { get; set; }
}

/// <summary>
/// Runtime: 648 ms, faster than 64.86% of C# online submissions for Stream of Characters.
/// Memory Usage: 108.7 MB, less than 5.41% of C# online submissions for Stream of Characters.
/// </summary>
public class StreamChecker
{

    List<char> stream = new List<char>();
    TrieNode root = new TrieNode();

    public StreamChecker(string[] words)
    {
        foreach (string word in words)
        {
            TrieNode current = root;
            for(int i = word.Length-1; i >=0; i--)
            {
                if(!current.Children.ContainsKey(word[i]))
                {
                    current.Children.Add(word[i], new TrieNode());
                }

                current = current.Children[word[i]];
            }
            current.IsEnd = true;
        }
    }

    public bool Query(char letter)
    {
        stream.Insert(0, letter);
        TrieNode current = root;
        foreach(char c in stream)
        {
            if (current.IsEnd)
            {
                return true;
            }

            if (!current.Children.ContainsKey(c))
            {
                return false;
            }

            current = current.Children[c];
        }

        return current.IsEnd;
    }
}

[TestClass]
public class TestClass
{
    [TestMethod]
    public void Test1()
    {
        string[] words = { "cd", "f", "kl" };
        StreamChecker streamChecker = new StreamChecker(words);
        Assert.AreEqual(false, streamChecker.Query('a'));
        Assert.AreEqual(false, streamChecker.Query('b'));
        Assert.AreEqual(false, streamChecker.Query('c'));
        Assert.AreEqual(true, streamChecker.Query('d'));
        Assert.AreEqual(false, streamChecker.Query('e'));
        Assert.AreEqual(true, streamChecker.Query('f'));
        Assert.AreEqual(false, streamChecker.Query('g'));
        Assert.AreEqual(false, streamChecker.Query('h'));
        Assert.AreEqual(false, streamChecker.Query('i'));
        Assert.AreEqual(false, streamChecker.Query('j'));
        Assert.AreEqual(false, streamChecker.Query('k'));
        Assert.AreEqual(true, streamChecker.Query('l'));
    }

    [TestMethod]
    public void Test2()
    {
        //string[] words = { "aaaaaaaaa", "aaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaa" };

        List<string> wordList = new List<string>();
        string t = "aaaaaaaaaaaaaa";
        for (int i = 0; i < 1000; i++)
        {
            t = t + 'a';
            wordList.Add(t);
        }

        StreamChecker streamChecker = new StreamChecker(wordList.ToArray());
        for (int i = 0; i < 10000; i++)
        {
            streamChecker.Query('a');
        }

    }
}