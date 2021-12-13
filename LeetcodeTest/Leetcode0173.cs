namespace Leetcode0173;


public class BSTIterator
{
    TreeNode current = null;
    Stack<TreeNode> stack = new Stack<TreeNode>();

    public BSTIterator(TreeNode root)
    {
        current = root;
        while(current != null)
        {
            stack.Push(current);
            current = current.left;
        }
        //current = stack.Pop();
    }

    public int Next()
    {
        if(stack.Count == 0)
        {
            return -1;
        }

        current = stack.Pop();
        int value = current.val;
        if (current.right != null)
        {
            current = current.right;
            //stack.Push(current);
            while (current != null)
            {
                stack.Push(current);
                current = current.left;
            }
        }
        return value;
    }

    public bool HasNext()
    {
        return stack.Count > 0;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase()
    {

    }

    [TestMethod] 
    public void Test1() 
    {
        TreeNode root = "[7, 3, 15, null, null, 9, 20]".LeetcodeToTree();
        BSTIterator bSTIterator = new BSTIterator(root);

        Console.WriteLine(bSTIterator.Next());    // return 3
        Console.WriteLine(bSTIterator.Next());    // return 7
        Console.WriteLine(bSTIterator.HasNext()); // return True
        Console.WriteLine(bSTIterator.Next());   // return 9
        Console.WriteLine(bSTIterator.HasNext()); // return True
        Console.WriteLine(bSTIterator.Next());    // return 15
        Console.WriteLine(bSTIterator.HasNext()); // return True
        Console.WriteLine(bSTIterator.Next());    // return 20
        Console.WriteLine(bSTIterator.HasNext()); // return False
    }

    [TestMethod] 
    public void Test2() 
    {
        TreeNode root = "[7, 3, 15]".LeetcodeToTree();
        BSTIterator bSTIterator = new BSTIterator(root);

        Console.WriteLine(bSTIterator.Next());    // return 3
        Console.WriteLine(bSTIterator.Next());    // return 7
        Console.WriteLine(bSTIterator.Next());    // return 15
        Console.WriteLine(bSTIterator.HasNext()); // return True
        Console.WriteLine(bSTIterator.Next());   // return 9
        Console.WriteLine(bSTIterator.HasNext()); // return True
        
        Console.WriteLine(bSTIterator.HasNext()); // return True
        Console.WriteLine(bSTIterator.Next());    // return 20
        Console.WriteLine(bSTIterator.HasNext()); // return False
    }

    [TestMethod] public void Test3() { TestBase(); }
    [TestMethod] public void Test4() { TestBase(); }
}