using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.DataStructures
{
    class GNode
    {
        public int Id;
        public LinkedList<GNode> Adjacents = new LinkedList<GNode>();
        private GNode(int id)
        {
            this.Id = id;
        }
    }
    class THJOGraph
    {
        private Dictionary<int, GNode> nodeLookup = new Dictionary<int, GNode>();
        private GNode GetNode(int id)
        {
            return null;
        }
        public void AddEdge(int source, int dest)
        {

        }
        public bool HasPathDFS(GNode s, GNode d)
        {
            HashSet<int> visited = new HashSet<int>();
            return HasPathDFS(s, d, visited);
        }
        private bool HasPathDFS(GNode s, GNode d, HashSet<int> visited)
        {
            if (visited.Contains(s.Id))
                return false;

            visited.Add(s.Id);
            if (s.Id == d.Id)
                return true;
            foreach (var adjcent in s.Adjacents)
            {
                if (HasPathDFS(adjcent, d, visited))
                    return true;
            }
            return false;
        }

        public bool HasPathBFS(GNode s, GNode d)
        {
            HashSet<int> visited = new HashSet<int>();
            Queue<GNode> q = new Queue<GNode>();

            q.Enqueue(s);
            while(q.Count > 0)
            {
                GNode curr = q.Dequeue();
                if (curr.Id == d.Id)
                    return true;
                if (!visited.Contains(curr.Id))
                    visited.Add(curr.Id);
                else
                    continue;
                foreach (var adjacent in curr.Adjacents)
                {
                    if (!visited.Contains(adjacent.Id))
                        q.Enqueue(adjacent);
                }
            }

            return false;
        }


        void Dijkstra(int[,] g, int v, int src)
        {
            int[] dist = new int[v];
            bool[] seen = new bool[v];

            for(int i = 0; i < v; i++)
            {
                dist[i] = int.MaxValue;
                seen[i] = false;
            }
            dist[src] = 0;
        }
    }
}
