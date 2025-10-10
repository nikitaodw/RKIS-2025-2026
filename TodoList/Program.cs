namespace TodoList
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Работу выполнили: Галстян и Дзуцев");
            
            Console.Write("Введите ваше имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите вашу фамилию: ");
            string surname = Console.ReadLine();

            Console.Write("Введите ваш год рождения: ");
            int year = int.Parse(Console.ReadLine());
            int age = DateTime.Now.Year - year;
            
            Console.WriteLine($"Добавлен пользователь {name} {surname}, возраст - {age}");

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
                    Console.WriteLine("Доступные команды:");
                    Console.WriteLine("help - вывести список команд");
                    Console.WriteLine("profile - показать данные пользователя");
                    Console.WriteLine("exit - выйти из программы");
                }
                else if (input == "profile")
                {
                    Console.WriteLine($"{name} {surname}, {age}");
                }
                else
                {
                    Console.WriteLine("Неизвестная команда.");
                }
            }
        }
    }
}