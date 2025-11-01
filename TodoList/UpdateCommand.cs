namespace TodoList;

public class UpdateCommand: ICommand
{
	public int index { get; set; }
	public string newText { get; set; }

	public TodoList todos { get; set; }

	public void Execute()
	{
		todos.Update(index, newText);
	}
}