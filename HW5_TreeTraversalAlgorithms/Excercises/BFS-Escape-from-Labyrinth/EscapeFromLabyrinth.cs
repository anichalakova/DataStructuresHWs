using System;
using System.Collections.Generic;
using Escape_from_Labyrinth;

public class EscapeFromLabyrinth
{
    private static int width = 9;
    private static int height = 7;
    private static char[,] labyrinth;
    private const char visitedCell = 'v';

    static char[,] ReadLabyrinth()
    {
        width = int.Parse(Console.ReadLine());
        height = int.Parse(Console.ReadLine());
        labyrinth = new char[height,width];
        for (int i = 0; i < height; i++)
        {
            string currentRow = Console.ReadLine();
            for (int j = 0; j < width; j++)
            {
                var charArray = currentRow.ToCharArray();
                labyrinth[i,j] = charArray[j];
            }
        }
        return labyrinth;
    }
    static string FindShortestPathToExit()
    {
        var queue = new Queue<Point>();
        var startPosition = FindStartPosition();
        if (startPosition == null)
        {
            return null;
        }

        queue.Enqueue(startPosition);
        while (queue.Count > 0)
        {
            var currentCell = queue.Dequeue();
            if (IsExit(currentCell))
            {
                return TracePathBack(currentCell);
            }

            TryDirection(queue, currentCell, "U", 0, -1);
            TryDirection(queue, currentCell, "R", 1, 0);
            TryDirection(queue, currentCell, "D", 0, 1);
            TryDirection(queue, currentCell, "L", -1, 0);
        }

        return null;
    }

    static Point FindStartPosition()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y  = 0; y  < height; y ++)
            {
                if (labyrinth[y,x] == 's')
                {
                    return new Point(x, y, null, null);
                }
            }
        }
        return null;
    }

    static bool IsExit(Point currentPoint)
     {
        if (currentPoint.X == 0 
            || currentPoint.X == width - 1 
            || currentPoint.Y == 0
            || currentPoint.Y == height - 1)
        {
            return true;
        }

        return false;
    }

    static string TracePathBack(Point currentPoint)
    {
        var path = new Stack<string>();
        while (currentPoint.PreviousPoint != null)
        {
            path.Push(currentPoint.Direction);
            currentPoint = currentPoint.PreviousPoint;
        }

        var pathString = string.Join("", path.ToArray());
        return pathString;
    }

    static void TryDirection(Queue<Point> queue, Point currentCell, string direction, int xOffset, int yOffset)
    {
        var newX = currentCell.X + xOffset;
        var newY = currentCell.Y + yOffset;
        if (newX < width
            && newY <height
            && labyrinth[newY,newX] == '-')
        {
            var nextPoint = new Point(newX, newY, direction, currentCell);
            labyrinth[newY, newX] = visitedCell;
            queue.Enqueue(nextPoint);
        }
    }

    public static void Main()
    {
        ReadLabyrinth();
        string shortestPath = FindShortestPathToExit();
        if (shortestPath == null)
        {
            Console.WriteLine("No exit!");
        }
        else if (shortestPath == "")
        {
            Console.WriteLine("Start is at the exit.");
        }
        else
        {
            Console.WriteLine("Shortest exit: " + shortestPath);
        }
    }
}
