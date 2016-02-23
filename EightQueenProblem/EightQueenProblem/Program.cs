using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueenProblem
{
    class Program
    {
        public static void WriteSolution(List<int[]> solution)
        {
            char q1 = '(';
            char q2 = ')';

            char[][] table = new char[8][];
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = Enumerable.Repeat(' ', 8).ToArray();
            }
            foreach (var currentQueen in solution)
            {
                table[currentQueen[0]][currentQueen[1]] = q1;
            }

            //Console.WriteLine("----------------");
            //foreach (var row in table)
            //{
            //    Console.WriteLine(new String(row));
            //}

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Console.BackgroundColor = (x + y) % 2 == 0 ? ConsoleColor.Black : ConsoleColor.White;
                    Console.ForegroundColor = (x + y) % 2 == 1 ? ConsoleColor.Black : ConsoleColor.White;
                    Console.BackgroundColor = (x + y) % 2 == 0 ? ConsoleColor.Black : ConsoleColor.White;
                    Console.Write(table[y][x]);
                    Console.Write(table[y][x] == q1 ? q2 : table[y][x]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("----------------");
        }

        public static bool CheckSolution(List<int[]> solution)
        {
            for (int i = 1; i < solution.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (solution[i][0] == solution[j][0] || solution[i][1] == solution[j][1] || Math.Abs(solution[i][0] - solution[j][0]) == Math.Abs(solution[i][1] - solution[j][1]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            //List<int[]> test = new List<int[]>();

            //test.Add(new int[] { 1 });
            //test.Add(new int[] { 2 });
            //test.Add(new int[] { 3 });

            //test.Last()[0]++;

            //Console.ReadKey();
            //Environment.Exit(0);

            List<List<int[]>> solutionList = new List<List<int[]>>();

            bool finished = false;

            List<int[]> currentSolution = new List<int[]>();

            currentSolution.Add(new int[] { 0, 0 });

            while (!finished)
            {
                if (CheckSolution(currentSolution))
                {
                    if (currentSolution.Count == 8)
                    {
                        solutionList.Add(currentSolution.Select(a => (int[])a.Clone()).ToList());
                        currentSolution.Last()[0]++;
                    }
                    else
                    {
                        currentSolution.Add(new int[] { 0, currentSolution.Last()[1] + 1 });
                    }
                }
                else
                {
                    currentSolution.Last()[0]++;
                }

                while (!finished && currentSolution.Last()[0] > 7)
                {
                    currentSolution.RemoveAt(currentSolution.Count - 1);
                    if (currentSolution.Count > 0)
                    {
                        currentSolution.Last()[0]++;
                    }
                    else
                    {
                        finished = true;
                    }
                }
            }

            int x = 1;
            foreach (var solution in solutionList)
            {
                Console.WriteLine(x++);
                WriteSolution(solution);
            }

            Console.ReadKey();
        }
    }
}
