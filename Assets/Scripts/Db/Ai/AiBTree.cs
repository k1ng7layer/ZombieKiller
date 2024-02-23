using System.Collections.Generic;
using Game.Utils;

namespace Db.Ai
{
	public class AiBTree
	{
		public readonly EEnemyType AiType;
		public readonly List<BTreeRootTask> RootTasks = new List<BTreeRootTask>();

		public AiBTree(EEnemyType aiType)
		{
			AiType = aiType;
		}
	}
}