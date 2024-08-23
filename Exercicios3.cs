using System;
using System.Collections.Generic;

class Solution
{
    static int[] nim = new int[301];

    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());
        
        while (t-- > 0)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());
            string s = Console.ReadLine();

            List<int> list = new List<int>();
            int count = 0;


            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                if (ch == 'I')
                {
                    count++;
                }
                else
                {
                    if (count != 0)
                    {
                        list.Add(count);
                    }
                    count = 0;
                }
            }


            if (count > 0)
            {
                list.Add(count);
            }

            int result = 0;
            for (int i = 0; i < list.Count; i++)
            {

                result ^= grundy(list[i]);
            }

            if (result <= 0)
            {

                Console.WriteLine("LOSE");
            }
            else
            {

                Console.WriteLine("WIN");
            }
        }
    }

    private static int mex(List<int> arr)
    {
        int mex = 0;
        while (arr.Contains(mex))
            mex++;
        return mex;
    }

    private static int grundy(int n)
    {
        if (nim[n] != 0)
            return nim[n];
        if (n == 0)
        {
            nim[0] = 0;
            return 0;
        }
        if (n == 1)
        {
            nim[1] = 1;
            return 1;
        }
        if (n == 2)
        {
            nim[2] = 2;
            return 2;
        }

        List<int> list = new List<int>();
        for (int i = 1, j = 0, k = 0; i <= n; i++)
        {
            int x, y;
            if (i <= n / 2)
            {
                x = grundy(j);
                y = grundy(n - j - 2);
                j++;
            }
            else
            {
                x = grundy(k);
                y = grundy(n - k - 1);
                k++;
            }
            list.Add(x ^ y);
        }
        nim[n] = mex(list);
        return nim[n];
    }
}
