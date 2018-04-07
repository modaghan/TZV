using Facet.Combinatorics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZV
{
    class Program
    {
        static bool[] matrix = new bool[] { false, true, false, false, false, true, false, false, false };
        static void Main(string[] args)
        {
            for (int i = 1; i <= 9; i++)
            {
                Variations<int> variations = new Variations<int>(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, i);
                Console.WriteLine(variations.Count);
                foreach (List<int> row in variations)
                {
                    if (Test(row))
                    {
                        row.Reverse();
                        foreach (int num in row)
                        {
                            Console.Write(num + ", ");
                        }
                        Console.WriteLine();
                    }
                } 

            }
            Console.WriteLine("Bulunamadı");

            Console.ReadLine();
        }

        static bool Test(List<int> list)
        {
            bool[] tempMatrix = (bool[])matrix.Clone();
            for (int i = 0; i < list.Count; i++)
            {
                if (i + 1 != list.Count && list[i + 1] > list[i])
                    return false;
            }
            for (int i = 0; i < list.Count; i++)
            {
                int index = list[i] - 1;
                tempMatrix[index] = !tempMatrix[index];
                if (index - 1 != -1)
                    tempMatrix[index - 1] = !tempMatrix[index - 1];
                if (index + 1 != 9)
                    tempMatrix[index + 1] = !tempMatrix[index + 1];
            }
            foreach (bool item in tempMatrix)
            {
                if (!item)
                    return false;
            }
            return true;
        }
    }
}
