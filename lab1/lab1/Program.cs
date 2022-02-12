using System;
using System.Collections.Generic;
using System.Linq;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            AuxFunc.SayHello();
            AuxFunc.ShowComand();
            bool isWorking = true;
            AVL tree = new AVL();
            string currentComand = "";
            while (isWorking)
            {
                currentComand = Console.ReadLine().Trim();
                if (currentComand == "exit")
                {
                    isWorking = false;
                }
                else if (currentComand == "add") {
                    tree.Add(AuxFunc.GetInt());
                    tree.DisplayTree();
                }
                else if (currentComand == "delete") {
                    tree.Delete(AuxFunc.GetInt());
                    tree.DisplayTree();
                }
                else if (currentComand == "print") {
                    tree.DisplayTree();
                }
                else if (currentComand == "rand")
                {
                    int[] tmp = AuxFunc.GetRandNums();
                    for (int i = 0; i < tmp.Length; i++)
                    {
                        tree.Add(tmp[i]);
                    }
                    
                    tree.DisplayTree();
                }
                else if (currentComand == "save")
                {
                    tree.DisplayTreeInFile();
                }
                else if (currentComand == "file")
                {
                    int[] tmp = AuxFunc.GetDataFromFile();
                    if (tmp!= null) {
                        for (int i = 0; i < tmp.Length; i++)
                        {
                            tree.Add(tmp[i]);
                        }

                        tree.DisplayTree();
                    }
                    
                }
                else
                {
                    Console.WriteLine("Нет такой команды");
                }
            }
                     
        }
    }
 
}
