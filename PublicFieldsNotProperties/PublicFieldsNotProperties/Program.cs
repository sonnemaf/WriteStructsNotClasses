using System;

namespace PublicFieldsNotProperties {

    class Program {
        static void Main(string[] args) {
            LineStruct l = new LineStruct(new PointStruct(1, 5), new PointStruct(8, 5));

            Console.WriteLine(l.ToString());
            Console.WriteLine(l.Length.ToString());

            l.Start.Swap();

            Console.WriteLine(l.ToString());
            Console.WriteLine(l.Length.ToString());
        }
    }

    struct LineStruct {

        public PointStruct Start { get; set; }
        public PointStruct Stop { get; set; }

        //public PointStruct Start;
        //public PointStruct Stop;

        public LineStruct(PointStruct start, PointStruct stop) {
            this.Start = start;
            this.Stop = stop;
        }

        public double Length => Math.Sqrt(Math.Pow(Start.X - Stop.X, 2) + Math.Pow(Start.Y - Stop.Y, 2));

        public override string ToString() => $"Line {Start.ToString()} to {Stop.ToString()}";
    }

    struct PointStruct {

        public int X { get; set; }
        public int Y { get; set; }

        //public int X, Y;

        public PointStruct(int x, int y) {
            this.X = x;
            this.Y = y;
        }

        public void Swap() {
            this = new PointStruct(Y, X);
        }

        public override string ToString() => $"({X.ToString()},{Y.ToString()})";

    }
}


