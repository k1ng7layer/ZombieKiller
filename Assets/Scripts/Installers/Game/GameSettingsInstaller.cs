using Db.Ai;
using Db.Ai.Impl;
using Db.Camera;
using Db.Camera.Impl;
using Db.Enemies;
using Db.Enemies.Impl;
using Db.Inventory;
using Db.Inventory.Impl;
using Db.Items;
using Db.Items.Impl;
using Db.Items.Repositories;
using Db.Items.Repositories.Impl;
using Db.Player;
using Db.Player.Impl;
using Db.PowerUps;
using Db.PowerUps.Impl;
using Db.Prefabs;
using Db.Prefabs.Impl;
using Db.ProjectileBase;
using Db.ProjectileBase.Impl;
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
        [SerializeField] private EnemyParamsBase enemyParamsBase;
        [SerializeField] private ProjectileBase projectileBase;
        [SerializeField] private PowerUpBase powerUpBase;
        [SerializeField] private AiBTreeSettingsBase aiBTreeSettingsBase;

       

        public override void InstallBindings()
        { ;
            Container.Bind<IPrefabsBase>().FromInstance(prefabsBase);
            Container.Bind<ICameraBase>().FromInstance(cameraBase);
            Container.Bind<IPlayerSettings>().FromInstance(playerSettings);
            Container.Bind<IEnemyParamsBase>().FromInstance(enemyParamsBase);
            Container.Bind<IProjectileBase>().FromInstance(projectileBase);
            Container.Bind<IPowerUpBase>().FromInstance(powerUpBase);
            Container.Bind<IAiBTreeSettingsBase>().To<AiBTreeSettingsBase>().FromInstance(aiBTreeSettingsBase).AsSingle();
        }
    }
}