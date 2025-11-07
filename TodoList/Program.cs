using TodoList.Commands;

namespace TodoList
{
	
    class Program
    {
	    public static string dataDirPath = "data";
	    public static string profilePath = Path.Combine(dataDirPath, "profile.txt");
        public static void Main()
        {
	        FileManager.EnsureDataDirectory(dataDirPath);
	        if (!File.Exists(profilePath)) File.WriteAllText(profilePath, "Default;User;2000");
	        
	        
            Console.WriteLine("Работу выполнили: Галстян и Дзуцев");

            while (true)
            {
	            Console.WriteLine("Введите команду: ");
	            string input = Console.ReadLine();

	            ICommand command = CommandParser.Parse(input);
	            command.Execute();
            }
        }
    }
}