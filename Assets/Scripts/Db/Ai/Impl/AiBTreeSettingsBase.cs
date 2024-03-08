using System;
using System.Collections.Generic;
using Game.Utils;
using Plugins.NgpBehaviourTreeDesigner;
using Plugins.NgpBehaviourTreeDesigner.Nodes;
using UnityEngine;

namespace Db.Ai.Impl
{
	[CreateAssetMenu(menuName = "Databases/Ai/AiBTreeSettingsBase", fileName = "AiBTreeSettingsBase")]
	public class AiBTreeSettingsBase : ScriptableObject, IAiBTreeSettingsBase
	{
		[KeyValue("enemyType")] [SerializeField]
		private EnemyAiTree[] aiTrees;

		[NonSerialized] private List<AiBTree> _EnemyAiTreesCache = new();

		public List<BTreeRootTask> Get(EEnemyType aiType)
		{
			var aiBTreeVo = _EnemyAiTreesCache.Find(f => f.AiType == aiType)
			                ?? ReadAndCache(aiType);

			if (aiBTreeVo == null)
				throw new Exception($"[{nameof(AiBTreeSettingsBase)}] No fsm settings for enemy type {aiType}");

			return aiBTreeVo.RootTasks;
		}

		private AiBTree ReadAndCache(EEnemyType aiType)
		{
			var enemyAiTree = Array.Find(aiTrees, f => f.aiType == aiType);
			if (enemyAiTree == null)
				return null;

			var aiBTree = new AiBTree(aiType);
			_EnemyAiTreesCache.Add(aiBTree);

			foreach (var tree in enemyAiTree.trees)
			{
				var rootTask = new BTreeRootTask(tree.name, CreateBTreeTask(tree));
				aiBTree.RootTasks.Add(rootTask);
			}

			return aiBTree;
		}

		private static BTreeTask CreateBTreeTask(BehaviourTreeGraph graph)
		{
			var root = graph.GetRoot();
			var firstNode = root.ChildNodes[0];
			return ReadChildNodes(new BTreeTask(firstNode.name, firstNode.Values), root.ChildNodes);
		}

		private static BTreeTask ReadChildNodes(BTreeTask task, List<ABehaviourTreeNode> childNodes)
		{
			foreach (var node in childNodes)
			{
				var values = node.Values;
				var treeTask = new BTreeTask(node.name, values);
				ReadChildNodes(treeTask, node.ChildNodes);
				task.ChildTasks.Add(treeTask);
			}

			return task;
		}


		[Serializable]
		private class EnemyAiTree
		{
			public EEnemyType aiType;
			public BehaviourTreeGraph[] trees;
		}
	}
}