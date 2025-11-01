namespace TodoList;

public class DeleteCommand: ICommand
{
	public int index { get; set; }
	public TodoList todos { get; set; }

	public void Execute()
	{
		todos.Delete(index);
	}
}