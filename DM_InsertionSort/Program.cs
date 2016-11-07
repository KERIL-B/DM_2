using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_InsertionSort
{
    class Program
    {
        static Random rand = new Random();
        static void Main(string[] args)
        {
            Console.Title = "Insertion Sort";
            Random rand = new Random();

            #region Генерация массива
            Console.WriteLine("//////////////////////////////////////////////////////////////////");
            Console.WriteLine("////////////////////////// Insertion Sort ////////////////////////");
            Console.WriteLine("//////////////////////////////////////////////////////////////////");
            Console.WriteLine();
            Console.Write("Enter length of massive ->");
            bool tmp = false;
            int n = 0;

            do
            {
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                    tmp = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Incorrect length");
                    Console.Write("Enter length of massive ->");
                    tmp = true;
                }
            } while (tmp);

            int[] arr1 = new int[n];
            int[] arr2 = new int[n];

            Console.WriteLine();
            Console.WriteLine("Massive generating..");
            Console.WriteLine("Done.");
            Console.WriteLine();
            #endregion
            #region Инициализация количества повторений
            Console.Write("Enter number of repetitions ->");
            tmp = false;
            int repetitions = 0;
            do
            {
                try
                {
                    repetitions = Convert.ToInt32(Console.ReadLine());
                    tmp = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Incorrect number");
                    Console.Write("Enter number of repetitions ->");
                    tmp = true;
                }
            } while (tmp);
            Console.WriteLine("Correct.");
            Console.WriteLine();
            #endregion
            #region Эксперимент
            Console.WriteLine("Experiment in process..");
            int insertionSum = 0;
            int minInsertion = n * n + 1;
            int maxInsertion = 0;

            int binarySum = 0;
            int minBinary = n * n + 1;
            int maxBinary = 0;

            for (int i = 0; i < repetitions; i++)
            {

                arr1 = RandomGenerate(arr1);
                arr2 = arr1;

                int countI = InsertionSort(arr1);
                int countB = BinaryInsertionSort(arr2);

                insertionSum += countI;
                binarySum += countB;

                if (countI < minInsertion)
                    minInsertion = countI;
                if (countI > maxInsertion)
                    maxInsertion = countI;

                if (countB < minBinary)
                    minBinary = countB;
                if (countB > maxBinary)
                    maxBinary = countB;
            }

            Console.WriteLine("Done");
            #endregion
            #region Вывод результата
            Console.WriteLine();
            Console.WriteLine("============================  Resaults  ==========================");
            Console.WriteLine();
            Console.WriteLine("Number of actions in INSERTION SORT {0}", insertionSum / repetitions);
            Console.WriteLine("Number of actions in BINARY INSERTION SORT {0}", binarySum / repetitions);
            Console.WriteLine();
            Console.WriteLine("Min of actions in INSERTION SORT {0}", minInsertion);
            Console.WriteLine("Min of actions in BINARY INSERTION SORT {0}", minBinary);
            Console.WriteLine();
            Console.WriteLine("Max of actions in INSERTION SORT {0}", maxInsertion);
            Console.WriteLine("Max of actions in BINARY INSERTION SORT {0}", maxBinary);
            Console.ReadKey();
            #endregion
            Console.ReadKey();
        }

        static private int[] RandomGenerate(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(200) - 100;
            }
            return arr;
        }

        static private int InsertionSort(int[] arr)
        {
            int count = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                int j;
                int buf = arr[i];
                for (j = i - 1; j >= 0; j--)
                {
                    count++;
                    if (arr[j] < buf)
                        break;

                    arr[j + 1] = arr[j];
                }
                arr[j + 1] = buf;
            }
            return count;
        }

        public static int BinaryInsertionSort(int[] arr)
        {
            int count=0;
            for (int i = 0; i < arr.Length; i++)
            {
                int tmp = arr[i]; int left = 0; int right = i - 1;
                while (left <= right)
                {
                    int m = (left + right) / 2; //определение индекса среднего элемента
                    if (tmp < arr[m])
                        right = m - 1; // сдвиг правой
                    else left = m + 1; //или левой границы
                    count++;
                }

                for (int j = i - 1; j >= left; j--)
                {
                    arr[j + 1] = arr[j]; // сдвиг элементов
                   // count++;
                }

                arr[left] = tmp; // вставка элемента на нужное место
            }
            return count;
        }

        static private void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write("{0} ", arr[i]);
            Console.WriteLine();
        }
    }
}
