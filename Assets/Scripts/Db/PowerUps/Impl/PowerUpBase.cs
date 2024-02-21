using System.Collections.Generic;
using UnityEngine;

namespace Db.PowerUps.Impl
{
    [CreateAssetMenu(menuName = "Settings/PowerUps/" + nameof(PowerUpS), fileName = "PowerUpBase")]
    public class PowerUpBase : ScriptableObject, 
        IPowerUpBase
    {
        [SerializeField] private List<PowerUpSettings> powerUpSettings;
        
        public IReadOnlyList<PowerUpSettings> PowerUpS => powerUpSettings;

        public PowerUpSettings Get(int id)
        {
            if (id > powerUpSettings.Count - 1)
                return null;
            
            return powerUpSettings[id];
        }
    }
}