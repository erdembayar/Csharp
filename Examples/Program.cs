using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examples
{
    class Program
    {
        

        static void Main(string[] args)
        {
            //Singleton.Current.Action();
            //Animal animal = new Animal();

            /*TestThreading testThreading = new TestThreading();

            var tasks = new List<Task>();
            tasks.Add(Task.Run(()=> testThreading.Process()));
            tasks.Add(Task.Run(()=> testThreading.Process()));
            tasks.Add(Task.Run(()=> testThreading.Process()));
            tasks.Add(Task.Run(()=> testThreading.Process()));
            tasks.Add(Task.Run(()=> testThreading.Process()));
            tasks.Add(Task.Run(()=> testThreading.Process()));

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("Done");*/

            /*Hashtable hashtable = new Hashtable();
            hashtable.Add(1, "one");
            hashtable.Add(2, "two");
            hashtable.Add(3, "three");
            hashtable.Add(4, "four");

            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            SortedList<int, string> sortedList = new SortedList<int, string>();

            HashSet<int?> hashSet = new HashSet<int?>();
            hashSet.Add((int?)null);
            hashSet.Add((int?)null);
            hashSet.Add(1);
            hashSet.Add(1);



            Console.WriteLine(hashtable[4]);*/

            /*Calc cal1 = Program.FuncCalc;
            Console.WriteLine(cal1.Invoke(2, 5));


            cal1 = Program.FuncCalc2;
            Console.WriteLine(cal1.Invoke(2, 5));

            cal1 = delegate (int x, int y) 
            {
                return x + y * 2;
            };

            Console.WriteLine(cal1.Invoke(2, 5));*/

            Person oPerson = new Person();
            oPerson.iAge = 27;
            oPerson.sName = "Fernando Vezzali";
            PropertyInfo[] properties = oPerson.GetType().GetProperties();

            foreach (PropertyInfo oPropertyInfo in properties)
            {
                MethodInfo oMethodInfo = oPerson.GetType().GetMethod("get_" + oPropertyInfo.Name);
                ParameterInfo[] ArrParameterInfo = oPerson.GetType().GetMethod("get_" + oPropertyInfo.Name).GetParameters();
                Console.WriteLine(oPropertyInfo.Name + " = " + oMethodInfo.Invoke(oPerson, ArrParameterInfo));
            }

            Console.ReadLine();
        }

        public delegate int Calc(int x, int y);

        public static int FuncCalc(int x, int y)
        {
            return x + y;
        }

        public static int FuncCalc2(int x, int y)
        {
            return x * y;
        }
    }

    public class Singleton
    {
        private static Singleton context;
        static Singleton()
        {
            Console.WriteLine("executed static constructor");
            context = new Singleton();
        }

        private Singleton()
        {
            Console.WriteLine("executed constuctor");
        }
        

        public static Singleton Current
        {
            get { return context; }
        }

        public void Action()
        {
            Console.WriteLine("executed Action");
        }
    }

    public class Animal
    {
        public Animal() {
            Console.WriteLine("constructor Animal");
        }

        static Animal()
        {
            Console.WriteLine("Static constructor Animal");
        }
    }

    public class TestThreading
    {
        public object lockThis = new object();
        private decimal amount = 0;
        public void Process()
        {
            lock (lockThis)
            {
                //if (amount < 1)
                //{
                    Thread.Sleep(1000);

                    Console.WriteLine("Started work procees and amount is {0}", ++amount);
                //}
            }
        }
    }

    public class Person
    {
        private int _iAge;
        private string _sName;

        public int iAge
        {
            get { return _iAge; }
            set { _iAge = value; }
        }
        public string sName
        {
            get { return _sName; }
            set { _sName = value; }
        }
    }
}
