﻿using System.Collections.Generic;

namespace Leetcode0116;

public class Node
{
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() { }

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next)
    {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}

public class Solution
{
    public Node Connect(Node root)
    {
        if (root == null)
        {
            return root;
        }

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);
        

        while(queue.Count > 0)
        {
            Queue<Node> newQueue = new Queue<Node>();
            // dequeue first
            Node previousNode = queue.Dequeue();
            if (previousNode.left != null) { newQueue.Enqueue(previousNode.left); }
            if (previousNode.right != null) { newQueue.Enqueue(previousNode.right); }

            // dequeue the following
            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();
                previousNode.next = node;
                if (node.left != null) { newQueue.Enqueue(node.left); }
                if (node.right != null) { newQueue.Enqueue(node.right); }
                previousNode = node;
            }
            queue = newQueue;
        }

        return root;
    }
}

