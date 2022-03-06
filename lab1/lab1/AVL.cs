using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace lab1
{
    public class AVL : InterfaceAVL
    {


        List<string> arrForPrint = new List<string>();
        public Node root;
        public void Add(int data)
        {
            Node newItem = new Node(data);
            if (root == null)
            {
                root = newItem;
            }
            else
            {
                root = RecursiveInsert(root, newItem);
            }
        }
        private Node RecursiveInsert(Node current, Node newItem)
        {
            if (current == null)
            {
                current = newItem;
                return current;
            }
            else if (newItem.data < current.data)
            {
                current.left = RecursiveInsert(current.left, newItem);
                current = BalanceTree(current);
            }
            else if (newItem.data > current.data)
            {
                current.right = RecursiveInsert(current.right, newItem);
                current = BalanceTree(current);
            }
            return current;
        }
        private Node BalanceTree(Node current)
        {
            int b_factor = BalanceRate(current);
            if (b_factor > 1)
            {
                if (BalanceRate(current.left) > 0)
                {
                    current = SmallRight(current);
                }
                else
                {
                    current = BigRight(current);
                }
            }
            else if (b_factor < -1)
            {
                if (BalanceRate(current.right) > 0)
                {
                    current = BigLeft(current);
                }
                else
                {
                    current = SmallLeft(current);
                }
            }
            return current;
        }
        public void Delete(int target)
        {
            root = Delete(root, target);
        }
        public Node Delete(Node current, int target)
        {
            Node parent;
            if (current == null)
            { return null; }
            else
            {
                //left subtree
                if (target < current.data)
                {
                    current.left = Delete(current.left, target);
                    if (BalanceRate(current) == -2)
                    {
                        if (BalanceRate(current.right) <= 0)
                        {
                            current = SmallLeft(current);
                        }
                        else
                        {
                            current = BigLeft(current);
                        }
                    }
                }
                //right subtree
                else if (target > current.data)
                {
                    current.right = Delete(current.right, target);
                    if (BalanceRate(current) == 2)
                    {
                        if (BalanceRate(current.left) >= 0)
                        {
                            current = SmallRight(current);
                        }
                        else
                        {
                            current = BigRight(current);
                        }
                    }
                }
                //if target is found
                else
                {
                    if (current.right != null)
                    {
                        
                        parent = current.right;
                        while (parent.left != null)
                        {
                            parent = parent.left;
                        }
                        current.data = parent.data;
                        current.right = Delete(current.right, parent.data);
                        if (BalanceRate(current) == 2)//rebalancing
                        {
                            if (BalanceRate(current.left) >= 0)
                            {
                                current = SmallRight(current);
                            }
                            else { current = BigRight(current); }
                        }
                    }
                    else
                    {   //if current.left != null
                        return current.left;
                    }
                }
            }
            return current;
        }
        
        public void DisplayTree()
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            arrForPrint = new List<string>();
            for (int i = 0; i < getHeight(root); i++)
            {
                arrForPrint.Add("");
            }

            InOrderDisplayTree(root, 0);
            Console.WriteLine();

            for (int i = 0; i < getHeight(root) ; i++)
            {
                //Console.Write(string.Concat(Enumerable.Repeat(" ", (4 - i) * 2)));
                //Console.WriteLine(arrForPrint[i]);
            }

            Console.WriteLine();
        }
        public void DisplayTreeInFile()
        {
            Console.WriteLine("Введите имя файла");
            string path=Console.ReadLine();
            if (root == null)
            {
                
                if (path.Length > 0)
                {
                    File.AppendAllText(path, "Tree is empty");
                }
                else
                {
                    Console.WriteLine("Ошибка команды");
                }

                return;
            }
            arrForPrint = new List<string>();
            for (int i = 0; i < getHeight(root); i++)
            {
                arrForPrint.Add("");
            }

            InOrderDisplayTree(root, 0);
            if (path.Length > 0) {
                File.AppendAllText(path, Environment.NewLine);
            }
            else
            {
                Console.WriteLine("Ошибка команды");
            }
            

            for (int i = 0; i < getHeight(root); i++)
            {
                File.AppendAllText(path, string.Concat(Enumerable.Repeat(" ", (4 - i) * 2)));
                File.AppendAllText(path, arrForPrint[i] + Environment.NewLine);
            }
            
            File.AppendAllText(path,  Environment.NewLine); 
            Console.WriteLine("Сделано");
        }



        private void InOrderDisplayTree(Node current, int currentHeight)

        {


            if (current != null)
            {
                arrForPrint[currentHeight] += current.data.ToString() + "  ";
                for (int i = 0; i < currentHeight; i++)
                {
                    Console.Write("-|");
                }
                
                Console.Write(current.data.ToString());
                Console.WriteLine();
                InOrderDisplayTree(current.left, currentHeight + 1);
                InOrderDisplayTree(current.right, currentHeight + 1);
                
            }


        }

        public int max(int l, int r)
        {
            return l > r ? l : r;
        }
        public int getHeight(Node current)
        {
            int height = 0;
            if (current != null)
            {
                int l = getHeight(current.left);
                int r = getHeight(current.right);
                int m = max(l, r);
                height = m + 1;
            }
            return height;
        }
        private int BalanceRate(Node current)
        {
            int l = getHeight(current.left);
            int r = getHeight(current.right);
            int b_factor = l - r;
            return b_factor;
        }
        private Node SmallLeft(Node parent)
        {
            Node pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;
            return pivot;
        }
        private Node SmallRight(Node parent)
        {
            Node pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;
            return pivot;
        }
        private Node BigRight(Node parent)
        {
            Node pivot = parent.left;
            parent.left = SmallLeft(pivot);
            return SmallRight(parent);
        }
        private Node BigLeft(Node parent)
        {
            Node pivot = parent.right;
            parent.right = SmallRight(pivot);
            return SmallLeft(parent);
        }
    }
}

