using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            MyBinaryTree tree = new MyBinaryTree();

            /*********************/
            /**** Test Case 1 ****/
            /*********************/
            Console.WriteLine("\n## TC1: Build the following tree ###");
            //               1 (root)
            //       ┏━━━━━━━┻━━━━━━━┓
            //       2               3
            //   ┏━━━┻━━━┓       ┏━━━┻━━━┓
            //   4       2       6       n
            // ┏━┻━┓   ┏━┻━┓   ┏━┻━┓   
            // n   7   n   n   n   n 
            //    ┏┻┓              
            //    n n
            tree.Root = new MyBinaryTreeNode(1);
            tree.Root.Left = new MyBinaryTreeNode(2);
            tree.Root.Left.Left = new MyBinaryTreeNode(4);
            tree.Root.Left.Left.Right = new MyBinaryTreeNode(7);
            tree.Root.Left.Right = new MyBinaryTreeNode(2);
            tree.Root.Right = new MyBinaryTreeNode(3);
            tree.Root.Right.Left = new MyBinaryTreeNode(6);
            tree.Dump();
            Console.WriteLine("### End Of TC1 ###\n");

            /*********************/
            /**** Test Case 2 ****/
            /*********************/
            Console.WriteLine("\n## TC2: Traverse tree use in-order ###");
            tree.Traversal(MyBinaryTree.TraversalOrder.PreOrder);
            Console.WriteLine("### End Of TC2 ###\n");

            /*********************/
            /**** Test Case 3 ****/
            /*********************/
            Console.WriteLine("\n## TC3: Traverse tree use in-order ###");
            tree.Traversal(MyBinaryTree.TraversalOrder.InOrder);
            Console.WriteLine("### End Of TC3 ###\n");

            /*********************/
            /**** Test Case 4 ****/
            /*********************/
            Console.WriteLine("\n## TC4: Traverse tree use in-order ###");
            tree.Traversal(MyBinaryTree.TraversalOrder.PostOrder);
            Console.WriteLine("### End Of TC4 ###\n");


            /*********************/
            /**** Test Case 5 ****/
            /*********************/
            Console.WriteLine("\n## TC5: Search tree use pre-order ###");
            MyBinaryTree newTree = new MyBinaryTree();
            newTree.Root = tree.Search(2, MyBinaryTree.TraversalOrder.PreOrder);
            newTree.Dump();
            Console.WriteLine("### End Of TC5 ###\n");

            /*********************/
            /**** Test Case 6 ****/
            /*********************/
            Console.WriteLine("\n## TC5: Search tree use in-order ###");
            newTree = new MyBinaryTree();
            newTree.Root = tree.Search(2, MyBinaryTree.TraversalOrder.InOrder);
            newTree.Dump();
            Console.WriteLine("### End Of TC5 ###\n");

            /*********************/
            /**** Test Case 7 ****/
            /*********************/
            Console.WriteLine("\n## TC5: Search tree use post-order ###");
            newTree = new MyBinaryTree();
            newTree.Root = tree.Search(2, MyBinaryTree.TraversalOrder.PostOrder);
            newTree.Dump();
            Console.WriteLine("### End Of TC5 ###\n");
        }
    }
}
