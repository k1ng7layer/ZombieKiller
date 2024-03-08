using System;
using CleverCrow.Fluid.BTs.Tasks;
using Game.Providers.RandomProvider;

namespace Game.Models.Ai.Utils.Tasks
{
	public class CustomRandomChance : ConditionBase
	{
		private readonly IRandomProvider _randomProvider;
		private readonly Func<float> _chanceGetter;

		public CustomRandomChance(IRandomProvider randomProvider, Func<float> chanceGetter)
		{
			_randomProvider = randomProvider;
			_chanceGetter = chanceGetter;
		}

		protected override bool OnUpdate() => _chanceGetter() > _randomProvider.Value;
	}
}