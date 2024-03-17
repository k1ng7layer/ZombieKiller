using Db.Items;
using Ecs.Commands.Command;
using Game.Utils;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Commands.Systems
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 600, nameof(EFeatures.Common))]
    public class UsePotionSystem : ForEachCommandUpdateSystem<UsePotionCommand>
    {
        private readonly IItemsBase _itemsBase;
        private readonly GameContext _game;

        public UsePotionSystem(
            ICommandBuffer commandBuffer, 
            IItemsBase itemsBase,
            GameContext game
        ) : base(commandBuffer)
        {
            _itemsBase = itemsBase;
            _game = game;
        }

        protected override void Execute(ref UsePotionCommand command)
        {
            var potion = _itemsBase.PotionRepository.Get(command.Id);
            var player = _game.PlayerEntity;

            foreach (var potionEffect in potion.Effects)
            {
                switch (potionEffect.StatType)
                {
                    case EUnitStat.HEALTH:
                        var currHealth = player.Health.Value;
                        currHealth += potionEffect.Value;
                        player.ReplaceHealth(currHealth);
                        break;
                    case EUnitStat.MOVE_SPEED:
                        break;
                    case EUnitStat.ARMOR:
                        break;
                    case EUnitStat.ATTACK_DAMAGE:
                        break;
                    case EUnitStat.ABILITY_POWER:
                        break;
                }
            }
        }
    }
}