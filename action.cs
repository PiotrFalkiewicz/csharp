using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace ConsoleApplication3
{
    class x
    {
        public x()
        {
            WriteLine("x " + this.GetHashCode());
        }
        public virtual void doSomething()
        {
            WriteLine("x is doing something");
        }
    }
    class y : x
    {
        public y() : base()
        {
            WriteLine("y " + this.GetHashCode());
        }
        public virtual void doSomething()
        {
            base.doSomething();
        }

    }
    class z : y
    {
        public z() : base()
        {
            WriteLine("z " + this.GetHashCode());
        }
        public override void doSomething()
        {
            WriteLine("z is doing somethin");
        }
    }
    public class clasa
    {
        public static void a()
        {
            x obj = new x();
        }
        public static void b()
        {
            y obj = new y();
        }
        public static void c()
        {
            z obj = new z();
        }
        public static void z()
        {
            x obj = new x();
            obj.doSomething();
        }

        public static void x()
        {
            y obj = new y();
            obj.doSomething();
        }

        public static void v()
        {
            z obj = new z();
            obj.doSomething();
        }

        public static bool t()
        {
            return true;
        }
        public static bool f()
        {
            return false;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<ConsoleKey, Action> lista = new Dictionary<ConsoleKey, Action> {
                { ConsoleKey.A, clasa.a },
                { ConsoleKey.B, clasa.b },
                { ConsoleKey.C, clasa.c },
                { ConsoleKey.Z, clasa.z },
                { ConsoleKey.X, clasa.x },
                { ConsoleKey.V, clasa.v }};

            do
            {
                    lista[ReadKey(true).Key]();                
            } while (ReadKey(true).Key != ConsoleKey.Escape);
            ReadLine();

        }

        
    }
        
}

