using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    interface InterfaceAVL
    {

        public void DisplayTreeInFile();
        public void Add(int data);
       
        private Node RecursiveInsert(Node current, Node newItem)
        {
           
            return current;
        }
        private Node Balance_tree(Node current)
        {
            
            return current;
        }
        public void Delete(int target);
        
            
        
        private Node Delete(Node current, int target)
        {
            
            return current;
        }

        public void DisplayTree();
        



        private void InOrderDisplayTree(Node current, int currentHeight)
        {
        }

        public int max(int l, int r)
        {
            return 0;
        }
        public int getHeight(Node current)
        {           
            return 0;
        }
        private int Balance_factor(Node current)
        {
            
            return 0;
        }
        private Node RotateRR(Node parent)
        {
            
            return parent;
        }
        private Node RotateLL(Node parent)
        {
            
            return parent;
        }
        private Node RotateLR(Node parent)
        {
            
            return RotateLL(parent);
        }
        private Node RotateRL(Node parent)
        {
            
            return RotateRR(parent);
        }
    }

}
