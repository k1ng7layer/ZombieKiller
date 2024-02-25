namespace Db.Inventory
{
    public interface IPlayerInventorySettings
    {
        int BasicCapacity { get; }
        
        int[] StarterItemsIds { get; }
    }
}