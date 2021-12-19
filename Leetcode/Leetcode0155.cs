namespace Leetcode0155;

/// <summary>
/// Runtime: 116 ms, faster than 96.44% of C# online submissions for Min Stack.
/// Memory Usage: 47.5 MB, less than 13.66% of C# online submissions for Min Stack.
/// </summary>
public class MinStack
{
    Stack<int> minStack = new Stack<int>();
    Stack<int> stack = new Stack<int>();

    public MinStack()
    {

    }

    public void Push(int val)
    {
        if(minStack.Count == 0)
        {
            minStack.Push(val);
        }
        else
        {
            int min = Math.Min(val, minStack.Peek());
            minStack.Push(min);
        }
        stack.Push(val);
    }

    public void Pop()
    {
        minStack.Pop();
        stack.Pop();
    }

    public int Top()
    {
        return stack.Peek();
    }

    public int GetMin()
    {
        return minStack.Peek();
    }
}

[TestClass]
public class MinStackTest
{
    [TestMethod]
    public void Test1()
    {
        MinStack minStack = new MinStack();
        minStack.Push(-2);
        minStack.Push(0);
        minStack.Push(-3);
        Assert.AreEqual(-3, minStack.GetMin());
        minStack.Pop();
        Assert.AreEqual(0, minStack.Top());
        Assert.AreEqual(-2, minStack.GetMin());
    }
}