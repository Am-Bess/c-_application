class Calculator : ICalculator
{
    public event EventHandler<EventArgs> ?GotResult;


    readonly Stack<int> LastResult = new();
    public int Result { get; set ; } = 0;

    public void Divide(int value)
    {
        LastResult.Push(Result);
        Result /= value;
        PrintResult();
    }

    public void Multiplay(int value)
    {
        LastResult.Push(Result);
        Result *= value;
        PrintResult();
    }

    public void Substruct(int value)
    {
        LastResult.Push(Result);
        Result -= value;
        PrintResult();
    }

    public void Sum(int value)
    {
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