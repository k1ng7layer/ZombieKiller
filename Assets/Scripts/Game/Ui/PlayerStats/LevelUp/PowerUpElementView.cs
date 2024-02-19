using SimpleUi.Abstracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Ui.PlayerStats.LevelUp
{
    public class PowerUpElementView : UiView
    {
        public Image Icon;
        public TextMeshProUGUI Title;
        public TextMeshProUGUI Description;

        public void SetInfo(
            Sprite icon, 
            string title, 
            string description
        )
        {
            Icon.sprite = icon;
            Title.text = title;
            Description.text = description;
        }
    }
}