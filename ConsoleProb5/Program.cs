using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProb5
{
    class Program
    {
        static int TARGET_SUM = 100;
        static int[] VALUES = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        static void Main(string[] args)
        {
            // root node of tree
            Tree root = new Tree();
            root.Value = VALUES[0];

            // help to create ternary tree
            ArrayList arr = new ArrayList();
            arr.Add(root);
                        
            for (int i = 1; i < VALUES.Length; i++)
            {
                foreach (Tree item in arr.ToArray())
                {
                    // create three child for each node of tree
                    // add each child to helper array for repeating next
                    item.ConcatNode = new Tree()
                    {
                        Value = VALUES[i],
                        Sign = "."
                    };
                    arr.Add(item.ConcatNode);

                    item.MinusNode = new Tree()
                    {
                        Value = VALUES[i],
                        Sign="-"
                    };
                    arr.Add(item.MinusNode);

                    item.PlusNode = new Tree()
                    {
                        Value = VALUES[i],
                        Sign="+"
                    };
                    arr.Add(item.PlusNode);

                    // delete node whose children were created
                    arr.Remove(item);
                }
            }

            // traverse tree, start from root
            Show(root, new ArrayList());

            Console.ReadKey();
        }

        // traverse tree
        public static void Show(Tree node, ArrayList path)
        {
            path.Add(node);

            if (node.PlusNode != null)
                Show(node.PlusNode, path);

            if (node.MinusNode != null)
                Show(node.MinusNode, path);

            if (node.ConcatNode != null)
                Show(node.ConcatNode, path);

            if (IsLeaf(node))
            {
                if(CheckSum(path))
                    ShowPath(path);                
            }

            path.RemoveAt(path.Count - 1);

        }

        // check node if that is leaf node in tree
        private static bool IsLeaf(Tree node)
        {
            if (node.ConcatNode == null && node.MinusNode == null && node.PlusNode == null)
                return true;
            return false;
        }

        // show a branch of tree
        private static void ShowPath(ArrayList path)
        {
            foreach (Tree item in path)
            {
                if(item.Sign == ".")
                    Console.Write(item.Value);
                else
                    Console.Write(item.Sign  + item.Value);
            }
            Console.WriteLine();
        }

        // check branch if sum of nodes equal to expected sum value
        public static bool CheckSum(ArrayList branch)
        {
            int sum = 0;
            ArrayList p = new ArrayList();

            // clone array for values and no referenses
            foreach (Tree item in branch)
            {
                p.Add(
                        new Tree()
                        {
                            Value = item.Value,
                            Sign = item.Sign
                        }
                    );
            }

            // integrating nodes in array that has a concat operator
            for(int i=0; i<p.Count;i++)
            {                
                if((p[i] as Tree).Sign == ".")
                {
                    Tree t = p[i - 1] as Tree;
                    t.Value=int.Parse((p[i-1] as Tree).Value.ToString()+(p[i] as Tree).Value.ToString());
                    p.RemoveAt(i--);
                }
            }

            //calculate sum of array and check it
            foreach (Tree item in p)
            {
                sum += (item.Value * int.Parse(item.Sign?.ToString() + "1"));
            }

            if (sum == TARGET_SUM)
                return true;
            else
                return false;
        }


    }
}
