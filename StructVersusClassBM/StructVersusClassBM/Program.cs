using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace StructVersusClassBM {
    class Program {
        static void Main(string[] args) => BenchmarkRunner.Run<BM>();
    }

    [MemoryDiagnoser]
    public class BM {

        [Benchmark]
        public void CreateClass() {
            for (int i = 0; i < 1000; i++) new PointClass(i, i);
        }

        [Benchmark(Baseline = true)]
        public void CreateStructs() {
            for (int i = 0; i < 1000; i++) new PointStruct(i, i);
        }
    }

    struct PointStruct {

        public int X;
        public int Y;

        public PointStruct(int x, int y) {
            this.X = x;
            this.Y = y;
        }

        public void Swap() {
            this = new PointStruct(this.Y, this.X);
        }

        public double Dist => Math.Sqrt((X * X) + (Y * Y));

        public override string ToString() => $"({X.ToString()},{Y.ToString()})";
    }


    class PointClass {

        public int X { get; set; }
        public int Y { get; set; }

        public PointClass(int x, int y) {
            this.X = x;
            this.Y = y;
        }

        public void Swap() {
            (this.X, this.Y) = (this.Y, this.X);
        }

        public double Dist => Math.Sqrt((X * X) + (Y * Y));

        public override string ToString() => $"({X.ToString()},{Y.ToString()})";
    }

}
