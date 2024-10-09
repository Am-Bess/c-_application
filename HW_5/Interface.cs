interface ICalculator 
{
    event EventHandler<EventArgs> GotResult;

    int Result { get; set; }
    void Sum(int value);
    void Substruct(int value);
    void Multiplay(int value);
    void Divide(int value);
    void CancelLast() ;

}