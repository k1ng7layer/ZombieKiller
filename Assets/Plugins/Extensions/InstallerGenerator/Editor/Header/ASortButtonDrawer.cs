using Plugins.Extensions.InstallerGenerator.Editor.Sort;
using UnityEditor;
using UnityEngine;

namespace Plugins.Extensions.InstallerGenerator.Editor.Header
{
	public abstract class ASortButtonDrawer
	{
		public readonly ISortStrategy SortStrategy;

		protected readonly GUILayoutOption[] Style;

		private ISortStrategy[] _resetOnClickStrategies;

		protected ASortButtonDrawer(ISortStrategy sortStrategy, GUILayoutOption[] style)
		{
			SortStrategy = sortStrategy;
			Style = style;
		}

		public virtual bool OnClick()
		{
			var onClick = GUILayout.Button(GetButtonLabel(), EditorStyles.toolbarDropDown, Style);
			
			if (onClick)
			{
				foreach (var sortStrategy in _resetOnClickStrategies)
					sortStrategy.Reset();
			}

			return onClick;
		}

		public void ResetOnClick(params ISortStrategy[] strategies) => _resetOnClickStrategies = strategies;

		protected abstract string GetButtonLabel();
	}
}