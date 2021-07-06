using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithm.DataStructures
{
    public class GGraph
    {
        private Dictionary<int, GGraphNode> nodeLookup = new Dictionary<int, GGraphNode>();

        private GGraphNode getNode(int id)
        {
            return nodeLookup[id];
        }
        public void AddEdge(int source, int destination)
        {

        }

        public bool HasPathDFS(int source, int destination)
        {
            GGraphNode start = getNode(source);
            GGraphNode end = getNode(destination);

            HashSet<int> visisted = new HashSet<int>();
            return HasPathDFS(start, end, visisted);
        }
        public bool HasPathDFS(GGraphNode source, GGraphNode destination, HashSet<int> visisted)
        {
            if (visisted.Contains(source.Id))
                return false;
            visisted.Add(source.Id);
            if (source == destination)
                return true;

            foreach(GGraphNode child in source.Adjacent)
            {
                if (HasPathDFS(child, destination, visisted))
                    return true;
            }
            return false;
        }

        public bool HasPathBFS(GGraphNode source, GGraphNode destination)
        {
            Queue<GGraphNode> nextToVisit = new Queue<GGraphNode>();
            HashSet<int> visisted = new HashSet<int>();
            nextToVisit.Enqueue(source);

            while(nextToVisit.Count > 0)
            {
                GGraphNode node = nextToVisit.Dequeue();
                if (node == destination)
                    return true;

                if (visisted.Contains(node.Id))
                    continue;

                visisted.Add(node.Id);

                foreach (GGraphNode child in node.Adjacent)
                    nextToVisit.Enqueue(child);
            }

            return false;
        }
    }
    public class GGraphNode
    {
        public int Id;
        public LinkedList<GGraphNode> Adjacent = new LinkedList<GGraphNode>();
        public GGraphNode(int id)
        {
            Id = id;
        }
    }
}
