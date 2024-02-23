using System.Collections.Generic;

namespace Db.Ai
{
    public class BTreeTask
    {
        public readonly string TaskName;
        public readonly Dictionary<string, object> Values;
        public readonly List<BTreeTask> ChildTasks = new();

        public BTreeTask(string taskName, Dictionary<string, object> values = null)
        {
            TaskName = taskName;
            Values = values;
        }
    }
}