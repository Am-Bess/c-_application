internal class CalculatorException : Exception
{
    public Stack<CalculatorActionLog> ActionLogs { get; private set; } = new();
    public CalculatorException(string message, Stack<CalculatorActionLog> log) : base(message)
    {
        ActionLogs = log;
    }

    public CalculatorException(string message, Exception exception) : base(message, exception) { }

    public override string ToString()
    {
        return Message + " : " + string.Join("\n", ActionLogs.Select(x => $"действие {x.CalcAction} с числом [{x.CalcArgument}]"));
    }
}

internal class CalculatorDivideByZeroException : CalculatorException
{
    public CalculatorDivideByZeroException(string message, Stack<CalculatorActionLog> ActionLogs) : base(message, ActionLogs) { }

    public CalculatorDivideByZeroException(string message, Exception exception) : base(message, exception) { }

}

internal class CalculateOperationCauseOverflowException : CalculatorException
{
    public CalculateOperationCauseOverflowException(string message, Stack<CalculatorActionLog> ActionLogs) : base(message, ActionLogs) { }

    public CalculateOperationCauseOverflowException(string message, Exception exception) : base(message, exception) { }
}

