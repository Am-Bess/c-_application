interface ICalculator
{
    event EventHandler<EventArgs> GotResult;

    double Result { get; set; }
    void SumInt(int value);
    void Substruct(int value);
    void Multiplay(int value);
    void Divide(int value);

    void Sum(double number);
    void Substruct(double number);
    void Multiplay(double number);
    void Divide(double number);

    void CancelLast();

}