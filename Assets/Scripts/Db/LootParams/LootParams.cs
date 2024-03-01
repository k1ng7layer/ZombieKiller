using System;
using Game.Utils;

namespace Db.LootParams
{
    [Serializable]
    public class LootParams
    {
        public EItemType ItemType;
        public string[] ItemsIds;
    }
}