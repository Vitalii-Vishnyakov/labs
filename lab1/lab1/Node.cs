using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    public class Node : InterfaceNode
    {
        
            public int data;
            public Node left;
            public Node right;
            public Node(int data)
            {
                this.data = data;
            }
        
    }
}
