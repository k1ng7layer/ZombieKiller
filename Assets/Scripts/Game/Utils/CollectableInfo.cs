namespace Game.Utils
{
    public readonly struct CollectableInfo
    {
        public readonly EItemType Type;
        public readonly int Id;

        public CollectableInfo(EItemType type, int id)
        {
            Type = type;
            Id = id;
        }
    }
}