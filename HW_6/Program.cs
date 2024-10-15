class Program
{
    static void Calculator_GotResult(object? sender, EventArgs e)
    {
        if (sender is Calculator calculator)
        {
            Console.WriteLine($"Ответ = {calculator.Result}");
        }
    }
    static void Execute(Action<int> action, int value)
    {
        try
        {
            action.Invoke(value);
        }
        catch (CalculatorDivideByZeroException e)
        {
            Console.WriteLine(e);
        }
        catch (CalculateOperationCauseOverflowException e)
        {
            Console.WriteLine(e);
        }
    }

    static void Execute(Action<double> action, double value)
    {
        try
        {
            action.Invoke(value);
        }
        catch (CalculatorDivideByZeroException e)
        {
            Console.WriteLine(e);
        }
        catch (CalculateOperationCauseOverflowException e)
        {
            Console.WriteLine(e);
        }
    }
    static bool IsInt(string? number, out int number_int)
    {
        if (int.TryParse(number, out number_int))
        {
            return true;
        }
        return false;
    }

    static bool IsDouble(string? number, out double number_double)
    {
        if (double.TryParse(number, out number_double))
        {
            return true;
        }
        return false;
    }

    public static void Main(string[] args)
    {
        ICalculator calculator = new Calculator();
        calculator.GotResult += Calculator_GotResult;
        int number_int = 0;
        double number_double = 0;


        Console.Write("Введите стартовое число: ");
        calculator.Result = Convert.ToDouble(Console.ReadLine());

        while (true)
        {
            Console.WriteLine("Для выхода введите \"STOP\" или нажмите \"Enter\", " +
                " для отметы последнего результата \"CANCEL\"");

            Console.Write("Введите действие(+ - / *): ");
            string? input = Console.ReadLine();

            if (input?.ToUpper() == "STOP" || string.IsNullOrWhiteSpace(input))
            {
                return;
            }
            Console.Write("Введите число: ");
            var number = Console.ReadLine();

            switch (input)
            {
                case "+":
                    {
                        if (IsInt(number, out number_int))
                            Execute(calculator.SumInt, number_int);
                        else if (IsDouble(number, out number_double))
                            Execute(calculator.Sum, number_double);
                        break;
                    }
                case "-":
                    {
                        if (IsInt(number, out number_int))
                            Execute(calculator.Substruct, number_int);
                        else if (IsDouble(number, out number_double))
                            Execute(calculator.Substruct, number_double);

                        break;
                    }
                case "*":
                    {
                        if (IsInt(number, out number_int))
                            Execute(calculator.Multiplay, number_int);
                        else if (IsDouble(number, out number_double))
                            Execute(calculator.Multiplay, number_double);

                        break;
                    }
                case "/":
                    {
                        if (IsInt(number, out number_int))
                            Execute(calculator.Divide, number_int);
                        else if (IsDouble(number, out number_double))
                            Execute(calculator.Divide, number_double);

                        break;
                    }
                case "CANCEL":
                    {
                        calculator.CancelLast();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Вы ошиблись, Попробуйте снова!");
                        break;
                    }
            }
        }
    }
}