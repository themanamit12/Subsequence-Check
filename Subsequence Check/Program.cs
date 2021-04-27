using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class CandidateCode
{
    static bool isSubSequence(string str1, string str2, int m, int n)
    {
        if (m == 0)
            return true;
        if (n == 0)
            return false;

        if (str1[m - 1] == str2[n - 1])
            return isSubSequence(str1, str2, m - 1, n - 1);

        return isSubSequence(str1, str2, m, n - 1);
    }

    static void Main(String[] args)
    {
        //Write code here
        Console.WriteLine("Please input virus composition (only lower case)");
        string virus = Console.ReadLine().ToLower();

        Console.WriteLine("Please input number of people (Should not more than 10)");
        string number = Console.ReadLine();

        bool isNumeric = int.TryParse(number, out int n);

        while (!isNumeric || n > 10)
        {
            Console.WriteLine("Error: Please input valid number of people (Should not more than 10)");
            number = Console.ReadLine();
            isNumeric = int.TryParse(number, out n);
        }

        string[] people = new string[n];
        Console.WriteLine("Please input blood composition for each people respectively");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Blood composition for person [" + (i + 1) + "] (only lower case)");
            people[i] = Console.ReadLine().ToLower();
        }

        for (int i = 0; i < n; i++)
        {
            int x = people[i].Length;
            int y = virus.Length;
            bool res = isSubSequence(people[i], virus, x, y);

            if (res)
                Console.WriteLine("POSITIVE");
            else
                Console.WriteLine("NEGATIVE");
        }

        Console.Write("Press any key to exit...!");
        Console.ReadLine();
    }
}
