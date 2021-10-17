using System;
using System.Collections.Generic;
using System.IO;

namespace Part1_Mod9
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task_9_1_3();
            //Task_9_2_2();
            //Task_9_2_3();
            //Task_9_3_2();
            //Task_9_3_4();
            //Task_9_3_7();
            //Task_9_3_12();
            //Task_9_3_13();
            //Task_9_3_14();
            //Task_9_3_15();
            //Task_9_4_2();
            //Task_9_4_3();
            //Task_9_5();


            Console.WriteLine("-- end --");
        }

        #region Task 9.5
        delegate void Notify();
        class ProcessBusinessLogic
        {
            public event Notify ProcessCompleted;
            public Notify note;
            public void StartProcess()
            {
                Console.WriteLine("Process started");
                OnProcessCompleted();
            }
            void OnProcessCompleted()
            {
                ProcessCompleted?.Invoke();
                note?.Invoke();
            }

        }
        public static void bl_ProceddCompleted()
        {
            Console.WriteLine("Proc.completed");
        }
        private static void Task_9_5()
        {
            ProcessBusinessLogic bl = new();
            bl.ProcessCompleted += bl_ProceddCompleted;
            bl.note += bl_ProceddCompleted;
            bl.StartProcess();
        }
        #endregion Task 9.5

        #region Task 9.4.3
        class Parent { }
        class Child : Parent { }
        static void MethodPar(Parent p) { }
        static void MethodChi(Child c) { }
        static void MethodObj(object o) { }

        delegate void ParentDel(Parent p);
        delegate void ChildDel(Child c);
        delegate void ObjectDel(object o);

        private static void Task_9_4_3()
        {
            ParentDel pDel = MethodPar;
            //pDel += MethodChi;
            pDel += MethodObj;
            ChildDel cDel = MethodChi;
            cDel += MethodPar;
            cDel += MethodObj;
            ObjectDel oDel = MethodObj;
            //oDel += MethodPar;
            //oDel += MethodChi;

        }
        #endregion Task 9.4.3

        #region Task 9.4.2
        class Car
        {
            internal int price;
            internal Car(int p)
            {
                price = p;
            }
        }

        class Lexus : Car
        {
            string model;
            internal Lexus(int p, string m) : base(p)
            {
                model = m;
            }
            internal Lexus(int p) : base(p)
            {
            }

        }
        delegate Car CarDelegate(int price);
        delegate Lexus LexusDelegate(int price);
        delegate object CarDel1(Car carItem);
        delegate object LexusDel(Lexus lexusItem);

        private static void Task_9_4_2()
        {
            CarDelegate carDel = MakeLexus;
            carDel += MakeCar;
            LexusDelegate lexusDel = MakeLexus;
            //lexusDel += MakeCar; //Ошибка

            CarDel1 carDel1 = MethodCar;
            carDel1 += MethodLex;

            LexusDel lexDel1 = MethodLex;
            lexDel1 += MethodCar;
            
        }

        static Lexus MethodCar(object item)
        {
            return null;
        }
        static Lexus MethodLex(object item)
        {
            return null;
        }
        private static Car MakeCar(int price)
        {
            return new Car(price);
        }

        private static Lexus MakeLexus(int price)
        {
            return new Lexus(price);
        }
        #endregion

        #region 9.3.15
        private static void Task_9_3_15()
        {
            Func<int> rnd = () => new Random().Next(0, 100);
            Console.WriteLine($"{rnd.Invoke()} + {rnd()}");
        }
        #endregion
        #region Task 9.3.14
        delegate void ShowMessageDelegate9314(string name);
        private static void Task_9_3_14()
        {
            ShowMessageDelegate9314 smd = delegate (string name)
            {
                Console.WriteLine(name);
            };
            Action<string> smd1 = (s) => Console.WriteLine(s);
            smd("Hello World!");
            smd1("Hello lambda world");
        }
        #endregion

        #region Task 9.3.13
        delegate int RandomNumberDelegate();
        private static void Task_9_3_13()
        {
            RandomNumberDelegate rnd = delegate
            {
                return new Random().Next(0, 100);
            };
            Console.WriteLine(rnd());

        }
        #endregion

        #region Task 9.3.12
        delegate void ShowMessageDelegate9312(string name);
        private static void Task_9_3_12()
        {
            ShowMessageDelegate9312 smd = delegate (string name)
            {
                Console.WriteLine(name);
            };
            smd("Hello World!");
        }
        #endregion

        #region Task 9.3.7

        private static void Task_9_3_7()
        {
            ShowMessageDelegate smd = ShowMessage937;
            smd();
            SumDelegate sd = Sum937;
            Console.WriteLine(sd(1,2,3));
            CheckLengthDelegete cld = CheckLength937;
            Console.WriteLine(cld("jljklhkjhkjh\n"));

            Action smd1 = new (ShowMessage937);
            smd1();
            
            Func<int, int, int, int> sd1 = new(Sum937);
            Console.WriteLine(sd1(1, 2, 3));

            Predicate<string> cld1 = new(CheckLength937);
            Console.WriteLine(cld1("kjkljjlkj"));


        }

        delegate void ShowMessageDelegate();
        delegate int SumDelegate(int a, int b, int c);
        delegate bool CheckLengthDelegete(string row);

        static void ShowMessage937()
        {
            Console.WriteLine("Hello World!");
        }
        static void ShowMessage937(string s)
        {
            Console.WriteLine("string s");
        }

        static int Sum937(int a, int b, int c)
        {
            return a + b + c;
        }

        static bool CheckLength937(string _row)
        {
            if (_row.Length > 3) return true;
            return false;
        }
        #endregion

        #region Task 9.3.4 - and 9.3.5
        private static void Task_9_3_4()
        {
            MyDelegate mcDel = Addition;
            mcDel += Substr;
            mcDel -= Addition;
            mcDel -= Addition;
            Console.WriteLine(mcDel(10, 5));
            MyDelegate mcDel2 = Addition;
            mcDel2 += Addition;
            MyDelegate mcDel3 = mcDel + mcDel2;
            Console.WriteLine(mcDel3(100, 50));

        }
        static int Addition(int x, int y)
        {
            Console.WriteLine($"Addition: { x + y}");
            return x + y;
        }
        #endregion

        #region Task 9.3.2 - 9.3.3
        delegate int MyDelegate(int a, int b);
        private static void Task_9_3_2()
        {
            MyDelegate del = Substr;
            Console.WriteLine(del(10,5));
            Console.WriteLine(del.Invoke(10, 5));
        }
        static int Substr(int x, int y)
        {
            Console.WriteLine($"Substr: {x-y}");
            return x - y;
        }
        #endregion

        #region 9.2.3
        private static void Task_9_2_3()
        {
            int[,] twoDimArray = new int[2,2];
            try
            {
                Array.Sort(twoDimArray);
            }
            catch (RankException ex)
            {
                Console.WriteLine($"RankException occured:\n{ex.GetType()}\n{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Some exception occured:\n{ex.GetType()}\n{ex.Message}");
            }
            finally
            {
                Console.WriteLine("Finally block");
            }

        }
        #endregion

        #region Task 9.2.2
        private static void Task_9_2_2()
        {
            List<int> ls = new();
            try
            {
                ls[2] = 0;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"ArgumentOutOfRangeException occured:\nNo such index in the array: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Some other exception: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("List processing: Finally block reached\n");
            }
            int[] arr = new int[2];
            try
            {
                arr[2] = 0;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"ArgumentOutOfRangeException occured:\nNo such index in the array: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Some other exception: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Array processing: Finally block reached");
            }


        }
        #endregion

        #region Task 9.1.3
        private static void Task_9_1_3()
        {
            Exception ex = new("My Ex Message");
            ex.Data.Add("Date", DateTime.Now);
            ex.Data.Add(2, 3);
            Console.WriteLine(ex.Data["Date"]);
            Console.WriteLine(ex.Data[2]);
            ex.HelpLink = "www.ru";
            Console.WriteLine(ex.HelpLink);

        }

        #endregion
    }
}

