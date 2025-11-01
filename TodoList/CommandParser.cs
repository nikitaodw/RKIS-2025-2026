namespace TodoList;

public static class CommandParser
{
	public static ICommand Parse(string input, TodoList todoList, Profile profile)
	{
		string[] twoParts = input.Trim().Split(' ', 2);
		string[] threeParts = input.Trim().Split(' ', 3);
		string commandName = twoParts[0].ToLower();
		string[] flags = ParseFlags(input);

		switch (commandName)
		{
			case "add":
				return new AddCommand
				{
					todos = todoList,
					isMultiTask = flags.Contains("--multi") || flags.Contains("-m"),
					text = input
				};

			case "view":
				return new ViewCommand
				{
					todos = todoList,
					hasAll = flags.Contains("--all") || flags.Contains("-a"),
					hasIndex = flags.Contains("--index") || flags.Contains("-i"),
					hasStatus = flags.Contains("--status") || flags.Contains("-s"),
					hasDate = flags.Contains("--update-date") || flags.Contains("-d")
				};

			case "done":
				return new DoneCommand
				{
					todos = todoList,
					index = int.Parse(twoParts[1]) - 1
				};

			case "delete":
				return new DeleteCommand
				{
					todos = todoList,
					index = int.Parse(twoParts[1]) - 1
				};
			case "read":
				return new ReadCommand
				{
					todos = todoList,
					index = int.Parse(twoParts[1]) - 1
				};
			case "update":
				return new UpdateCommand
				{
					todos = todoList,
					index = int.Parse(threeParts[1]) - 1,
					newText = threeParts[2]
				};

			case "profile":
				return new ProfileCommand
				{
					profile = profile
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