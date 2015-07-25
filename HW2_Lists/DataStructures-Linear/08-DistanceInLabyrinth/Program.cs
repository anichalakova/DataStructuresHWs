namespace _08_DistanceInLabyrinth
{
    using System;
    class Program
    {
        // TODO: Change the algorithm using Queue to enqueue and process adjacent matrix nodes

        private static int rows = 10;
        private static int columns = 10;
        private static string[,] matrix = new string[rows,columns];
        private static bool isFinished = false;

        static void Main()
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            InitalizeArray();
            

            FillDistancesInArray();
            
            Console.WriteLine("Distances:");
            Console.WriteLine();
            PrintMatrix(defaultColor);
        }

        private static void FillDistancesInArray()
        {
            while (!isFinished)
            {
                isFinished = true;
                CalculateDistances();
            }

            MarkUnreachableCells();
        }

        private static void CalculateDistances()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (IsEmptyCell(i, j))
                    {
                        int counter = 0;
                        CheckAbove(counter, i, j);
                        CheckRight(counter, i, j);
                        CheckBelow(counter, i, j);
                        CheckLeft(counter, i, j);
                    }
                }
            }
        }

        private static void MarkUnreachableCells()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (IsEmptyCell(i, j))
                    {
                        matrix[i, j] = "U";
                    }
                }
            }
        }

        private static void CheckAbove(int counter, int row, int column)
        {
            if (row < rows-1)
            {
                string above = matrix[row+1, column];
                switch (above)
                {
                    case "x":
                        break;
                    case "0":
                        break;
                    case "*":
                        {
                            matrix[row, column] = "1";
                            counter++;
                            isFinished = false;
                            break;
                        }
                    default:
                    {
                        var aboveCounter = int.Parse(above);
                        if ((counter == 0)||(aboveCounter + 1 < counter))
                        {
                            counter = aboveCounter + 1;
                            matrix[row, column] = (counter).ToString();
                            isFinished = false;
                        }
                        break;
                    }
                }
            }
        }

        private static void CheckBelow(int counter, int row, int column)
        {
            if (row > 0)
            {
                string below = matrix[row -1, column];
                switch (below)
                {
                    case "x":
                        break;
                    case "0":
                        break;
                    case "*":
                        {
                            matrix[row, column] = "1";
                            counter++;
                            isFinished = false;
                            break;
                        }
                    default:
                      var belowCounter = int.Parse(below);
                      if ((counter == 0) || (belowCounter + 1 < counter))
                        {
                            counter = belowCounter + 1;
                            matrix[row, column] = (counter).ToString();
                            isFinished = false;
                            
                        }
                        break;
                }
            }
        }

        private static void CheckRight(int counter, int row, int column)
        {
            if (column < columns - 1)
            {
                string right = matrix[row, column+1];
                switch (right)
                {
                    case "x":
                        break;
                    case "0":
                        break;
                    case "*":
                        {
                            matrix[row, column] = "1";
                            isFinished = false;
                            counter++;
                            break;
                        }
                    default:
                        var rightCounter = int.Parse(right);
                        if ((counter == 0) || (rightCounter + 1 < counter))
                        {
                            counter = rightCounter + 1;
                            matrix[row, column] = (counter).ToString();
                            isFinished = false;
                        }
                        break;
                }
            }
        }

        private static void CheckLeft(int counter, int row, int column)
        {
            if (column > 0)
            {
                string left = matrix[row, column -1];
                switch (left)
                {
                    case "x":
                        break;
                    case "0":
                        break;
                    case "*":
                        {
                            matrix[row, column] = "1";
                            isFinished = false;
                            counter++;
                            break;
                        }
                    default:
                        var leftCounter = int.Parse(left);
                        if ((counter == 0) || (leftCounter + 1 < counter))
                        {
                            counter = leftCounter + 1;
                            matrix[row, column] = (counter).ToString();
                            isFinished = false;
                        }
                        break;
                }
            }
        }

        private static void InitalizeArray()
        {
            Random rnd = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                        matrix[i, j] = "0";
                }
            }

            for (int i = 0; i < rows*columns/3; i++)
            {
                        int randomColumn = rnd.Next(0, columns);
                        int randomRow = rnd.Next(0, rows);
                        matrix[randomRow, randomColumn] = "x";
            }

            int randomNumber2 = rnd.Next(0, rows);
            int randomNumber3 = rnd.Next(0, columns);
            matrix[randomNumber2, randomNumber3] = "*";
        }

        private static void PrintMatrix(ConsoleColor defaultColor)
        {
            for (int i = 0; i < rows; i++)
            {
                Console.Write("   ");
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i,j].Length>1)
                    {
                        ChangeColor(matrix[i,j], defaultColor);
                        Console.Write(matrix[i, j] + "   ");
                    }
                    else
                    {
                        ChangeColor(matrix[i, j], defaultColor);
                        Console.Write(matrix[i, j] + "    ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private static bool IsEmptyCell(int row, int column)
        {
            if (matrix[row, column] != "0")
            {
                return false;
            }
            return true;
        }

        private static void ChangeColor(string value, ConsoleColor defaultColor)
        {
            switch (value)
            {
                case "x": Console.ForegroundColor = ConsoleColor.Red; break;
                case "*": Console.ForegroundColor = ConsoleColor.Yellow; break;
                case "U": Console.ForegroundColor = ConsoleColor.DarkMagenta; break;
                default: Console.ForegroundColor = defaultColor; break;
            }
        }
    }
}
