using CleverCrow.Fluid.BTs.Trees;
using Db.Ai;
using Game.AI;
using Game.Models.Ai.Utils;

namespace Game.Models.Ai.Impls
{
    public class BehaviourTreeFactory : IBehaviourTreeFactory
    {
        private readonly IAiBTreeSettingsBase _aiBTreeSettingsBase;
        private readonly IAiTaskBuildersLibrary _taskBuildersLibrary;

        public BehaviourTreeFactory(
            IAiBTreeSettingsBase aiBTreeSettingsBase,
            IAiTaskBuildersLibrary taskBuildersLibrary
        )
        {
            _aiBTreeSettingsBase = aiBTreeSettingsBase;
            _taskBuildersLibrary = taskBuildersLibrary;
        }

        public IBehaviorTree Create(GameEntity entity)
        {
            var heroType = entity.Enemy.EnemyType;
            var trees = _aiBTreeSettingsBase.Get(heroType);
            var builder = new BehaviorTreeBuilder(null);
            builder.Name(heroType.ToString()).SelectorRepeater();
            foreach (var tree in trees)
            {
                builder.Decorator(tree.Name, task => task.Update());
                BuildTree(builder, tree.Task, entity);
                builder.End();
            }

            return builder.End().Build();
        }

        private void BuildTree(BehaviorTreeBuilder builder, BTreeTask task, GameEntity entity)
        {
            var name = task.TaskName.Replace("_", " ");
            var taskBuilder = _taskBuildersLibrary.Get(name);
            taskBuilder.Fill(builder, entity, task.Values);

            if (task.ChildTasks != null)
            {
                foreach (var childTask in task.ChildTasks)
                    BuildTree(builder, childTask, entity);
            }

            taskBuilder.End(builder);
        }
    }
}