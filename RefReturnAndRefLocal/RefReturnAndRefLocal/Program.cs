using System;

namespace RefReturnAndRefLocal {
    class Program {

        private static PointStruct _myPoint = new PointStruct(12, 5);

        static void Main(string[] args) {
            var p = GetPoint();
            p.Swap();

            Console.WriteLine(_myPoint);
            Console.WriteLine(p);
        }

        public static PointStruct GetPoint() { // Returns a copy
            return _myPoint;
        }
    }

    struct PointStruct {

        public int X; // { get; set; }
        public int Y; // { get; set; }

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

}
