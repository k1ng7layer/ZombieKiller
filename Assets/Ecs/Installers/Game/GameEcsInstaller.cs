﻿using Ecs.Core.Bootstrap;
using Ecs.Installers.Game.Feature;
using Ecs.Utils.Groups.Impl;
using JCMG.EntitasRedux.Commands;

namespace Ecs.Installers.Game
{
	public class GameEcsInstaller : AEcsInstaller
	{
		protected override void InstallSystems()
		{
			BindGroups();
			
			Container.BindInterfacesTo<CommandBuffer>().AsSingle();
			
			BindContexts();
            
			GameEcsSystems.Install(Container);

			BindEventSystems();

			BindCleanupSystems();

			var mainFeature = new GameFeature();
			Container.Bind<GameFeature>().FromInstance(mainFeature).WhenInjectedInto<Bootstrap>();
		}

		private void BindGroups()
		{
			Container.BindInterfacesTo<GameGroupUtils>().AsSingle();
		}

		private void BindContexts()
		{
			BindContext<GameContext>();
			BindContext<InputContext>();
		}
		
		private void BindEventSystems()
		{
			Container.BindInterfacesTo<GameEventSystems>().AsSingle();
			Container.BindInterfacesTo<InputEventSystems>().AsSingle();
		}

		private void BindCleanupSystems()
		{
			Container.BindInterfacesTo<GameCleanupSystems>().AsSingle();
			Container.BindInterfacesTo<InputCleanupSystems>().AsSingle();
		}
	}
}