namespace Leetcode0138;


public class Node
{
    public int val;
    public Node next;
    public Node random;

    public Node(int _val)
    {
        val = _val;
        next = null;
        random = null;
    }
}


public class Solution
{
    public Node CopyRandomList(Node head)
    {
        Dictionary<Node, Node> mapping = new Dictionary<Node, Node>();

        Node newPreHead = new Node(0);
        Node newPreCurrent = newPreHead;
        Node current = head;
        while (current != null)
        {
            Node newCurrent = new Node(current.val);
            newCurrent.random = current.random;

            mapping.Add(current, newCurrent);

            newPreCurrent.next = newCurrent;
            newPreCurrent = newPreCurrent.next;
            current = current.next;
        }

        current = newPreHead;
        while(current != null)
        {
            if(current.random != null)
            {
                current.random = mapping[current.random];
            }
            
            current = current.next;
        }

        return newPreHead.next;

    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase()
    {

    }

    //[TestMethod] public void Test1() { TestBase(); }
    //[TestMethod] public void Test2() { TestBase(); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}

/*
 Runtime: 80 ms, faster than 97.40% of C# online submissions for Copy List with Random Pointer.
Memory Usage: 39.9 MB, less than 5.49% of C# online submissions for Copy List with Random Pointer.
 */