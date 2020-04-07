using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace TestIfBoolean
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<TestRunner>();
        }
    }

    [ClrJob, MonoJob, CoreJob] // 可以針對不同的 CLR 進行測試
    [MinColumn, MaxColumn]
    [MemoryDiagnoser]
    public class TestRunner
    {
        private readonly TestClass _test = new TestClass();

        public TestRunner()
        {
        }

        [Benchmark]
        public void TestMethod1() => _test.TestMethod1(false);

        [Benchmark]
        public void TestMethod2() => _test.TestMethod2(false);
    }

    public class TestClass
    {
        public void TestMethod1(bool tmp)
        {
            for (int i = 0; i < 1000; i++)
            {
                if (tmp == false)
                {
                    
                }
            }
        }

        public void TestMethod2(bool tmp)
        {
            for (int i = 0; i < 1000; i++)
            {
                if (!tmp)
                {
                    
                }
            }
        }
    }
}