using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZV.ConUI
{
    public class Graph
    {

        //  No. of vertices in graph
        private int v;
        //  adjacency list 
        public List<int>[] adjList;
        public int Count { get; set; }
        // Constructor
        public Graph(int vertices)
        {
            // initialise vertex count
            this.v = vertices;
            //  initialise adjacency list
            this.initAdjList();
        }

        private void initAdjList()
        {
            this.adjList = new List<int>[this.v];
            for (int i = 0; (i < this.v); i++)
            {
                this.adjList[i] = new List<int>();
            }

        }

        //  add edge from u to v
        public void addEdge(int u, int v)
        {
            //  Add v to u's list.
            adjList[u].Add(v);
        }

        //  Prints all paths from
        //  's' to 'd'
        public void printAllPaths(int s, int d)
        {
            Count = 0;
            bool[] isVisited = new bool[this.v];
            List<int> pathList = new List<int>();
            // add source to path[]
            pathList.Add(s);
            // Call recursive utility
            this.printAllPathsUtil(s, d, isVisited, pathList);
        }

        //  A recursive function to print
        //  all paths from 'u' to 'd'.
        //  isVisited[] keeps track of
        //  vertices in current path.
        //  localPathList<> stores actual
        //  vertices in the current path
        private void printAllPathsUtil(int u, int d, bool[] isVisited, List<int> localPathList)
        {
            //  Mark the current node
            isVisited[u] = true;
            if (u.Equals(d))
            {
                for (int i = 0; i < localPathList.Count(); i++)
                {
                    Console.Write(localPathList[i] + " ");
                }
                ++Count;
                Console.WriteLine();
            }

            //  Recur for all the vertices
            //  adjacent to current vertex
            foreach (int i in this.adjList[u])
            {
                if (!isVisited[i])
                {
                    //  store current node 
                    //  in path[]
                    localPathList.Add(i);
                    this.printAllPathsUtil(i, d, isVisited, localPathList);
                    //  remove current node
                    //  in path[]
                    localPathList.Remove(i);
                }

            }

            //  Mark the current node
            isVisited[u] = false;
        }
    }
}
