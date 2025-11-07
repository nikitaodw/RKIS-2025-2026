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
}