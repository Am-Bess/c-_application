class Program
{
    static void Calculator_GotResult(object? sender, EventArgs e)
    {
        if (sender is Calculator calculator)
        {
            Console.WriteLine($"Ответ = {calculator.Result}");
        }
    }

    public static void Main(string[] args)
    {
        ICalculator Calculator = new Calculator();
        Calculator.GotResult += Calculator_GotResult;


        Console.WriteLine("Введите стартовое число");
        Calculator.Result = Convert.ToInt32(Console.ReadLine());

        while (true)
        {
            Console.WriteLine("Введите последовательно действие (+ - / *) и число \n" +
                "Для выхода введите \"STOP\" или нажмите \"Enter\", " +
                "\"CANCEL\" для отметы последнего результата");


            string? input = Console.ReadLine();
            if (input?.ToUpper() == "STOP" || string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            switch (input)
            {
                case "+":
                    {
                        int number = Convert.ToInt32(Console.ReadLine());
                        Calculator.Sum(number);
                        break;
                    }
                case "-":
                    {
                        int number = Convert.ToInt32(Console.ReadLine());
                        Calculator.Divide(number);
                        break;
                    }
                case "*":
                    {
                        int number = Convert.ToInt32(Console.ReadLine());
                        Calculator.Multiplay(number);
                        break;
                    }
                case "/":
                    {
                        int number = Convert.ToInt32(Console.ReadLine());
                        Calculator.Divide(number);
                        break;
                    }
                case "CANCEL":
                    {
                        Calculator.CancelLast();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Вы ошиблис, Попробуйте снова!");
                        break;
                    }
            }
        }
    }
}