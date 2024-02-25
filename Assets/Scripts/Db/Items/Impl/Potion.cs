using System;
using Game.Utils;
using UnityEngine;

namespace Db.Items.Impl
{
    [CreateAssetMenu(menuName = "Settings/Items/" + nameof(Potion), fileName = "PotionItem")]
    public class Potion : Item
    {
        public EPotionType PotionType;
        public PotionEffect[] Effects;
        
        public override object[] GetDescriptionArgs()
        {
            var result = new object[Effects.Length];

            for (int i = 0; i < Effects.Length; i++)
            {
                result[i] = Effects[i].Value;
            }

            return result;
        }
    }

    [Serializable]
    public class PotionEffect
    {
        public EUnitStat StatType;
        public int Value;
    }
}