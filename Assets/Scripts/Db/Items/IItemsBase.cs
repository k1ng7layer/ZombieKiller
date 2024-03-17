using System.Collections.Generic;
using Db.Items.Impl;
using Db.Items.Repositories.Impl;
using Game.Utils;

namespace Db.Items
{
    public interface IItemsBase
    {
        IReadOnlyList<Item> Items { get; }
        Item GetItem(string id);
        IReadOnlyList<Item> GetItemsByType(EItemType itemType);
        EItemType GetItemType(string id);
        ItemRepository<Potion> PotionRepository { get; }
    }
}