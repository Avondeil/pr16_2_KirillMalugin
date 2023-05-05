using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prakt16_zad3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Сколько элементов будет вводится в массив?: "); int el = int.Parse(Console.ReadLine());
                double[] Array = new double[el];
                //Ввод элементов в массив
                for (int i = 0; i < Array.Length; i++)
                {
                    Console.Write($"Введите {i + 1} элемент: ");
                    Array[i] = double.Parse(Console.ReadLine());
                }
                var dupl = Array.GroupBy(x => x).ToDictionary(a => a.Key, a => a.Count());
                //Вывод частоты введенных элементов в массиве
                Console.WriteLine("Вывод частоты элементов в массиве:");
                foreach (var povt in dupl)
                {
                    Console.WriteLine("{0}-{1}", povt.Key, povt.Value);
                }
                //Вывод (число в массиве*на его частоту)
                Console.WriteLine("Вывод (число в массиве*на его частоту):");
                foreach (var povt in dupl)
                {
                    Console.WriteLine("{0}-{1}", povt.Key*povt.Value, povt.Value);
                }
            }
            catch {
                Console.WriteLine("Некорректный ввод данных!");
            }
            Console.ReadKey();
        }
    }
}
