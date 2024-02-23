namespace Db.Ai
{
	public class BTreeRootTask
	{
		public readonly string Name;
		public readonly BTreeTask Task;

		public BTreeRootTask(string name, BTreeTask task)
		{
			Name = name;
			Task = task;
		}
	}
}