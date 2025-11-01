namespace TodoList;

public class ViewCommand : ICommand
{
	public bool hasIndex { get; set; }
	public bool hasStatus { get; set; }
	public bool hasDate { get; set; }
	public bool hasAll { get; set; }
	public TodoList todos { get; set; }

	public void Execute()
	{
		todos.View(hasIndex, hasStatus, hasDate, hasAll);
	}
}