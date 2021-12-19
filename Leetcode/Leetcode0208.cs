namespace Leetcode0208;

/// <summary>
/// Runtime: 228 ms, faster than 69.87% of C# online submissions for Implement Trie (Prefix Tree).
/// Memory Usage: 66 MB, less than 65.37% of C# online submissions for Implement Trie (Prefix Tree).
/// </summary>
public class TrieNode
{
    public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
    public bool IsEnd { get; set; }
}

public class Trie
{
    private TrieNode root = new TrieNode();
    public Trie()
    {

    }

    public void Insert(string word)
    {
        TrieNode current = root;
        foreach(char c in word)
        {
            if (!current.Children.ContainsKey(c))
            {
                current.Children.Add(c, new TrieNode());
            }

            current = current.Children[c];
        }
        current.IsEnd = true;
    }

    public bool Search(string word)
    {
        TrieNode current = root;
        foreach(char c in word)
        {
            if (!current.Children.ContainsKey(c))
            {
                return false;
            }
            current = current.Children[c];
        }
        return current.IsEnd;
    }

    public bool StartsWith(string prefix)
    {
        TrieNode current = root;
        foreach (char c in prefix)
        {
            if (!current.Children.ContainsKey(c))
            {
                return false;
            }
            current = current.Children[c];
        }
        return true;
    }
}
