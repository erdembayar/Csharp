using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
            TimeSpan time = new TimeSpan(1, 0, 0);


            //		time.Ticks		long


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

            Calc cal1, cal2, multiCalc;
            cal1 = Program.FuncCalc;
            
            //Console.WriteLine(cal1.Invoke(2, 5));

            cal2 = Program.FuncCalc2;

            multiCalc = cal1 + cal2;

            multiCalc.Invoke(2, 5);
            /*
            cal1 = delegate (int x, int y) 
            {
                return x + y * 2;
            };

            Console.WriteLine(cal1.Invoke(2, 5));*/

            Dog dog = new Dog();
            dog.Walk();
            dog.Walk2();
            /*
            var age = 10;
            var tax = 10.5F;

            var dog1 = new Dog();
            dog1.Walk();*/

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

        public delegate void Calc(int x, int y);

        public static void FuncCalc(int x, int y)
        {
            Console.WriteLine(x + y);
        }

        public static void FuncCalc2(int x, int y)
        {
            Console.WriteLine(x * y);
        }
    }

    public static class Helper
    {
        public static void Walk2(this Dog dog)
        {
            var obj = new { Age = 25, Name = "Sam" };

            dog.Walk();
            Console.WriteLine("Walked");
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

    public class Animal : Fly, Fish
    {
        private int countWing = 0;
        public int CountWing
        {
            get { return countWing; }
            set { countWing = value; }
        }

        public Animal()
        {
            Console.WriteLine("constructor Animal");
        }

        static Animal()
        {
            Console.WriteLine("Static constructor Animal");
        }

        public virtual void Walk()
        {
            countWing++;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        private void Fly()
        {
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }

    public interface Fly
    {
        int CountWing { get; set; }
        int Count();
    }

    public interface Fish
    {
        int Count();
        void Run();
    }

    public class Dog : Animal
    {
        public sealed override void Walk()
        {
            base.Walk();
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(new DataTable());
        }


    }

    public abstract class Pet
    {

        public abstract void Wow();
        public virtual void Run()
        {
            Console.WriteLine("Run");
        }
    }

    public struct Cat
    {
        //Nullable<Decimal> == decimal?
        public int CountLeg { get; set; }

        void Muyau()
        {
            Console.WriteLine("Muyau");
        }
    }

    public class ChildPet : Pet, Fish
    {
        public override void Wow()
        {
            throw new NotImplementedException();
        }

        public override void Run()
        {
            Console.WriteLine("Not Run");
        }

        public int Count()
        {
            throw new NotImplementedException();
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
