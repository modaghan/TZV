using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZV.ConUI
{
    public class Question9
    {
         //  Driver program
        public static void Solution()
        {
            //  Create a sample graph
            Graph g = new Graph(13);
            g.addEdge(0, 2);
            g.addEdge(0, 3);
            g.addEdge(1, 2);
            g.addEdge(1, 5);
            g.addEdge(2, 0);
            g.addEdge(2, 1);
            g.addEdge(2, 3);
            g.addEdge(2, 5);
            g.addEdge(2, 6);
            g.addEdge(3, 0);
            g.addEdge(3, 2);
            g.addEdge(3, 6);
            g.addEdge(3, 7);
            g.addEdge(3, 4);
            g.addEdge(4, 3);
            g.addEdge(4, 7);
            g.addEdge(5, 1);
            g.addEdge(5, 2);
            g.addEdge(5, 6);
            g.addEdge(5, 9);
            g.addEdge(5, 8);
            g.addEdge(6, 2);
            g.addEdge(6, 3);
            g.addEdge(6, 7);
            g.addEdge(6, 10);
            g.addEdge(6, 9);
            g.addEdge(7, 3);
            g.addEdge(7, 4);
            g.addEdge(7, 6);
            g.addEdge(7, 10);
            g.addEdge(7, 11);
            g.addEdge(8, 5);
            g.addEdge(8, 9);
            g.addEdge(9, 5);
            g.addEdge(9, 6);
            g.addEdge(9, 8);
            g.addEdge(9, 10);
            g.addEdge(9, 12);
            g.addEdge(10, 6);
            g.addEdge(10, 7);
            g.addEdge(10, 9);
            g.addEdge(10, 11);
            g.addEdge(10, 12);
            g.addEdge(11, 7);
            g.addEdge(11, 10);
            g.addEdge(12, 9);
            g.addEdge(12, 10);
            //  arbitrary source
            int s = 0;
            //  arbitrary destination
            int d = 12;
            g.printAllPaths(s, d);
            Console.WriteLine("Solution : " + g.Count);
            Console.Read();
        }
    }
}
