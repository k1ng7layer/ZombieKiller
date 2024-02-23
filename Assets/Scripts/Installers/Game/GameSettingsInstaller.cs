using Db.Camera;
using Db.Camera.Impl;
using Db.Enemies;
using Db.Enemies.Impl;
using Db.Player;
using Db.Player.Impl;
using Db.PowerUps;
using Db.PowerUps.Impl;
using Db.Prefabs;
using Db.Prefabs.Impl;
using Db.ProjectileBase;
using Db.ProjectileBase.Impl;
using Db.Weapon;
using Db.Weapon.Impl;
using UnityEngine;
using Zenject;

namespace Installers.Game
{
    [CreateAssetMenu(menuName = "Installers/" + nameof(GameSettingsInstaller), fileName = nameof(GameSettingsInstaller))]
    public class GameSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private PrefabsBase prefabsBase;
        [SerializeField] private CameraBase cameraBase;
        [SerializeField] private PlayerSettings playerSettings;
        [SerializeField] private WeaponBase weaponBase;
        [SerializeField] private EnemyParamsBase enemyParamsBase;
        [SerializeField] private ProjectileBase projectileBase;
        [SerializeField] private PowerUpBase powerUpBase;
       

        public override void InstallBindings()
        {
            Container.Bind<IPrefabsBase>().FromInstance(prefabsBase);
            Container.Bind<ICameraBase>().FromInstance(cameraBase);
            Container.Bind<IPlayerSettings>().FromInstance(playerSettings);
            Container.Bind<IWeaponBase>().FromInstance(weaponBase);
            Container.Bind<IEnemyParamsBase>().FromInstance(enemyParamsBase);
            Container.Bind<IProjectileBase>().FromInstance(projectileBase);
            Container.Bind<IPowerUpBase>().FromInstance(powerUpBase);
        }
    }
}