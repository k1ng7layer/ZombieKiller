using Ecs.Commands;
using Ecs.Utils.Interfaces;
using Game.Utils;
using JCMG.EntitasRedux.Commands;
using SimpleUi.Abstracts;
using SimpleUi.Signals;
using UniRx;
using Zenject;

namespace Game.Ui.Inventory.BagButton
{
    public class OpenBagButtonController : UiController<OpenBagButtonView>, 
        IUiInitialize
    {
        private readonly SignalBus _signalBus;
        private readonly ICommandBuffer _commandBuffer;

        public OpenBagButtonController(
            SignalBus signalBus, 
            ICommandBuffer commandBuffer
        )
        {
            _signalBus = signalBus;
            _commandBuffer = commandBuffer;
        }
        
        public void Initialize()
        {
            View.OpenBagBtn.OnClickAsObservable().Subscribe(_ => OpenInventory()).AddTo(View);
        }

        private void OpenInventory()
        {
            _commandBuffer.SetGameState(EGameState.Pause);
            _signalBus.OpenWindow<PlayerBagInventoryWindow>();
        }
    }
}