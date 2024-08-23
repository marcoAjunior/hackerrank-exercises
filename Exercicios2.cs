using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Result
{
    public static string encryption(string s)
    {
        string cleaned = s.Replace(" ", "");
        int L = cleaned.Length;

        int rows = (int)Math.Floor(Math.Sqrt(L));
        int columns = (int)Math.Ceiling(Math.Sqrt(L));

        if (rows * columns < L)
        {
            rows++;
        }

        char[,] grid = new char[rows, columns];
        int index = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                if (index < L)
                {
                    grid[r, c] = cleaned[index];
                    index++;
                }
                else
                {
                    grid[r, c] = ' ';
                }
            }
        }

        StringBuilder result = new StringBuilder();

        for (int c = 0; c < columns; c++)
        {
            for (int r = 0; r < rows; r++)
            {
                if (grid[r, c] != ' ')
                {
                    result.Append(grid[r, c]);
                }
            }
            result.Append(" ");
        }

        return result.ToString().Trim();
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.encryption(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
