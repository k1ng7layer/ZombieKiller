using Db.Enemies;
using Ecs.Commands.Systems.Spawn;
using Ecs.Extensions.UidGenerator;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Commands.Systems
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 500, nameof(EFeatures.Spawn))]
    public class SpawnEnemySystem : ForEachCommandUpdateSystem<SpawnEnemyCommand>
    {
        private readonly IEnemyParamsBase _enemyParamsBase;
        private readonly GameContext _game;

        public SpawnEnemySystem(
            ICommandBuffer commandBuffer, 
            IEnemyParamsBase enemyParamsBase,
            GameContext game
        ) : base(commandBuffer)
        {
            _enemyParamsBase = enemyParamsBase;
            _game = game;
        }

        protected override void Execute(ref SpawnEnemyCommand command)
        {
            var enemyType = command.EnemyType;
            var enemyParams = _enemyParamsBase.GetEnemyParams(enemyType);
            var enemyEntity = _game.CreateEntity();
            var player = _game.PlayerEntity.Uid.Value;
            enemyEntity.AddEnemy(enemyType);
            enemyEntity.AddPosition(command.Position);
            enemyEntity.AddRotation(command.Rotation);
            enemyEntity.AddPrefab(enemyType.ToString());
            enemyEntity.AddHealth(enemyParams.BaseHealth);
            enemyEntity.AddUid(UidGenerator.Next());
            enemyEntity.IsInstantiate = true;
            enemyEntity.AddExperience(enemyParams.BaseExperience);
            enemyEntity.AddTarget(player);
            enemyEntity.AddAttackRange(enemyParams.BaseAttackRange);
            enemyEntity.AddMoveSpeed(enemyParams.BaseMoveSpeed);
            enemyEntity.ReplaceAttackSpeed(enemyParams.BaseAttackSpeed);
            enemyEntity.AddAttackCooldown(0);
            enemyEntity.IsUnit = true;
            enemyEntity.IsAi = true;
            enemyEntity.IsActive = true;
            enemyEntity.IsCanAttack = true;
        }
    }
}