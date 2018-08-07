using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProb5
{
    class Program2
    {
        static int TARGET_SUM = 100;
        static int[] VALUES = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        static ArrayList Add(int digit, string sign, ArrayList branches)
        {
            for (int i = 0; i < branches.Count; i++)
            {
                branches[i] = digit + sign + branches[i];
            }
            return branches;
        }

        static ArrayList f(int sum, int number, int index)
        {
            // بدست آوردن رقم یکان
            int digit = Math.Abs(number % 10);

            if(index >= VALUES.Length)
            {
                if(sum == number)
                {
                    ArrayList result = new ArrayList();
                    result.Add(digit.ToString());
                    return result;
                }
                else
                {
                    return new ArrayList();
                }
            }

            // f(1..9) => 1+f(2..9), 1-f(2..9), f(12..9)

            ArrayList branch1 = f(sum - number, VALUES[index], index + 1);

            ArrayList branch2 = f(sum - number, -VALUES[index], index + 1);

            int concatNumber = number >= 0
                ? 10 * number + VALUES[index]
                : 10 * number - VALUES[index];

            ArrayList branch3 = f(sum, concatNumber, index + 1);

            ArrayList results = new ArrayList();
            results.AddRange(Add(digit, "+", branch1));
            results.AddRange(Add(digit, "-", branch2));
            results.AddRange(Add(digit, "", branch3));

            return results;
        }

        static void Main2(string[] args)
        {
            foreach (var item in f(TARGET_SUM, VALUES[0], 1))
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }


    }
}
