using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Zenject;

namespace Game.Utils
{
    public static class BehaviorTreeInjectExtension
    {
        public static void QueueAllTasksForInject(this BehaviorTree tree, DiContainer container)
        {
            tree.CheckForSerialization(true, false);

            tree.OnBehaviorStart += behavior =>
            {
                InjectIntoBehavior(container, behavior);
            };
        }

        private static void InjectIntoBehavior(DiContainer container, Behavior behavior)
        {
            foreach (var task in behavior.FindTasks<Task>())
            {
                if (task is BehaviorTreeReference referenceTask)
                {
                    foreach (var externalBehavior in referenceTask.GetExternalBehaviors())
                    {
                        externalBehavior.Init();
                        var tasks = externalBehavior.FindTasks<Task>();
                        tasks.ForEach(container.Inject);
                    }
                }

                container.Inject(task);
            }
        }
    }
}