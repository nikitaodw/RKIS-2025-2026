namespace TodoList.Commands;

public static class CommandParser
{
	public static Profile Profile = FileManager.LoadProfile(Program.profilePath);
	private static TodoList _todoList = new();
	public static ICommand Parse(string input)
	{
		string[] twoParts = input.Trim().Split(' ', 2);
		string[] threeParts = input.Trim().Split(' ', 3);
		string commandName = twoParts[0].ToLower();
		string[] flags = ParseFlags(input);

		if (input == "set profile")
		{
			return new SetProfileCommand();
		}
		
		switch (commandName)
		{
			case "add":
				return new AddCommand
				{
					Todos = _todoList,
					IsMultiTask = flags.Contains("--multi") || flags.Contains("-m"),
					Text = input
				};

			case "view":
				return new ViewCommand
				{
					Todos = _todoList,
					hasAll = flags.Contains("--all") || flags.Contains("-a"),
					hasIndex = flags.Contains("--Index") || flags.Contains("-i"),
					hasStatus = flags.Contains("--status") || flags.Contains("-s"),
					hasDate = flags.Contains("--update-date") || flags.Contains("-d")
				};

			case "done":
				return new DoneCommand
				{
					Todos = _todoList,
					Index = int.Parse(twoParts[1]) - 1
				};

			case "delete":
				return new DeleteCommand
				{
					Todos = _todoList,
					Index = int.Parse(twoParts[1]) - 1
				};
			case "read":
				return new ReadCommand
				{
					Todos = _todoList,
					Index = int.Parse(twoParts[1]) - 1
				};
			case "update":
				return new UpdateCommand
				{
					Todos = _todoList,
					Index = int.Parse(threeParts[1]) - 1,
					NewText = threeParts[2]
				};

			case "profile":
				return new ProfileCommand
				{
					profile = Profile
				};

			case "help":
				return new HelpCommand();

			case "exit":
				return new ExitCommand();

			default:
				return new UnknownCommand();
		}
	}
	
	private static string[] ParseFlags(string command)
	{
		var parts = command.Split(' ');
		var flags = new List<string>();

		foreach (var part in parts)
		{
			if (part.StartsWith("-"))
			{
				for (int i = 1; i < part.Length; i++)
				{
					flags.Add("-" + part[i]);
				}
			}
			else if (part.StartsWith("--"))
			{
				flags.Add(part);
			}
		}

		return flags.ToArray();
	}
}