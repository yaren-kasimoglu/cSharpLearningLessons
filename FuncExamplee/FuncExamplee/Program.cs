namespace FuncExamplee
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Func<int, int, int> toplaFunc = (a, b) => a + b;
        }
        public static int Topla(int s1, int s2)
        {
            return s1 + s2;
        }
    }
}