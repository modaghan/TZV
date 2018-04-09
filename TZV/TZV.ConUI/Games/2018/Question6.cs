using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZV.ConUI
{
    public class Question6
    {
        static int loopCount = 1000000;
        static List<List<bool[,]>> SolutionPool = new List<List<bool[,]>>();
        static List<bool[,]> Cube = new List<bool[,]>()
        {
            new bool[,]{
                {false, false, false},
                {false, false, false},
                {false, false, false}
            },
            new bool[,]{
                {false, false,false },
                {false, false, false},
                {false, false, false}
            },
            new bool[,]{
                {false, false,false },
                {false, false, false},
                {false, false, false}
            }
        };
        static List<int[]> Coors = new List<int[]>();
        static List<List<int>> rows = new List<List<int>>();
        public static void Solution()
        {
            for (int l = 0; l < 3; l++)
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        Coors.Add(new int[3] { l, x, y });
                    }
                }
            }
            Combinations<int> variations = new Combinations<int>(new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 }, 6);
            long part = variations.Count / 100;
            int index = -1;
            foreach (var item in variations)
            {
                ++index;
                List<bool[,]> generatedModel = new List<bool[,]>()
                {
                    new bool[,]{
                        {false, false, false},
                        {false, false, false},
                        {false, false, false}
                    },
                    new bool[,]{
                        {false, false,false },
                        {false, false, false},
                        {false, false, false}
                    },
                    new bool[,]{
                        {false, false,false },
                        {false, false, false},
                        {false, false, false}
                    }
                };

                foreach (int coorIndex in item)
                {
                    int[] coor = Coors[coorIndex];
                    generatedModel[coor[0]][coor[1], coor[2]] = true;
                }

                if (Test(generatedModel))
                    SolutionPool.Add(generatedModel);
                if (index % part == 0)
                    Console.Write("|");
            }

            Console.WriteLine(SolutionPool.Count);
            Console.Read();
        }
        

        private static List<bool[,]> CreateCube(List<bool[,]> generatedModel)
        {
            int trueCount = 0;
            for (int l = 0; l < 3; l++)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (generatedModel[l][i, j])
                            ++trueCount;
                    }
                }
            }
            if (trueCount == 6)
                return generatedModel;
            else
            {
                int index = new Random(DateTime.Now.Millisecond).Next(rows.Count);
                int l = rows[index][0];
                int x = rows[index][1];
                int y = rows[index][2];
                generatedModel[l][x, y] = true;
                //Console.WriteLine("{0}-{1}-{2}", l, x, y);
                return CreateCube(generatedModel);
            }
        }

        private static bool Test(List<bool[,]> cube)
        {
            int trueCount = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (cube[0][i, j])
                        ++trueCount;
                }
            }
            if (trueCount == 0)
                return false;
            else
            {

                int similarityCount = 0;
                foreach (List<bool[,]> solCube in SolutionPool)
                {
                    for (int l = 0; l < 3; l++)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                if (cube[l][i, j] == solCube[l][i, j])
                                    ++similarityCount;
                            }
                        }
                    }
                }
                if (similarityCount == 27)
                    return false;
                else if (HasAloneCube(cube))
                    return false;
                else
                {
                    return true;
                }
            }
        }

        private static bool HasAloneCube(List<bool[,]> cube)
        {
            for (int l = 0; l < 3; l++)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (cube[l][i, j])
                        {
                            switch (l)
                            {
                                case 0:
                                    switch (i)
                                    {
                                        case 0:
                                            switch (j)
                                            {
                                                case 0:
                                                    if (!cube[0][0, 1] && !cube[0][1, 0] && !cube[1][0, 0])
                                                        return true;
                                                    break;
                                                case 1:
                                                    if (!cube[0][0, 0] && !cube[0][1, 1] && !cube[1][0, 1])
                                                        return true;
                                                    break;
                                                case 2:
                                                    if (!cube[0][0, 1] && !cube[0][1, 2] && !cube[1][0, 2])
                                                        return true;
                                                    break;
                                            }
                                            break;
                                        case 1:
                                            switch (j)
                                            {
                                                case 0:
                                                    if (!cube[0][0, 0] && !cube[0][1, 1] && !cube[0][2, 1] && !cube[1][0, 1])
                                                        return true;
                                                    break;
                                                case 1:
                                                    if (!cube[0][0, 1] && !cube[0][1, 0] && !cube[0][1, 2] && !cube[0][2, 1] && !cube[1][1, 1])
                                                        return true;
                                                    break;
                                                case 2:
                                                    if (!cube[0][0, 2] && !cube[0][1, 1] && !cube[0][2, 2] && !cube[1][1, 2])
                                                        return true;
                                                    break;
                                            }
                                            break;
                                        case 2:
                                            switch (j)
                                            {
                                                case 0:
                                                    if (!cube[0][1, 0] && !cube[0][2, 1] && !cube[1][2, 0])
                                                        return true;
                                                    break;
                                                case 1:
                                                    if (!cube[0][1, 1] && !cube[0][2, 0] && !cube[0][2, 2] && !cube[1][2, 1])
                                                        return true;
                                                    break;
                                                case 2:
                                                    if (!cube[0][1, 2] && !cube[0][2, 1] && !cube[1][2, 2])
                                                        return true;
                                                    break;
                                            }
                                            break;
                                    }
                                    break;
                                case 1:
                                    switch (i)
                                    {
                                        case 0:
                                            switch (j)
                                            {
                                                case 0:
                                                    if (!cube[l][0, 1] && !cube[l][1, 0] && !cube[2][0, 0] && !cube[0][0, 0])
                                                        return true;
                                                    break;
                                                case 1:
                                                    if (!cube[l][0, 0] && !cube[l][1, 1] && !cube[l][0, 2] && !cube[2][0, 1] && !cube[0][0, 1])
                                                        return true;
                                                    break;
                                                case 2:
                                                    if (!cube[l][0, 1] && !cube[l][1, 2] && !cube[2][0, 2] && !cube[0][0, 2])
                                                        return true;
                                                    break;
                                            }
                                            break;
                                        case 1:
                                            switch (j)
                                            {
                                                case 0:
                                                    if (!cube[l][0, 0] && !cube[l][1, 1] && !cube[l][2, 1] && !cube[0][0, 1] && !cube[2][0, 1])
                                                        return true;
                                                    break;
                                                case 1:
                                                    if (!cube[l][0, 1] && !cube[l][1, 0] && !cube[l][1, 2] && !cube[l][2, 1] && !cube[0][1, 1] && !cube[2][1, 1])
                                                        return true;
                                                    break;
                                                case 2:
                                                    if (!cube[l][0, 2] && !cube[l][1, 1] && !cube[l][2, 2] && !cube[0][1, 2] && !cube[2][1, 2])
                                                        return true;
                                                    break;
                                            }
                                            break;
                                        case 2:
                                            switch (j)
                                            {
                                                case 0:
                                                    if (!cube[l][1, 0] && !cube[l][2, 1] && !cube[0][2, 0] && !cube[2][2, 0])
                                                        return true;
                                                    break;
                                                case 1:
                                                    if (!cube[l][1, 1] && !cube[l][2, 0] && !cube[l][2, 2] && !cube[0][2, 1] && !cube[2][2, 1])
                                                        return true;
                                                    break;
                                                case 2:
                                                    if (!cube[l][1, 2] && !cube[l][2, 1] && !cube[0][2, 2] && !cube[2][2, 2])
                                                        return true;
                                                    break;
                                            }
                                            break;
                                    }
                                    break;
                                case 2:
                                    switch (i)
                                    {
                                        case 0:
                                            switch (j)
                                            {
                                                case 0:
                                                    if (!cube[l][0, 1] && !cube[l][1, 0] && !cube[1][0, 0])
                                                        return true;
                                                    break;
                                                case 1:
                                                    if (!cube[l][0, 0] && !cube[l][1, 1] && !cube[1][0, 1])
                                                        return true;
                                                    break;
                                                case 2:
                                                    if (!cube[l][0, 1] && !cube[l][1, 2] && !cube[1][0, 2])
                                                        return true;
                                                    break;
                                            }
                                            break;
                                        case 1:
                                            switch (j)
                                            {
                                                case 0:
                                                    if (!cube[l][0, 0] && !cube[l][1, 1] && !cube[l][2, 1] && !cube[1][0, 1])
                                                        return true;
                                                    break;
                                                case 1:
                                                    if (!cube[l][0, 1] && !cube[l][1, 0] && !cube[l][1, 2] && !cube[l][2, 1] && !cube[1][1, 1])
                                                        return true;
                                                    break;
                                                case 2:
                                                    if (!cube[l][0, 2] && !cube[l][1, 1] && !cube[l][2, 2] && !cube[1][1, 2])
                                                        return true;
                                                    break;
                                            }
                                            break;
                                        case 2:
                                            switch (j)
                                            {
                                                case 0:
                                                    if (!cube[l][1, 0] && !cube[l][2, 1] && !cube[1][2, 0])
                                                        return true;
                                                    break;
                                                case 1:
                                                    if (!cube[l][1, 1] && !cube[l][2, 0] && !cube[l][2, 2] && !cube[1][2, 1])
                                                        return true;
                                                    break;
                                                case 2:
                                                    if (!cube[l][1, 2] && !cube[l][2, 1] && !cube[1][2, 2])
                                                        return true;
                                                    break;
                                            }
                                            break;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
