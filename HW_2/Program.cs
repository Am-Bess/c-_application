public class Program
{
    public static void Main(string[] args)
    {
        // Bits B = new Bits(4);
        // Console.WriteLine(B.GetBitByIndex(3));

        Bits bits = new Bits(5);

        byte b = bits; 
        int i = bits;
        long l = bits;


        Console.WriteLine($"b={b}, i={i}, l={l}");
    }
}