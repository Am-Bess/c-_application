internal class CalculatorActionLog
{
    public CalculatorAction CalcAction { get; private set; }
    public double CalcArgument { get; private set; }


    public CalculatorActionLog(CalculatorAction calcAction, int calcArgument)
    {
        CalcAction = calcAction;
        CalcArgument = calcArgument;
    }

    public CalculatorActionLog(CalculatorAction calcAction, double calcArgument)
    {
        CalcAction = calcAction;
        CalcArgument = calcArgument;
    }
}