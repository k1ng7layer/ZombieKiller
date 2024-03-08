namespace Game.AI
{
	public interface IAiTaskBuildersLibrary
	{
		ITaskBuilder Get(string name);
	}
}