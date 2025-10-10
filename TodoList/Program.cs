namespace TodoList
{
    class Program
    {
        static string name;
        static string surname;
        static int age;
        public static void Main()
        {
            Console.WriteLine("Работу выполнили: Галстян и Дзуцев");
            CreateUser();

            string[] todos = new string[2];
            bool[] statuses = new bool[2];
            DateTime[] dates = new DateTime[2];
            int index = 0;

            while (true)
            {
                Console.Write("Введите команду: ");
                string input = Console.ReadLine();
                
                if (input == "exit")
                {
                    Console.WriteLine("Выход из программы.");
                    break;
                }
                if (input == "help")
                {
                    HelpCommand();
                }
                else if (input == "profile")
                {
                    ProfileCommand();
                }
                else if (input.StartsWith("add"))
                {
                    AddCommand(input, ref todos, ref statuses, ref dates, ref index);
                }
                else if (input == "view")
                {
                    ViewCommand(todos, statuses, dates);
                }
                else
                {
                    Console.WriteLine("Неизвестная команда.");
                }
            }
        }

        private static void ViewCommand(string[] todos, bool[] statuses, DateTime[] dates)
        {
            Console.WriteLine("Список задач:");
            for (int i = 0; i < todos.Length; i++)
            {
                if (string.IsNullOrEmpty(todos[i])) continue;
                Console.WriteLine($"{i + 1}) {todos[i]}, сделано:{statuses[i]}, {dates[i]}");
            }
        }

        private static void AddCommand(string command, ref string[] todos, ref bool[] statuses, ref DateTime[] dates, ref int index)
        {
            string text = command.Substring(4);
            if (index == todos.Length)
            {
                int newSize = todos.Length * 2;
                Array.Resize(ref todos, newSize);
                Array.Resize(ref statuses, newSize);
                Array.Resize(ref dates, newSize);
            }

            todos[index] = text;
            statuses[index] = false;
            dates[index] = DateTime.Now;
            index++;

            Console.WriteLine($"Добавлена задача: \"{text}\"");
        }

        private static void ProfileCommand()
        {
            Console.WriteLine($"{name} {surname}, {age}");
        }

        private static void HelpCommand()
        {
            Console.WriteLine("Доступные команды:");
            Console.WriteLine("help - вывести список команд");
            Console.WriteLine("profile - показать данные пользователя");
            Console.WriteLine("add текст задачи - добавить новую задачу");
            Console.WriteLine("view - показать все задачи");
            Console.WriteLine("exit - выйти из программы");
        }

        private static void CreateUser()
        {
            Console.Write("Введите ваше имя: ");
            name = Console.ReadLine();
            Console.Write("Введите вашу фамилию: ");
            surname = Console.ReadLine();

            Console.Write("Введите ваш год рождения: ");
            var year = int.Parse(Console.ReadLine());
            age = DateTime.Now.Year - year;
            
            Console.WriteLine($"Добавлен пользователь {name} {surname}, возраст - {age}");
        }
    }
}