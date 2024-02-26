using System;
using System.Collections.Generic;

namespace Ecs.Utils.Groups
{
    public interface IGameGroupUtils
    {
        IDisposable GetCollectables(out List<GameEntity> buffer, Func<GameEntity, bool> filter = null);
        IDisposable GetUnits(out List<GameEntity> buffer, Func<GameEntity, bool> filter = null);
        IDisposable GetProjectiles(out List<GameEntity> buffer, Func<GameEntity, bool> filter = null);
        IDisposable GetEnemies(out List<GameEntity> buffer, Func<GameEntity, bool> filter = null);
        IDisposable GetStagePortals(out List<GameEntity> buffer, Func<GameEntity, bool> filter = null);
        IDisposable GetAi(out List<GameEntity> buffer, Func<GameEntity, bool> filter = null);
    }
}