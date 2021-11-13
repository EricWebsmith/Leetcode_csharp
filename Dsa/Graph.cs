using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsa
{
    public class Graph
    {
        public int VerticeCount { get; private set; }

        List<int>[] _adj;

        public Graph(int vertice_count)
        {
            _adj = new List<int>[vertice_count];
            for(int i = 0; i < _adj.Length; i++)
            {
                _adj[i] = new List<int>();
            }
            VerticeCount = vertice_count;
        }

        public void AddEdge(int v, int w)
        {
            _adj[v].Add(w);
        }

        public List<int> BFS(int s)
        {
            List<int> results = new List<int>();
            bool[] visited = new bool[VerticeCount];
            for(int i = 0; i < VerticeCount; i++)
            {
                visited[i] = false;
            }

            // Create a queue for BFS
            Queue<int> queue = new Queue<int>();

            visited[s] = true;
            queue.Enqueue(s);

            while (queue.Any())
            {
                // dequeue a vertex from queue
                // and print it.
                s = queue.Dequeue();
                results.Add(s);
                
                

                List<int> list = _adj[s];

                foreach(var value in list)
                {
                    if (!visited[value])
                    {
                        visited[value] = true;
                        queue.Enqueue(value);
                    }
                }
            }

            return results;
        }
    }
}
