using System;
using System.Linq;

namespace tassk7
{
    class Program
    {
        public static void Color(string txt)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(txt);
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            bool ok = true;
            string str = "";
            Console.WriteLine("Введите информационные разряды");
            do
            {
                str = Console.ReadLine();
                for (int i = 0; i < str.Length; i++)
                {
                    char m = str[i];
                    if ((m < '0') || (m > '1'))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Ошибка, информационные разряды могут содержать только цифры \"0\" и \"1\"");
                        Console.ResetColor();
                        ok = false;
                        break;
                    }
                    else ok = true;
                }
            } while (!ok);
            int ind = 0;
            int[] inform = new int[str.Length];
            foreach (char c in str)
            {
                int chislo = c;
                if (chislo == 48) inform[ind] = 0;
                else inform[ind] = 1;
                ind++;
            }

            int n = str.Count();
            int k = (int)Math.Log(n, 2);
            do
            {
                if (n > Math.Pow(2, k) - k - 1)
                {
                    ok = false;
                    k++;
                }
                else ok = true;
            } while (!ok);

            Console.WriteLine();
            Console.Write("Необходимо добавить ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(k);
            Console.ResetColor();
            Console.Write(" контрольных разряда(ов)\n");
            int[] arr = new int[n + k];

            int forlog = 0;
            int x = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int step = i + 1;
                if ((double)forlog == Math.Log(step, 2))
                {
                    forlog++;
                    arr[i] = 5;
                }
                else
                {
                    arr[i] = inform[x];
                    x++;
                }
            }

            int forlog2 = 0;
            int even = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int next = i + 1;
                if ((double)forlog2 == Math.Log(next, 2))
                {
                    even = 0;
                    for (int j = i; j < arr.Length;)
                    {
                        for (int t = 0; t < i + 1; t++)
                        {
                            if ((j + t) < arr.Length)
                            {
                                int aaaa = arr[j + t];
                                even += arr[j + t];
                            }
                        }
                        j += 2 * next;
                    }
                    if ((even - 5) % 2 == 0)
                    {
                        arr[i] = 0;
                    }
                    else
                    {
                        arr[i] = 1;
                    }
                    forlog2++;
                }
            }
            Console.WriteLine("Кодовое слово после добавления контрольных разрядов: ");
            int ggg = 0;
            int ff = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if ((double)ggg == Math.Log(i + 1, 2))
                {
                    ggg++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(arr[i] + " ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(arr[i] + " ");
                    ff++;
                }
            }
            Console.ReadKey();
        }
    }
}
