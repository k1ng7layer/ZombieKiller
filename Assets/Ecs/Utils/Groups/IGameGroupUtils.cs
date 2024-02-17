using System;
using System.Collections.Generic;

namespace Ecs.Utils.Groups
{
    public interface IGameGroupUtils
    {
        IDisposable GetProjectiles(out List<GameEntity> buffer, Func<GameEntity, bool> filter = null);
    }
}