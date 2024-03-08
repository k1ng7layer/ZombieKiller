using System;
using System.Collections.Generic;
using Game.Utils;

namespace Db.LootParams
{
    [Serializable]
    public class LootParams
    {
        public EItemType ItemType;
        public List<string> ItemsIds;
        public bool IsRandom;
    }
}