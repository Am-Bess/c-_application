public class Program
{
    static void Main(string[] args)
    {

        int[,] labirynth = new int[,]
        {
            {1, 1, 1, 0, 1, 1, 1 },
            {1, 0, 0, 0, 0, 0, 1 },
            {1, 0, 1, 1, 1, 0, 1 },
            {0, 0, 0, 0, 1, 0, 0 },
            {1, 1, 0, 0, 1, 1, 1 },
            {1, 1, 1, 0, 1, 1, 1 },
            {1, 1, 1, 0, 1, 1, 1 }
        };

        Console.WriteLine($"Количество выходов = {HasExit(1, 1)}");

        int HasExit(int startX, int startY)
        {
            Stack<Tuple<int, int>> path = new Stack<Tuple<int, int>>();

            if (labirynth[startX, startY] == 0) path.Push(new(startX, startY));
            int exitCount = 0;

            while (path.Count > 0)
            {
                var current = path.Pop();

                if (isExit(current.Item1, current.Item2))
                    exitCount++;

                labirynth[current.Item1, current.Item2] = 1;

                if (current.Item1 + 1 < labirynth.GetLength(0)
                && labirynth[current.Item1 + 1, current.Item2] != 1)
                    path.Push(new(current.Item1 + 1, current.Item2));

                if (current.Item2 + 1 < labirynth.GetLength(1) &&
                labirynth[current.Item1, current.Item2 + 1] != 1)
                    path.Push(new(current.Item1, current.Item2 + 1));

                if (current.Item1 > 0 && labirynth[current.Item1 - 1, current.Item2] != 1)
                    path.Push(new(current.Item1 - 1, current.Item2));

                if (current.Item2 > 0 && labirynth[current.Item1, current.Item2 - 1] != 1)
                    path.Push(new(current.Item1, current.Item2 - 1));
            }
            return exitCount;
        }

        bool isExit(int x, int y)
        {
            if (x == 0 | y == 0) return true;
            if (x + 2 > labirynth.GetLength(0) | y + 2 > labirynth.GetLength(1)) return true;
            else return false;
        }
    }
}
