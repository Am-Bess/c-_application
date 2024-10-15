class Calculator : ICalculator
{
    public event EventHandler<EventArgs>? GotResult;
    readonly Stack<double> LastResult = new Stack<double>();
    readonly Stack<CalculatorActionLog> actions = new Stack<CalculatorActionLog>();
    public double Result { get; set ; } = 0;
    public void Divide(int value)
    {
        if (value == 0)
        {
            actions.Push(new CalculatorActionLog(CalculatorAction.Divide, value));
            throw new CalculatorDivideByZeroException("Делить на 0 нельзя!", actions);
        }
        LastResult.Push(Result);
        Result /= value;
        PrintResult();
    }

    public void Multiplay(int value)
    {
        ulong temp = (ulong)(value * Result);
        if (temp > int.MaxValue)
        {
            actions.Push(new CalculatorActionLog(CalculatorAction.Multiply, value));
            throw new CalculateOperationCauseOverflowException("Переполнение ", actions);
        }
        LastResult.Push(Result);
        Result *= value;
        PrintResult();
    }

    public void Substruct(int value)
    {
        long temp = (long)(Result - value);
        if (temp < int.MinValue)
        {
            actions.Push(new CalculatorActionLog(CalculatorAction.Substruct, value));
            throw new CalculateOperationCauseOverflowException("Переполнение", actions);
        }
        LastResult.Push(Result);
        Result -= value;
        PrintResult();
    }

    public void SumInt(int value)
    {
        ulong temp = (ulong)(Result + value);
        if (temp > int.MaxValue)
        {
            actions.Push(new CalculatorActionLog(CalculatorAction.Sum, value));
            throw new CalculateOperationCauseOverflowException("Переполнение", actions);
        }
        LastResult.Push(Result);
        Result += value;
        PrintResult();
    }

    public void Divide(double value)
    {
         if (value == 0)
        {
            actions.Push(new CalculatorActionLog(CalculatorAction.Divide, value));
            throw new CalculatorDivideByZeroException("Делить на 0 нельзя!", actions);
        }
        LastResult.Push(Result);
        Result /= value;
        PrintResult();
    }

    public void Multiplay(double value)
    {
        ulong temp = (ulong)(value * Result);
        if (temp > int.MaxValue)
        {
            actions.Push(new CalculatorActionLog(CalculatorAction.Multiply, value));
            throw new CalculateOperationCauseOverflowException("Переполнение ", actions);
        }
        LastResult.Push(Result);
        Result *= value;
        PrintResult();
    }

    public void Substruct(double value)
    {
        long temp = (long)(Result - value);
        if (temp < int.MinValue)
        {
            actions.Push(new CalculatorActionLog(CalculatorAction.Substruct, value));
            throw new CalculateOperationCauseOverflowException("Переполнение", actions);
        }
        LastResult.Push(Result);
        Result -= value;
        PrintResult();
    }

    public void Sum(double value)
    {
        ulong temp = (ulong)(Result + value);
        if (temp > int.MaxValue)
        {
            actions.Push(new CalculatorActionLog(CalculatorAction.Sum, value));
            throw new CalculateOperationCauseOverflowException("Переполнение", actions);
        }
        LastResult.Push(Result);
        Result += value;
        PrintResult();
    }

    void PrintResult()
    {
        if (GotResult != null)
        {
            GotResult?.Invoke(this, EventArgs.Empty);
        }
    }

    public void CancelLast()
    {
        Result = LastResult.Pop();
        PrintResult();
    }
    
}