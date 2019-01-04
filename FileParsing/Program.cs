using BenchmarkDotNet.Running;

namespace FileParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<FileParser>();
        }
    }
}
