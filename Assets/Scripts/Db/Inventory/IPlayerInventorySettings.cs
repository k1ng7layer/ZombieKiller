using System.Collections.Generic;

namespace Db.Inventory
{
    public interface IPlayerInventorySettings
    {
        int BasicCapacity { get; }
        
        IReadOnlyList<string> StarterItemsIds { get; }
    }
}