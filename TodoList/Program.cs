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
                    string task = input.Split(" ", 2)[1];
                    if (index >= todos.Length)
                    {
                        string[] newTodos = new string[todos.Length*2];
                        for (int i = 0; i < todos.Length; i++)
                            newTodos[i] = todos[i];
                        
                        todos = newTodos;
                    }

                    todos[index] = task;
                    index++;
                    Console.WriteLine($"Задача добавлена: {task}");
                }
                else if (input == "view")
                {
                    Console.WriteLine("Список задач:");
                    for (int i = 0; i < index; i++)
                    {
                        Console.WriteLine($"{i + 1}) {todos[i]}");
                    }
                }
                else
                {
                    Console.WriteLine("Неизвестная команда.");
                }
            }
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