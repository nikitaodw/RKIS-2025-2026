namespace TodoList;

public class DoneCommand: ICommand
{
	public int index { get; set; }

	public TodoList todos { get; set; }

	public void Execute()
	{
		todos.MarkDone(index);
	}
}