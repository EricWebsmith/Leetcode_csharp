namespace Leetcode0707;

/// <summary>
/// Runtime: 128 ms, faster than 99.18% of C# online submissions for Design Linked List.
/// Memory Usage: 44.1 MB, less than 57.61% of C# online submissions for Design Linked List.
/// </summary>
public class MyLinkedList
{
    internal ListNode prehead = new ListNode(-1);
    internal ListNode tail = null;
    internal int count = 0;

    public MyLinkedList()
    {

    }

    public int Get(int index)
    {
        ListNode current = prehead.next;
     
        for(int i = 1; i < index+1 && current!=null; i++)
        {
            current = current.next;
        }

        if(current == null) { return -1; }

        return current.val;
    }

    public void AddAtHead(int val)
    {
        ListNode newNode = new ListNode(val);

        if(prehead.next == null)
        {
            prehead.next = newNode;
            tail = newNode;
            count = 1;
            return;
        }

        newNode.next = prehead.next;
        prehead.next = newNode;

        count++;
    }

    public void AddAtTail(int val)
    {
        ListNode newNode = new ListNode(val);

        if (prehead.next == null)
        {
            prehead.next = newNode;
            tail = newNode;
            count = 1;
            return;
        }

        tail.next = newNode;
        tail = tail.next;

        count++;
    }

    public void AddAtIndex(int index, int val)
    {
        if (index < 0 || index > count)
        {
            return;
        }

        if(index == 0)
        {
            AddAtHead(val);
            return;
        }

        if (index == count)
        {
            AddAtTail(val);
            return;
        }

        ListNode current = prehead.next;

        for (int i = 1; i < index && current != null; i++)
        {
            current = current.next;
        }

        ListNode temp = current.next;
        current.next = new ListNode(val);
        current.next.next = temp;
        count++;
    }

    public void DeleteAtIndex(int index)
    {
        if (index < 0 || index >= count)
        {
            return;
        }

        if (index == 0)
        {
            if(prehead.next != null)
            {
                prehead.next = prehead.next.next;
                count--;
            }
            return;
        }

        ListNode current = prehead.next;

        for (int i = 1; i < index && current != null; i++)
        {
            current = current.next;
        }

        current.next = current.next.next;


        if(index == count - 1)
        {
            tail = current;
        }

        count--;
    }
}

[TestClass]
public class TestClass
{
    [TestMethod]
    public void Test1()
    {
        MyLinkedList myList = new MyLinkedList();
        myList.AddAtHead(7);
        Console.WriteLine(myList.prehead.next.ToStr());
        myList.AddAtHead(2);
        Console.WriteLine(myList.prehead.next.ToStr());
        myList.AddAtHead(1);
        Console.WriteLine(myList.prehead.next.ToStr());
        myList.AddAtIndex(3, 0);
        Console.WriteLine(myList.prehead.next.ToStr());
        myList.DeleteAtIndex(2);
        Console.WriteLine(myList.prehead.next.ToStr());
        myList.AddAtHead(6);
        Console.WriteLine(myList.prehead.next.ToStr());
        myList.AddAtTail(4);
        Console.WriteLine(myList.prehead.next.ToStr());
        int v = myList.Get(4);
        Console.WriteLine(v);
        Assert.AreEqual(4, v);
    }


    [TestMethod]
    public void Test2()
    {
        MyLinkedList myList = new MyLinkedList();
        myList.AddAtIndex(0, 10);
        Console.WriteLine(myList.prehead.next.ToStr());
        myList.AddAtIndex(0, 20);
        Console.WriteLine(myList.prehead.next.ToStr());
        myList.AddAtIndex(1, 30);
        int v = myList.Get(0);

        Console.WriteLine(v);
        Assert.AreEqual(20, v);
    }
}