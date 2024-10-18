namespace HW_7
{
    internal class TestClass
    {

        public int I { get; set; }
        public string? S { get; set; }
        public char[]? C { get; set; }
        public TestClass() { }
        public TestClass(int i)
        {
            I = i;
        }
        public TestClass(int i, string s, char[] c) : this(i)
        {
            S = s;
            C = c;
        }

    }
}