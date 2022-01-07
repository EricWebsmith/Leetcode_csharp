namespace Leetcode5947;


public class SolutionJava
{
    const int NOT_VISITED = 0;
    const int VISITING = 1;
    const int VISITED = 2;
    Dictionary<string, int> status = new Dictionary<string, int>();
    Dictionary<string, IList<string>> prereqs = new Dictionary<string, IList<string>>();

    public List<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies)
    {


        for (int i = 0; i < recipes.Length; ++i)
        {
            status.Add(recipes[i], NOT_VISITED);
            prereqs.Add(recipes[i], ingredients[i]);
        }

        foreach (string s in supplies)
        {
            status.Add(s, VISITED);
        }

        List<string> output = new List<string>();
        foreach (string s in recipes)
        {
            if(Dfs(s))
            {
                output.Add(s);
            }
        }

        return output;
    }

    public bool Dfs(string s)
    {
        if (!status.ContainsKey(s))
        {
            return false;
        }

        if (status[s] == VISITING)
        {
            return false;
        }

        if (status[s] == VISITED)
        {
            return true;
        }

        status[s] = VISITING;
        foreach (string p in prereqs[s])
        {
            if (!Dfs(p))
            {
                return false;
            }
        }
        status[s] = VISITED;
        return true;
    }
}

// Topological

public class Solution
{
    string[] supplies;
    Dictionary<string, IList<string>> dependencies = new Dictionary<string, IList<string>>();
    Dictionary<string, bool> canProduce = new Dictionary<string, bool>();
    List<string> visiting = new List<string>();

    private bool Dfs(string food)
    {

        if (canProduce.ContainsKey(food))
        {
            return canProduce[food];
        }

        // loop
        if (visiting.Contains(food))
        {
            Console.WriteLine("loop:"+food);
            canProduce[food] = false;
            return false;
        }

        visiting.Add(food);

        if (!dependencies.ContainsKey(food))
        {
            canProduce[food] = false;
            return false;
        }

        foreach (string ingredient in dependencies[food])
        {
            if (supplies.Contains(ingredient))
            {
                continue;
            }
            else if (canProduce.ContainsKey( ingredient))
            {
                if (!canProduce[ingredient])
                {
                    canProduce[food] = false;
                    return false;
                }
            }
            else if (!Dfs(ingredient))
            {
                canProduce[food] = false;
                return false;
            }
        }

        canProduce[food] = true;
        visiting.Remove(food);
        return true;
    }

    public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies)
    {

        this.supplies = supplies;
        for (int i = 0; i < recipes.Length; i++)
        {
            dependencies[recipes[i]] = ingredients[i];
        }

        IList<string> ans = new List<string>();
        foreach (string recipe in recipes)
        {
            if (Dfs(recipe))
            {
                visiting.Clear();
                ans.Add(recipe);
            }
        }

        return ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string recipesStr,string ingredientsStr, string suppliesStr, int expected)
    {
        string[] recipes = recipesStr.LeetcodeToStringArray();
        string[][] ingredients = ingredientsStr.LeetcodeToStringArray2D();
        string[] supplies = suppliesStr.LeetcodeToStringArray();
        IList<string> actual = new Solution().FindAllRecipes(recipes, ingredients, supplies);
        
        
        foreach(string s in actual)
        {
            Console.WriteLine(s);
        }

        Assert.AreEqual(expected, actual.Count);

    }

    [TestMethod] public void Test1() { 
        TestBase(
            "[bread,sandwich,burger]",
            "[[yeast,flour],[bread,meat],[sandwich,meat,bread]]", 
            "[yeast,flour]", 1); 
    }

    [TestMethod] public void Test2() 
    {
        TestBase(
            "[ju, fzjnm, x, e, zpmcz, h, q]",
            "[[d],[hveml,f,cpivl],[cpivl,zpmcz,h,e,fzjnm,ju],[cpivl,hveml,zpmcz,ju,h],[h,fzjnm,e,q,x],[d,hveml,cpivl,q,zpmcz,ju,e,x],[f,hveml,cpivl]]",
            "[f,hveml,cpivl,d]",
            3); 
    }

    [TestMethod]
    public void TestLoop()
    {
        TestBase(
            "[a,b,c]",
            "[[b],[a],[a,b]]",
            "[d,e,f]", 0);
    }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }
}