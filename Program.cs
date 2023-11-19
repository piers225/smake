namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string source = args[0];
                object[] argList = args.Skip(1).ToArray();
                Console.WriteLine(SBuilder.SMake(source, argList));
            }
        }
    }
}