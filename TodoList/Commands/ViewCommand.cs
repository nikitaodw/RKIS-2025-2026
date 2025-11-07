namespace TodoList.Commands;

public class ViewCommand : ICommand
{
	public bool hasIndex { get; set; }
	public bool hasStatus { get; set; }
	public bool hasDate { get; set; }
	public bool hasAll { get; set; }
	public TodoList Todos { get; set; }

	public void Execute()
	{
		Todos.View(hasIndex, hasStatus, hasDate, hasAll);
	}
}