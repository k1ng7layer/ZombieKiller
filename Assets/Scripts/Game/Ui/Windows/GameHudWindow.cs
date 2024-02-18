﻿using Game.Ui.PlayerStats.Exp;
using Game.Ui.PlayerStats.Health;
using SimpleUi;

namespace Game.Ui.Windows
{
    public class GameHudWindow : WindowBase
    {
        public override string Name => "GameHudWindow";

        protected override void AddControllers()
        { 
            AddController<PlayerExperienceController>();
            AddController<PlayerHealthController>();
        }
    }
}