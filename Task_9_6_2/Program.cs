using System;
using System.Linq;

namespace Task_9_6_2
{
    /// <summary>
    /// Создайте консольное приложение, в котором будет происходить сортировка списка фамилий из пяти человек. 
    /// Сортировка должна происходить при помощи события. Сортировка происходит при введении пользователем либо числа 1 (сортировка А-Я), либо числа 2 (сортировка Я-А).
    /// Дополнительно реализуйте проверку введённых данных от пользователя через конструкцию TryCatchFinally с использованием собственного типа исключения.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Angle", "Выход", "Bull", "Гамма", "Дом"};
            string sortOrder = "Unsorted Array";
            while(true)
            {
                ShowArray(names, sortOrder);
                Console.Write("\nВведите 1 (сортировка А-Я), 2 (сортировка Я-А) или 3 (завершение работы): ");
                try
                {
                    switch (Int32.Parse(Console.ReadLine()))        // В качестве варианта - отлавливается неправильно введенное число через созданное исключение,
                                                                    // и отдельно - все прочие ошибки (например, введено не число) - через стандартное исключение
                                                                    // если нужно сделать по-другому - пишитея, исправлю..
                    {
                        case 1:
                            Array.Sort(names);
                            sortOrder = "Sorted Ascending";
                            break;
                        case 2:
                            names = names.OrderByDescending(name => name).ToArray();
                            //Array.Sort<int>(array);   //ну, или так - не знаю, что лучше..  Можно еще проверять, как отсортирован массив и пропускать какие-то этапы
                            //Array.Reverse(array);
                            sortOrder = "Sorted Descending";
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                        default:
                            throw (new WrongNumberException("Wrong number entered"));
                    }
                }
                catch (WrongNumberException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.GetType()} {ex.Message}");
                }
            } 
            Console.WriteLine("-- end --");
        }
        static void ShowArray(string[] ar, string order)
        {
            Console.WriteLine("\n"+order);
            foreach(string s in ar)
            {
                Console.WriteLine(s);
            }
        }

    }
}
