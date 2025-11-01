namespace TodoList
{
	
    class Program
    {
	    static Profile profile;
	    static TodoList todos = new();
        public static void Main()
        {
            Console.WriteLine("Работу выполнили: Галстян и Дзуцев");
            CreateUser();

            while (true)
            {
	            Console.WriteLine("Введите команду: ");
	            string input = Console.ReadLine();

	            ICommand command = CommandParser.Parse(input, todos, profile);
	            command.Execute();
            }
        }
        
        private static void CreateUser()
        {
            Console.Write("Введите ваше имя: ");
            var name = Console.ReadLine();
            Console.Write("Введите вашу фамилию: ");
            var surname = Console.ReadLine();

            Console.Write("Введите ваш год рождения: ");
            var year = int.Parse(Console.ReadLine());
            
            profile = new Profile(name, surname, year);
            Console.WriteLine(profile.GetInfo());
        }
    }
}