using Ecs.Commands.Generator;
using Game.Utils;

namespace Ecs.Commands.Command
{
    [Command]
    public struct SetGameStateCommand
    {
        public EGameState GameState;
    }
}