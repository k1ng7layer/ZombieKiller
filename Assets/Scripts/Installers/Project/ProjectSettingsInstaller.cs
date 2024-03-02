using Db.Inventory;
using Db.Inventory.Impl;
using Db.Items;
using Db.Items.Impl;
using Db.Items.Repositories;
using Db.Items.Repositories.Impl;
using UnityEngine;
using Zenject;

namespace Installers.Project
{
    [CreateAssetMenu(menuName = "Installers/" + nameof(ProjectSettingsInstaller), fileName = nameof(ProjectSettingsInstaller))]
    public class ProjectSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private ItemsBase itemsBase;
        [SerializeField] private WeaponRepository weaponRepository;
        [SerializeField] private PotionRepository potionRepository;
        [SerializeField] private PlayerInventorySettings playerInventorySettings;
        
        public override void InstallBindings()
        {
            Container.Bind<IItemsBase>().FromInstance(itemsBase);
            Container.Bind<IWeaponRepository>().FromInstance(weaponRepository);
            Container.Bind<IPotionRepository>().FromInstance(potionRepository);
            Container.Bind<IPlayerInventorySettings>().To<PlayerInventorySettings>().FromInstance(playerInventorySettings).AsSingle();
        }
    }
}