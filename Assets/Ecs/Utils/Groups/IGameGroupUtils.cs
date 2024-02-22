using System;
using System.Collections.Generic;

namespace Ecs.Utils.Groups
{
    public interface IGameGroupUtils
    {
        IDisposable GetProjectiles(out List<GameEntity> buffer, Func<GameEntity, bool> filter = null);
        IDisposable GetEnemies(out List<GameEntity> buffer, Func<GameEntity, bool> filter = null);
        IDisposable GetStagePortals(out List<GameEntity> buffer, Func<GameEntity, bool> filter = null);
        IDisposable GetTimeEntities(out List<GameEntity> buffer, bool isTimeEnd, Func<GameEntity, bool> filter = null);
    }
}