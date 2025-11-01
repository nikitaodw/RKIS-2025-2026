namespace TodoList;

public class ReadCommand: ICommand
{
	public int index { get; set; }

	public TodoList todos { get; set; }

	public void Execute()
	{
		todos.Read(index);
	}
}