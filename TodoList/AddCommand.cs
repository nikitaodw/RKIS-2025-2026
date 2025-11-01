namespace TodoList;

public class AddCommand: ICommand
{
	public string text { get; set; }
	public bool isMultiTask { get; set; }
	public TodoList todos { get; set; }

	public void Execute()
	{
		if (!isMultiTask)
		{
			text = ExtractTaskText(text);
		}
		else
		{
			Console.WriteLine("Многострочный режим, введите !end для отправки");

			while (true)
			{
				string line = Console.ReadLine();
				if (line == "!end") break;
				text += line + "\n";
			}
		}
            
		todos.Add(new TodoItem(text));
	}
	static string ExtractTaskText(string input)
	{
		string[] parts = input.Split('"');
            
		if (parts.Length >= 2)
		{
			return parts[1];
		}
		else
		{
			return input.Substring(3).Trim();
		}
	}
}