namespace TodoList;

public class FileManager
{
	public static void EnsureDataDirectory(string dirPath)
	{
		if (!Directory.Exists(dirPath))
		{
			Directory.CreateDirectory(dirPath);
		}
	}
	
	public static void SaveProfile(Profile profile, string filePath)
	{
		var rawProfile = $"{profile.FirstName};{profile.LastName};{profile.BirthYear}";
		File.WriteAllText(filePath, rawProfile);
	}
	
	public static Profile LoadProfile(string filePath)
	{
		var parts = File.ReadAllText(filePath).Split(';');
		return new Profile(parts[0], parts[1], int.Parse(parts[2]));
	}
	
	public static void SaveTodos(TodoList todoList, string filePath)
	{
		using var writer = new StreamWriter(filePath, false);

		for (var i = 0; i < todoList.TaskCount; i++)
		{
			var item = todoList.todos[i];
			writer.WriteLine($"{i};{EscapeCsv(item.Text)};{item.IsDone};{item.LastUpdate:O}");
		}
		string EscapeCsv(string text)
			=> "\"" + text.Replace("\"", "\"\"").Replace("\n", "\\n") + "\"";
	}
	
	public static TodoList LoadTodos(string filePath)
	{
		var list = new TodoList();

		var lines = File.ReadAllLines(filePath);
		foreach (var line in lines)
		{
			var parts = line.Split(';');

			list.Add(new TodoItem(UnescapeCsv(parts[1]), bool.Parse(parts[2]), DateTime.Parse(parts[3])));
		}

		return list;
		
		string UnescapeCsv(string text)
			=> text.Trim('"').Replace("\\n", "\n").Replace("\"\"", "\"");
	}
}