using System;

namespace Midterm2
{
    public class A
    {
        private int _a;

        public int A
        {
            get { return _a; }
            set { _a = value; }
        }
        private int _b;

        public int B
        {
            get { return _b; }
            set { _b = value; }
        }
        public A()
        {

        }
        public A(int a, int b)
        {
            A = a;
            B = b;
        }
        public override string ToString()
        {
            return "this is base class";
        }
        public void AMethod() { }
    }

    public class B : A
    {
        private int _c;

        public int C
        {
            get { return _c; }
            set { _c = value; }
        }
        public B(int c, int a, int b) : base(a, b)
        {
            C = c;
        }

        public override string ToString()
        {
            return base.ToString() + "And derived class";
        }
        public int BMethod()
        {
            return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            A a = new A(4,5);
            A a1 = new B(5, 6, 7);
            //a1.BMethod(); -- cant access
            A a2 = new B(5, 5, 6);
        
            B b1 = new B(5, 6, 7);
            b1.BMethod();
            b1.AMethod();
        }
    }
}
