namespace Db.Inventory
{
    public interface IPlayerInventorySettings
    {
        int BasicCapacity { get; }
        
        string[] StarterItemsIds { get; }
    }
}