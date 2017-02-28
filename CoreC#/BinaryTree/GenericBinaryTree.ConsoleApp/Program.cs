using GenericBinaryTree.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBinaryTree.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>(50);

            tree.Add(10);
            tree.Add(75);

            foreach (var item in tree)
            {
                Console.WriteLine(item);
            }
        }
    }
}
