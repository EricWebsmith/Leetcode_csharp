using Dsa;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DsaTest
{
    [TestClass]
    public class GraphTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Graph g = new Graph(4);

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            Console.Write("Following is Breadth First " +
                          "Traversal(starting from " +
                          "vertex 2)\n");
            var results = g.BFS(2);
            results.ForEach(c => Console.WriteLine(c));
            
        }
    }
}
