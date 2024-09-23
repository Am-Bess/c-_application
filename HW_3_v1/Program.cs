public class Program
{
    static void Main(string[] args)
    {

        int[,] labirynth = new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1 },
            {1, 0, 0, 0, 0, 0, 1 },
            {1, 0, 1, 1, 1, 0, 1 },
            {2, 0, 0, 0, 1, 0, 2 },
            {1, 1, 0, 0, 1, 1, 1 },
            {1, 1, 1, 0, 1, 1, 1 },
            {1, 1, 1, 2, 1, 1, 1 }
        };

        Console.WriteLine($"Количество выходов = {HasExit(1, 1, labirynth)}");

        int HasExit(int startX, int startY, int[,] l)
        {
            Stack<Tuple<int, int>> path = new Stack<Tuple<int, int>>();

            if (l[startX, startY] == 0) path.Push(new(startX, startY));
            int exitCount = 0;

            while (path.Count > 0)
            {
                var current = path.Pop();

                if (l[current.Item1, current.Item2] == 2)
                    exitCount++;

                l[current.Item1, current.Item2] = 1;

                if (current.Item1 + 1 < l.GetLength(0)
                && l[current.Item1 + 1, current.Item2] != 1)
                    path.Push(new(current.Item1 + 1, current.Item2));

                if (current.Item2 + 1 < l.GetLength(1) &&
                l[current.Item1, current.Item2 + 1] != 1)
                    path.Push(new(current.Item1, current.Item2 + 1));

                if (current.Item1 > 0 && l[current.Item1 - 1, current.Item2] != 1)
                    path.Push(new(current.Item1 - 1, current.Item2));

                if (current.Item2 > 0 && l[current.Item1, current.Item2 - 1] != 1)
                    path.Push(new(current.Item1, current.Item2 - 1));
            }
            return exitCount;
        }
    }
}
