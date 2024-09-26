
class Program
{
    static void Main(string[] args)
    {
        //Дан массив и число. Найдите три числа в массиве сумма которых равна искомому числу.

        int[] arrInt = [2, 3, 7, 4, 0, -5, 5, 3, 0, 9, 15, -2, 4, 3, 6, 8, 11, 3, 17, 16, 1];
        int requiredNum = 9;

        List<int> resListInt = FindSum(arrInt, requiredNum);

        if (resListInt.Count > 0)
        {
            Console.Write($"{requiredNum} равно сумме ");
            resListInt.ForEach(p => Console.Write($"[{p}] "));
        }
        else
        {
            Console.WriteLine("Числа не найдены!");
        }
    }
    static List<int> FindSum(int[] inputArr, int requiredNum)
    {
        Array.Sort(inputArr);

        List<int> result = new List<int>();

        for (int i = 0; i < inputArr.Length - 2; i++)
        {
            int leftNum = i + 1;
            int rightNum = inputArr.Length - 1;

            while (leftNum < rightNum)
            {
                int sum = inputArr[i] + inputArr[leftNum] + inputArr[rightNum];

                if (sum == requiredNum)
                {
                    result.Add(inputArr[i]);
                    result.Add(inputArr[leftNum]);
                    result.Add(inputArr[rightNum]);
                    break;
                }
                else if (sum < requiredNum)
                    leftNum++;
                else
                    rightNum--;
            }

            if (result.Count > 0)
            {
                break;
            }
        }
        return result;
    }
}