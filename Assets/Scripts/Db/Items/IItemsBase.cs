using System.Collections.Generic;
using Game.Utils;

namespace Db.Items
{
    public interface IItemsBase
    {
        IReadOnlyList<Item> Items { get; }
        Item GetItem(string id);
        IReadOnlyList<Item> GetItemsByType(EItemType itemType);
    }
}