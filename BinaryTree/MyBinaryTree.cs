using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    
    // tree class hold the root node of the tree, and provide operations
    class MyBinaryTree
    {
        public enum TraversalOrder
        {
            PreOrder,
            InOrder,
            PostOrder
        }
        public MyBinaryTreeNode Root;

        public MyBinaryTree ()
        {
            this.Root = null;
        }

        // Method: Cut
        // Description: Search for the given element and cut the tree. 
        //              The given element become the root of the new tree
        // Parameters: 
        //    element: the element to cut from
        // Return value: 
        //    return the new tree
        public MyBinaryTree Cut (MyBinaryTreeNode element)
        {
            MyBinaryTree subTree = new MyBinaryTree();

            return subTree;
        }

        // Method: Search
        // Description: Search for the given value and return the first element found,
        //              using specified order
        // Parameters: 
        //    value: the value of element to be searched
        //    order: the traversals order used in search
        // Return value: 
        //    return the first emelment found, or null
        public MyBinaryTreeNode Search(int value, TraversalOrder order)
        {
            MyBinaryTreeNode node = null;
            switch (order)
            {
                case TraversalOrder.PreOrder:
                    SearchPreOrder(this.Root, value, ref node);
                    break;
                case TraversalOrder.InOrder:
                    SearchInOrder(this.Root, value, ref node);
                    break;
                case TraversalOrder.PostOrder:
                    SearchPostOrder(this.Root, value, ref node);
                    break;
                default:
                    break;
            }
            
            return node;
        }
        private void SearchPreOrder(MyBinaryTreeNode node, int value, ref MyBinaryTreeNode targetNode)
        {
            if (node != null && targetNode == null)
            {
                // Console.WriteLine($"searching: {node.Data} for {value}");
                if (node.Data != value)
                {
                    this.SearchPreOrder(node.Left, value, ref targetNode);
                    if (targetNode == null)
                    {
                        this.SearchPreOrder(node.Right, value, ref targetNode);
                    }
                }
                else
                {
                    // Console.WriteLine($"found!");
                    targetNode = node;
                }
            }
            else
            {
                // Console.WriteLine($"node: {node==null} and {targetNode==null}");
            }
            return;
        }
        private void SearchInOrder(MyBinaryTreeNode node, int value, ref MyBinaryTreeNode targetNode)
        {
            if (node != null && targetNode == null)
            {
                //Console.WriteLine($"searching: {node.Data} for {value}");
                this.SearchInOrder(node.Left, value, ref targetNode);
                if (targetNode == null)
                {
                    if (node.Data != value)
                    {
                        if (targetNode == null)
                        {
                            this.SearchInOrder(node.Right, value, ref targetNode);
                        }
                    }
                    else
                    {
                        //Console.WriteLine($"found!");
                        targetNode = node;
                    }
                }
            }
            else
            {
                //Console.WriteLine($"node: {node==null} and {targetNode==null}");
            }
            return;
        }

        private void SearchPostOrder(MyBinaryTreeNode node, int value, ref MyBinaryTreeNode targetNode)
        {
            if (node != null && targetNode == null)
            {
                // Console.WriteLine($"searching: {node.Data} for {value}");
                if (targetNode == null)
                {
                    this.SearchPostOrder(node.Left, value, ref targetNode);
                    if (targetNode == null)
                    {
                        this.SearchPostOrder(node.Right, value, ref targetNode);
                    }
                }
                if (targetNode == null)
                {
                    if (node.Data != value)
                    {

                    }
                    else
                    {
                        // Console.WriteLine($"found!");
                        targetNode = node;
                    }
                }
                    
            }
            else
            {
                // Console.WriteLine($"node: {node==null} and {targetNode==null}");
            }
            return;
        }


        public void Traversal (TraversalOrder order)
        {
            switch (order)
            {
                case TraversalOrder.PreOrder:
                    TraversalPreOrder(this.Root);
                    break;
                case TraversalOrder.InOrder:
                    TraversalInOrder(this.Root);
                    break;
                case TraversalOrder.PostOrder:
                    TraversalPostOrder(this.Root);
                    break;
                default:
                    break;
            }
            Console.Write("\n");
            return;
        }

        private void TraversalPreOrder(MyBinaryTreeNode node)
        {
            if (node != null)
            {
                Console.Write($"{node.Data} -> ");
                TraversalPreOrder(node.Left);
                TraversalPreOrder(node.Right);
            }
            return;
           
        }
        private void TraversalInOrder(MyBinaryTreeNode node)
        {
            if (node != null)
            {
                TraversalInOrder(node.Left);
                Console.Write($"{node.Data} -> ");
                TraversalInOrder(node.Right);
            }
            return;
        }
        private void TraversalPostOrder(MyBinaryTreeNode node)
        {
            if (node != null)
            {
                TraversalPostOrder(node.Left);
                TraversalPostOrder(node.Right);
                Console.Write($"{node.Data} -> ");
            }
            return;
        }

        // Method: Dump
        // Description: Dump the tree by calling PrintTree against root
        public void Dump()
        { 
            this.PrintTree(this.Root, 0);
            return;
        }

        // Method: PrintTree
        // Description: Print a tree using following format
        //    ──  Root  1
        //          └──  left   2
        //                  ├──  left   4
        //                  │    ├──  left   null
        //                  │    └──  right  10
        //                  │         ├──  left   null
        //                  │         └──  right  null
        //                  └──  right  5
        //                       ├──  left   null
        //                       └──  right  null
        // Parameters: 
        //      node:   root node of subtree
        //      role:   0 - root; -1 - left; 1 - right
        //      indent: indicate the level of tree, no need to set this 
        private void PrintTree(MyBinaryTreeNode node, int role, string indent = "")
        {
            string prefix = "";
            switch (role)
            {
                case 0: // root node
                    prefix = "──  Root ";
                    break;
                case -1: // left node
                    prefix = indent + "├──  left  ";
                    break;
                case 1: // right node
                    prefix = indent + "└──  right ";
                    break;
                default:
                    break;
            }
            if (role != 0)
            {
                Console.WriteLine($"{indent}│");
            }
            if (node == null)
            {
                Console.WriteLine($"{prefix} null");
            }
            else
            {
                Console.WriteLine($"{prefix} {node.Data}");
                string padding = (role == -1) ? "│    " : "     ";

                this.PrintTree(node.Left, -1, indent + padding);
                this.PrintTree(node.Right, 1, indent + padding);
            }
            
            //log.debug(prefix + nodeConnection + nodeName);
            return;
        }
    }


    // Node of tree
    class MyBinaryTreeNode
    {
        public int Data;
        public MyBinaryTreeNode Left;
        public MyBinaryTreeNode Right;

        public MyBinaryTreeNode()
        {
            this.Data = 0;
            this.Left = null;
            this.Right = null;
        }
        public MyBinaryTreeNode(int value)
        {
            this.Data = value;
            this.Left = null;
            this.Right = null;
        }
    }
}
