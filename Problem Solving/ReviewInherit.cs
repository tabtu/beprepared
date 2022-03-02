namespace coding
{
    public abstract class A
    {
        public A()
        {
            Console.WriteLine("A");
        }

        public virtual void Fun()
        {
            Console.WriteLine("Fun A");
        }
    }

    public class B : A
    {
        public B()
        {
            Console.WriteLine("B");
        }

        public override void Fun()
        {
            Console.WriteLine("Fun B");
        }
    }

    public class C : B
    {
        public C()
        {
            Console.WriteLine("C");
        }

        public static new void Fun()
        {
            Console.WriteLine("Fun C");
        }
    }

    public class coding
    {
        public static void Main(String[] args)
        {
            // abstruct class can not be constructure directly.
            //A a0 = new A();
            //a0.Fun();
            //Console.WriteLine();
            
            // new B() :-> new A() -> new B()
            A a1 = new B();  // output "A\nB\n"
            a1.Fun();  // output "Fun B", since instance A with override in B
            
            // new C() :-> new A() -> new B() -> new C()
            A a2 = new C();  // output "A\nB\nC\n"
            a2.Fun();  // output "Fun B", since instance A with override in B

            // new C() :-> new A() -> new B() -> new C()
            B a3 = new C();  // output "A\nB\nC\n"
            a3.Fun();  // output "Fun B", since instance B

            // new C() :-> new A() -> new B() -> new C()
            C a4 = new C();  // output "A\nB\nC\n"
            C.Fun();  // output "Fun C", since static new C.Fun()
        }
    }
}
