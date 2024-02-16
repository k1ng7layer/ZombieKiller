using Game.Utils;

namespace Db.Enemies
{
    public interface IEnemyParamsBase
    {
        EnemyParams GetEnemyParams(EEnemyType enemyType);
    }
}