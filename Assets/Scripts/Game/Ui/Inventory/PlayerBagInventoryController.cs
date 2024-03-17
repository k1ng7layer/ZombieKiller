using System;
using Db.Inventory;
using Db.Items;
using Ecs.Commands;
using Game.Services.Inventory;
using Game.Utils;
using JCMG.EntitasRedux.Commands;
using SimpleUi.Abstracts;
using SimpleUi.Signals;
using UniRx;
using UniRx.Triggers;
using Zenject;

namespace Game.Ui.Inventory
{
    public class PlayerBagInventoryController : UiController<PlayerBagInventoryView>, 
        IInitializable,
        IDisposable
    {
        private readonly IPlayerInventoryService _inventoryService;
        private readonly IItemsBase _itemsBase;
        private readonly SignalBus _signalBus;
        private readonly ICommandBuffer _commandBuffer;
        private readonly IPlayerInventorySettings _playerInventorySettings;

        public PlayerBagInventoryController(
            IPlayerInventoryService inventoryService, 
            IItemsBase itemsBase,
            SignalBus signalBus,
            ICommandBuffer commandBuffer,
            IPlayerInventorySettings playerInventorySettings
        )
        {
            _inventoryService = inventoryService;
            _itemsBase = itemsBase;
            _signalBus = signalBus;
            _commandBuffer = commandBuffer;
            _playerInventorySettings = playerInventorySettings;
        }
        
        public void Initialize()
        {
            ClosePopup();
            
            View.InfoPopupView.Background.OnPointerClickAsObservable()
                .Subscribe(_ => ClosePopup())
                .AddTo(View);

            View.BackButton.OnClickAsObservable().Subscribe(_ => CloseInventory()).AddTo(View);
            
            for (int i = 0; i < _playerInventorySettings.BasicCapacity; i++)
            {
                var itemView = View.ItemListCollection.Create();
                itemView.Icon.gameObject.SetActive(false);
                
                itemView.Btn.OnClickAsObservable()
                    .Subscribe(_ => OnItemClick(itemView.ItemId))
                    .AddTo(itemView.gameObject);

                itemView.OnPointerEnterAsObservable()
                    .Subscribe(_ => ToggleItemHighlight(itemView, true))
                    .AddTo(itemView.gameObject);
                
                itemView.OnPointerExitAsObservable()
                    .Subscribe(_ => ToggleItemHighlight(itemView, false))
                    .AddTo(itemView.gameObject);
            }

            View.InfoPopupView.UseButton.OnClickAsObservable()
                .Subscribe(_ => UseItem())
                .AddTo(View.gameObject);
            
            View.InfoPopupView.DropButton.OnClickAsObservable()
                .Subscribe(_ => DropItem())
                .AddTo(View.gameObject);

            _inventoryService.ItemRemoved += OnItemRemoved;
        }
        
        public void Dispose()
        {
            _inventoryService.ItemRemoved -= OnItemRemoved;
        }
        
        public override void OnShow()
        {
            var items = _inventoryService.GetAll();
            for (int i = 0; i < items.Count; i++)
            {
                var itemId = items[i];
                var item = _itemsBase.GetItem(itemId);
                
                var itemView = View.ItemListCollection[i];
                itemView.Icon.sprite = item.Icon;
                itemView.Icon.gameObject.SetActive(true);
                itemView.ItemId = itemId;
                
                // itemView.Btn.OnClickAsObservable()
                //     .Subscribe(_ => OnItemClick(itemId))
                //     .AddTo(itemView.gameObject);
                //
                // itemView.OnPointerEnterAsObservable()
                //     .Subscribe(_ => ToggleItemHighlight(itemView, true))
                //     .AddTo(itemView.gameObject);
                //
                // itemView.OnPointerExitAsObservable()
                //     .Subscribe(_ => ToggleItemHighlight(itemView, false))
                //     .AddTo(itemView.gameObject);
            }
        }

        public override void OnHide()
        {
            //View.ItemListCollection.Clear();

            foreach (var itemView in View.ItemListCollection)
            {
                itemView.ResetView();
            }
        }

        private void UseItem()
        {
            _commandBuffer.UseItem(View.InfoPopupView.ItemId);
            ClosePopup();
        }
        
        private void DropItem()
        {
            _inventoryService.TryRemove(View.InfoPopupView.ItemId);
            ClosePopup();
        }

        private void RefreshInventory()
        {
            OnHide();
            OnShow();
        }

        private void OnItemClick(string itemId)
        {
            if (itemId == string.Empty)
                return;
            
            var item = _itemsBase.GetItem(itemId);

            View.InfoPopupView.ItemId = itemId;
            View.InfoPopupView.gameObject.SetActive(true);
            View.InfoPopupView.Icon.sprite = item.Icon;
            View.InfoPopupView.Description.text = item.Description;
            View.InfoPopupView.UseButton.gameObject.SetActive(item.Usable);
            View.InfoPopupView.DropButton.gameObject.SetActive(true);
            
            //TODO:
            //var descriptionArgs = item.GetDescriptionArgs();
        }
        
        private void ClosePopup()
        {
            View.InfoPopupView.gameObject.SetActive(false);
        }

        private void CloseInventory()
        {
            _signalBus.BackWindow();
            _commandBuffer.SetGameState(EGameState.Game);
        }

        private void ToggleItemHighlight(InventoryItemView itemView, bool v)
        {
            // var color = itemView.Selected.color;
            // color.a = v ? 1f : 0;
            //itemView.Selected.color = color;
            itemView.Selected.gameObject.SetActive(v);
        }

        private void OnItemRemoved(string id)
        {
            RefreshInventory();
        }
    }
}