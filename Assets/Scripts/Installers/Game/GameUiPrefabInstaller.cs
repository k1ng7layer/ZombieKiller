
using Game.Ui.Buffs;
using Game.Ui.Income;
using Game.Ui.Input;
using Game.Ui.Inventory;
using Game.Ui.Inventory.BagButton;
using Game.Ui.PlayerStats.Exp;
using Game.Ui.PlayerStats.Health;
using Game.Ui.PlayerStats.LevelUp;
using SimpleUi;
using UnityEngine;
using Zenject;

namespace Installers.Game
{
    [CreateAssetMenu(menuName = "Installers/" + nameof(GameUiPrefabInstaller), fileName = nameof(GameUiPrefabInstaller))]
    public class GameUiPrefabInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private Canvas canvas;
        
        [SerializeField] private InputView inputView;
        [SerializeField] private CoinsView coinsView;
        [SerializeField] private LevelUpView levelUpView;
        [SerializeField] private PlayerExperienceView playerExpView;
        [SerializeField] private PlayerHealthView playerHealthView;
        [SerializeField] private CurrentBuffsView currentBuffsView;
        [SerializeField] private PlayerBagInventoryView playerBagInventoryView;
        [SerializeField] private OpenBagButtonView openBagButtonView;
        
        public override void InstallBindings()
        {
            var canvasView = Container.InstantiatePrefabForComponent<Canvas>(canvas);
            var canvasTransform = canvasView.transform;
            
            Container.BindUiView<InputController, InputView>(inputView, canvasTransform);
            Container.BindUiView<CoinsController, CoinsView>(coinsView, canvasTransform);
            Container.BindUiView<LevelUpController, LevelUpView>(levelUpView, canvasTransform);
            Container.BindUiView<PlayerExperienceController, PlayerExperienceView>(playerExpView, canvasTransform);
            Container.BindUiView<PlayerHealthController, PlayerHealthView>(playerHealthView, canvasTransform);
            Container.BindUiView<CurrentBuffsController, CurrentBuffsView>(currentBuffsView, canvasTransform);
            Container.BindUiView<PlayerBagInventoryController, PlayerBagInventoryView>(playerBagInventoryView, canvasTransform);
            Container.BindUiView<OpenBagButtonController, OpenBagButtonView>(openBagButtonView, canvasTransform);
        }
    }
}