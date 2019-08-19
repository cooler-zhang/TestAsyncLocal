using System;
using System.Threading;

namespace TestAsyncLocal
{
    internal class Program
    {
        private static readonly AsyncLocal<TestDbContext> AsyncTestDbContext = new AsyncLocal<TestDbContext>();

        private static void Main(string[] args)
        {
            GetDbContext();
            SetDbContext();
            GetDbContext();
            Thread.Sleep(3000);
            GetDbContext();
            Console.ReadLine();
        }

        public static void SetDbContext()
        {
            AsyncTestDbContext.Value = new TestDbContext();
        }

        public static void GetDbContext()
        {
            var dbContext = AsyncTestDbContext.Value;
            Console.WriteLine("CurrentDbContext:" + dbContext?.Id);
        }
    }

    public class TestDbContext
    {
        public string Id { get; set; }

        public TestDbContext()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}