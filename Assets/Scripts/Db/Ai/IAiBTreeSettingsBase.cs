using System.Collections.Generic;
using Game.Utils;

namespace Db.Ai
{
	public interface IAiBTreeSettingsBase
	{
		List<BTreeRootTask> Get(EEnemyType heroType);
	}
}