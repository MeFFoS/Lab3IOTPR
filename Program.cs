using System;

namespace Lab3IOTPR
{
    public class MatrixItem
    {
        public bool[,] Matrix { get; set; }
        public int N;
        public MatrixItem[,] Next { get; set; }
        public MatrixItem Previous { get; set; }
    }

    public class Matrix
    {
        public MatrixItem Item;
        public bool IsEmpty { get { return Item == null; } }
        public Matrix()
        {
            Console.Write("Введите размерность матрицы: ");
            var n = Int32.Parse(Console.ReadLine());
            Item = new MatrixItem() { Matrix = new bool[n, n], N = n, Next = new MatrixItem[n, n], Previous = null };
            ShowMenu();
        }

        public void ShowMatrix()
        {
            Console.Clear();
            Console.WriteLine("Матрица смежности: \n");
            for (var i = 0; i < Item.N; i++)
            {
                for (int j = 0; j < Item.N; j++)
                {
                    Console.Write(" " + Convert.ToInt32(Item.Matrix[i, j]));
                }
                Console.WriteLine();
            }
        }
        public void ShowMenu()
        {
            while(true)
            {
                ShowMatrix();
                Console.WriteLine("\nВыберите действие: \n" +
                                  "1. Добавить связь\n" +
                                  "2. Добавить подграф\n" +
                                  "3. Провалиться в вершину\n" +
                                  "4. Вернуться в предыдущий граф\n");
                var choice = Int32.Parse(Console.ReadLine()); ;
                switch (choice)
                {
                    case 1:
                        AddBond();
                        break;
                    case 2:
                        AddGraf();
                        break;
                    case 3:
                        NextGraf();
                        break;
                    case 4:
                        PreviousGraf();
                        break;
                }
            }
        }
        public void AddBond()
        {
            ShowMatrix();
            Console.Write("\nУкажите координату по вертикали: ");
            var i = Int32.Parse(Console.ReadLine()) - 1;
            Console.Write("Укажите координату по горизонтали: ");
            var j = Int32.Parse(Console.ReadLine()) - 1;

            Item.Matrix[i, j] = true;
        }

        public void AddGraf()
        {
            ShowMatrix();
            Console.Write("\nУкажите координату по вертикали: ");
            var i = Int32.Parse(Console.ReadLine()) - 1;
            Console.Write("Укажите координату по горизонтали: ");
            var j = Int32.Parse(Console.ReadLine()) - 1;
            Console.Write("Введите размерность матрицы: ");
            var n = Int32.Parse(Console.ReadLine());

            Item.Next[i, j] = new MatrixItem() { Matrix = new bool[n, n], N = n, Next = new MatrixItem[n, n], Previous = Item };
            Item = Item.Next[i, j];
        }

        private void PreviousGraf()
        {
            Item = Item.Previous;
            ShowMatrix();
        }
        private void NextGraf()
        {
            ShowMatrix();
            Console.Write("\nУкажите координату по вертикали: ");
            var i = Int32.Parse(Console.ReadLine()) - 1;
            Console.Write("Укажите координату по горизонтали: ");
            var j = Int32.Parse(Console.ReadLine()) - 1;
            Item = Item.Next[i, j];
        }

    }


    public class Program
    {
        static void Main()
        {
            var GhiperCub = new Matrix();
        }
    }
}


