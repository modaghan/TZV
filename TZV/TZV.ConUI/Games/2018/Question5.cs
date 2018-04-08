using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZV.ConUI
{
    public class Question5
    {
        public static void Solution()
        {
            Permutations<string> Per = new Permutations<string>(new List<string> { "A", "B", "C", "D",",",",","," }, GenerateOption.WithoutRepetition);
            List<string> list = new List<string>();
            foreach (List<string> line in Per)
            {
                string sol = "";
                foreach (string s in line)
                {
                    sol += s;
                }
                sol = sol.Replace(",,,", ",");
                sol = sol.Replace(",,", ",");
                if (sol[0] == ',')
                    sol = sol.Remove(0, 1);
                if (sol[sol.Length - 1] == ',')
                    sol = sol.Remove(sol.Length - 1, 1);
                sol.Trim();
                string[] elements = sol.Split(',');
                string newString = "";
                foreach (string s in elements.OrderBy(a=>a))
                {
                    newString += s + ",";
                }
                newString = newString.Remove(newString.Length - 1, 1);
                list.Add(newString);                
            }
            List<string> newList = list.Distinct().ToList();

            foreach (string sol in newList.OrderBy(a=>a[0]).ThenBy(a=>a))
            {
                Console.WriteLine(sol);
            }
            Console.WriteLine(newList.Count);

            Console.ReadLine();
        }
    }
}
