using Db.Items.Impl;
using Game.Utils;

namespace Db.Items.Repositories
{
    public interface IPotionRepository
    {
        Potion Get(EPotionType potionType);
    }
}