namespace Leetcode0721;

public class Solution
{
    int[] unionFind;
    IList<IList<string>> accounts;
    SortedDictionary<string, int> emailIdMap = new SortedDictionary<string, int>(StringComparer.Ordinal);

    private int Find(int i)
    {
        int p = i;
        while (p != unionFind[p])
        {
            p = unionFind[p];
        }
        return p;
    }

    private void Union(int i, int j)
    {
        int p1 = Find(i);
        int p2 = Find(j);
        unionFind[p2] = p1;
    }

    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
    {
        unionFind = new int[accounts.Count];
        for (int i = 0; i < unionFind.Length; i++)
        {
            unionFind[i] = i;
        }
        this.accounts = accounts;

        for (int i = 0; i < accounts.Count; i++)
        {
            int p = i;
            for (int j = 1; j < accounts[i].Count; j++)
            {
                if (emailIdMap.ContainsKey(accounts[i][j]))
                {
                    p = emailIdMap[accounts[i][j]];
                    Union(p, i);
                }
                else
                {
                    emailIdMap.Add(accounts[i][j], p);
                }
            }
        }

        for (int i = 0; i < unionFind.Length; i++)
        {
            unionFind[i] = Find(i);
        }

        foreach (IList<string> account in accounts)
        {
            string name = account[0];
            account.Clear();
            account.Add(name);
        }

        foreach (string email in emailIdMap.Keys)
        {
            int id = emailIdMap[email];
            int p = unionFind[id];
            accounts[p].Add(email);
        }

        // delete
        for (int i = unionFind.Length - 1; i >= 0; i--)
        {
            if (unionFind[i] != i)
            {
                accounts.RemoveAt(i);
            }
        }

        return accounts;
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(IList<IList<string>> accounts, int expected)
    {
        IList<IList<string>> actual = new Solution().AccountsMerge(accounts);

        Helper.Print2D(actual);

        Assert.AreEqual(expected, actual.Count);
    }

    [TestMethod]
    public void Test1()
    {
        IList<IList<string>> accounts = new List<IList<string>>()
        {
            new List<string>(){ "John","johnsmith@mail.com","john_newyork@mail.com"},
            new List<string>(){ "John","johnsmith@mail.com","john00@mail.com"},
            new List<string>(){ "Mary","mary@mail.com"},
            new List<string>(){ "John","johnnybravo@mail.com"},
        };

        TestBase(accounts, 3);
    }

    [TestMethod]
    public void Test2()
    {
        IList<IList<string>> accounts = new List<IList<string>>()
        {
            new List<string>(){ "Gabe","Gabe0@m.co","Gabe3@m.co","Gabe1@m.co"},
            new List<string>(){ "Kevin","Kevin3@m.co","Kevin5@m.co","Kevin0@m.co"},
            new List<string>(){ "Ethan","Ethan5@m.co","Ethan4@m.co","Ethan0@m.co"},
            new List<string>(){ "Hanzo","Hanzo3@m.co","Hanzo1@m.co","Hanzo0@m.co"},
            new List<string>(){ "Fern","Fern5@m.co","Fern1@m.co","Fern0@m.co"}
        };

        TestBase(accounts, 5);
    }

    [TestMethod]
    public void Test3()
    {
        IList<IList<string>> accounts = new List<IList<string>>()
        {
            new List<string>(){ "Hanzo","Hanzo2@m.co","Hanzo3@m.co"},
            new List<string>(){ "Hanzo","Hanzo4@m.co","Hanzo5@m.co"},
            new List<string>(){ "Hanzo","Hanzo0@m.co","Hanzo1@m.co"},
            new List<string>(){ "Hanzo","Hanzo3@m.co","Hanzo4@m.co"},
            new List<string>(){ "Hanzo", "Hanzo7@m.co", "Hanzo8@m.co" },
            new List<string>(){ "Hanzo","Hanzo1@m.co","Hanzo2@m.co" },
            new List<string>(){ "Hanzo","Hanzo6@m.co","Hanzo7@m.co" },
            new List<string>(){ "Hanzo","Hanzo5@m.co","Hanzo6@m.co" }
        };

        TestBase(accounts, 1);
    }
}