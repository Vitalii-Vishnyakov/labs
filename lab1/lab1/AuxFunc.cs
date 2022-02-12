using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace lab1
{
    class AuxFunc
        
    {
        public static void SayHello()
        {
            Console.WriteLine("Вишняков Виталий 405гр. вар. 3");
            Console.WriteLine(@"Реализовать AVL дерево, продемонстрировать
характерные особенности, реализовать возможность добавления и удаления элементов,
визуализировать дерево");
        }
        public static void ShowComand()
        {
            Console.WriteLine("Команды");
            Console.WriteLine("print");
            Console.WriteLine("add");
            Console.WriteLine("rand");
            Console.WriteLine("delete");
            Console.WriteLine("save");
            Console.WriteLine("file");
            Console.WriteLine("exit");
        }
        public static int GetInt()
        {
            int tmp = 0;
            Console.WriteLine("Введите целое число");
            while (!int.TryParse(Console.ReadLine(), out tmp))
            {
                Console.WriteLine("Ошибка ввода! Введите целое число");
            }
            return tmp;
        }
        public static int[] GetRandNums()
        {
            Random rnd = new Random();
            int len = rnd.Next(5, 15);
            int[] arr = new int[len];

            for (int i = 0; i < len; i ++)
            {
                arr[i]= rnd.Next(1,100);
            }

            return arr;
        }
        public static int[] GetDataFromFile()
        {
            Console.WriteLine("Введите имя файла");
            string path = Console.ReadLine();
            
            if (File.Exists(path))
            {
                try
                {
                    List<string> arr = new List<string>();
                    List<int> arrInt = new List<int>();
                    arr = File.ReadAllText(path).Split(' ').ToList();
                    for (int i = 0; i < arr.Count; i++)
                    {
                        int number;

                        bool success = int.TryParse(arr[i], out number);
                        if (success)
                        {
                            arrInt.Add(number);
                        }

                    }

                    return arrInt.ToArray();
                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка в данных");
                    return null;

                }
                
            }
            else
            {
                Console.WriteLine("Файл не найден");
                return null;
            }
                                             
        }
        

    }
}
