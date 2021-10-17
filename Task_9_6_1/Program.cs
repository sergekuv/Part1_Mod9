using System;
using System.IO;

namespace Task_9_6_1
{
    class Program
    {
        /// <summary>
        /// Создайте свой тип исключения.
        /// Сделайте массив из пяти различных видов исключений, включая собственный тип исключения.
        /// Реализуйте конструкцию TryCatchFinally, в которой будет итерация на каждый тип исключения (блок finally по желанию).
        /// В блоке catch выведите в консольном сообщении текст исключения.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            Exception[] exceptionArray = { new Exception("Parent Exception class"), new FileNotFoundException("Can't find some (unknown) file"), 
                new ArgumentOutOfRangeException(), new DivideByZeroException("Have you really tried to divide?"), new MyOwnException("My Own")};

            foreach(Exception ex in exceptionArray)
            try
            {
                throw ex;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("-- end --");
        }
    }
}
