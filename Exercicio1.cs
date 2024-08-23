using System;
using System.Collections.Generic;
using System.Linq;

class Result
{
    public static int simpleArraySum(List<int> ar)
    {
        return ar.Sum(); // Utiliza LINQ para somar todos os elementos
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int arCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> ar = Console.ReadLine().TrimEnd().Split(' ')
            .ToList().Select(x => Convert.ToInt32(x)).ToList();

        // Calcula a soma dos elementos
        int result = Result.simpleArraySum(ar);

        // Imprime o resultado
        Console.WriteLine(result);
    }
}
