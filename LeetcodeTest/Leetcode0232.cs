namespace Leetcode0232;

public class MyQueue
{
    private Stack<int> pushStack = new Stack<int>();
    private Stack<int> popStack = new Stack<int>();
    private bool isPush = true;

    private void Swith()
    {
        if (isPush)
        {
            while (pushStack.Count > 0)
            {
                int t = pushStack.Pop();
                popStack.Push(t);
            }
        }
        else
        {
            while (popStack.Count > 0)
            {
                int t = popStack.Pop();
                pushStack.Push(t);
            }
        }

        isPush = !isPush;
    }

    public MyQueue()
    {
    }

    public void Push(int x)
    {
        if (!isPush)
        {
            Swith();
        }
        pushStack.Push(x);
    }

    public int Pop()
    {
        if (isPush)
        {
            Swith();
        }

        return popStack.Pop();
    }

    public int Peek()
    {
        if (isPush)
        {
            return pushStack.Last();
        }
        else
        {
            return popStack.Peek();
        }
    }

    public bool Empty()
    {
        if (isPush)
        {
            return pushStack.Count == 0;
        }
        else
        {
            return popStack.Count == 0;
        }
    }
}

[TestClass]
public class SolutionTest
{


    [TestMethod]
    public void Test1()
    {
        MyQueue myQueue = new MyQueue();
        myQueue.Push(1);
        myQueue.Push(2);
        int peek = myQueue.Peek();
        Assert.AreEqual(1, peek);
        int pop = myQueue.Pop();
        Assert.AreEqual(1, pop);
        bool empty = myQueue.Empty();
        Assert.IsFalse(empty);
    }


    [TestMethod]
    public void Test2()
    {
        MyQueue myQueue = new MyQueue();
        myQueue.Push(1);
        myQueue.Push(2);
        int peek = myQueue.Peek();
        Assert.AreEqual(1, peek);
        int pop = myQueue.Pop();
        Assert.AreEqual(1, pop);
        bool empty = myQueue.Empty();
        Assert.IsFalse(empty);

        myQueue.Push(3);
        myQueue.Push(4);
        pop = myQueue.Pop();
        Assert.AreEqual(2, pop);
        pop = myQueue.Pop();
        Assert.AreEqual(3, pop);
        pop = myQueue.Pop();
        Assert.AreEqual(4, pop);
        empty = myQueue.Empty();
        Assert.IsTrue(empty);
    }

}
