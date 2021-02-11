using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ex1
{
    public class GarderParams
    {
        public List<List<string>> getEmptyMatrix(int x, int y)
        {
            var matrix = new List<List<string>> { };
            for (int i = 0; i < y; i++)
            {
                var matrixLine = new List<string> { };
                for (int j = 0; j < x; j++)
                {
                    matrixLine.Add(".");
                }
                matrix.Add(matrixLine);
            }

            return matrix;
        }

        public int findGardenBed(int y, int x, List<List<string>> matrix, int counter, int matrixMaxX, int matrixMaxY)
        {
            if (matrix[y][x] == "#")
            {
                matrix[y][x] = ".";
                counter++;
                if (x != matrixMaxX - 1)
                    findGardenBed(y, x + 1, matrix, counter, matrixMaxX, matrixMaxY);
                if (x != 0)
                    findGardenBed(y, x - 1, matrix, counter, matrixMaxX, matrixMaxY);
                if (y != matrixMaxY - 1)
                    findGardenBed(y + 1, x, matrix, counter, matrixMaxX, matrixMaxY);
                if (y != 0)
                    findGardenBed(y - 1, x, matrix, counter, matrixMaxX, matrixMaxY);
            }
            return counter;
        }


        /*public int findGardenBed(int y, int x, List<List<string>> matrix, int counter, int matrixMaxX, int matrixMaxY)
        {
            if (matrix[x][y] == "#")
            {
                matrix[x][y] = ".";
                counter++;
                if (x != matrixMaxX)
                    findGardenBed(x + 1, y, matrix, counter, matrixMaxX, matrixMaxY);
                if (x != 0)
                    findGardenBed(x - 1, y, matrix, counter, matrixMaxX, matrixMaxY);
                if (y != matrixMaxY)
                    findGardenBed(x, y + 1, matrix, counter, matrixMaxX, matrixMaxY);
                if (y != 0)
                    findGardenBed(x, y - 1, matrix, counter, matrixMaxX, matrixMaxY);
            }
            return counter;
        }*/


        public string[] getGardenSize(string s)
        {
            var numbersStrings = s.Split(' ');
            return numbersStrings;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var x = 0;
            var y = 0;
            var count = 0;

            var text = File.ReadAllLines("../../../input.txt");
            var garderParams = new GarderParams();
            var size = garderParams.getGardenSize(text[0]);

            x = int.Parse(size[1]);
            y = int.Parse(size[0]);
            Console.WriteLine(x);
            Console.WriteLine(y);

            var matrix = garderParams.getEmptyMatrix(x, y);
            var lineCounter = 0;
            foreach (var line in text)
            {
                if (line == text[0])
                    continue;

                for (int i = 0; i < x; i++)
                {
                    if (line[i] == '#')
                    {
                        matrix[lineCounter][i] = "#";
                    }
                }

                lineCounter++;
            }

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Console.Write(matrix[i][j]);
                }
                Console.WriteLine();
            }

        }
    }
}
