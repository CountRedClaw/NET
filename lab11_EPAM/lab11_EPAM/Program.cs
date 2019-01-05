using System;


namespace lab11_EPAM
{
    class Program
    {
        static void Main(string[] args)
        {
            var binaryTree1 =
                new BinarySearchTree<Test>(new Test[]
                {
                    new Test("Vasya", "title", 5, 250606),
                    new Test("Pete", "title", 3, 250606),
                    new Test("Petr", "title", 2, 250606),
                    new Test("Fedya", "title", 4, 250606),
                    new Test("Ben", "title", 6, 250606),
                    new Test("Tyrell", "title", 7, 250606)
                });

            foreach (Test b in binaryTree1.InOrder())
                Console.Write(b + "\n");

            Console.Write("\n");

            var binaryTree2 =
                new BinarySearchTree<Test>(new Test[]
                {
                    new Test("Tyrell", "title", 1, 250606),
                    new Test("Ben", "title", 2, 250606),
                    new Test("Pete", "title", 5, 250606),
                    new Test("Petr", "title", 3, 250606),
                    new Test("Fedya", "title", 4, 250606),
                    new Test("Pig", "title", 4, 250606)
                }, new CompareByStudent());

            foreach (Test b in binaryTree2.InOrder())
                Console.Write(b + "\n");

            int p = 5;
            Console.WriteLine(p);

            var binaryTree3 =
                new BinarySearchTree<int>(new int[]
                {
                    5, 3, 2, 4, 6, 7
                });

            foreach (Int32 b in binaryTree3.InOrder())
                Console.Write(b + "\n");

            Console.ReadKey();
        }
    }
}
