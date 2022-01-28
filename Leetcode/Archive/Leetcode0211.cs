namespace Leetcode0211;


public class Trie
{
    public Dictionary<char, Trie> TrieDict = new Dictionary<char, Trie>();
    public bool WordEnd { get; set; }
}

public class WordDictionary
{
    Trie root = new Trie();

    public WordDictionary()
    {

    }

    public void AddWord(string word)
    {
        
        Trie current = root;
        foreach(char c in word)
        {
            if (current.TrieDict.ContainsKey(c))
            {
                current = current.TrieDict[c];
            }
            else
            {
                Trie newTrie = new Trie();
                current.TrieDict.Add(c, newTrie);
                current = newTrie;
            }
        }
        current.WordEnd = true;
    }

    public bool Search(string word)
    {
        List<Trie> current = new List<Trie>{ root };
        foreach (char c in word)
        {
            List<Trie> next = new List<Trie>();
            foreach(Trie t in current)
            {
                if (c == '.')
                {
                    foreach (Trie val in t.TrieDict.Values)
                    {
                        next.Add(val);
                    }
                }
                else
                {
                    if (t.TrieDict.ContainsKey(c))
                    {
                        next.Add(t.TrieDict[c]);
                    }
                }
            }

            if(next.Count == 0)
            {
                return false;
            }

            current = next;
        }

        return current.Any(c=>c.WordEnd);
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase()
    {

    }

    [TestMethod] public void Test1() 
    {
        WordDictionary wordDictionary = new WordDictionary();
        wordDictionary.AddWord("bad");
        wordDictionary.AddWord("dad");
        wordDictionary.AddWord("mad");
        Assert.AreEqual(false,  wordDictionary.Search("pad")); // return False
        Assert.AreEqual(true, wordDictionary.Search("bad")); // return True
        Assert.AreEqual(true, wordDictionary.Search(".ad")); // return True
        Assert.AreEqual(true, wordDictionary.Search("b..")); // return True
    }
    //[TestMethod] public void Test2() { TestBase(); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}