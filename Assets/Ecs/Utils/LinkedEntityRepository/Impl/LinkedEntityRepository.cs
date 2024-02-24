using System;
using System.Collections.Generic;
using JCMG.EntitasRedux;

namespace Ecs.Utils.LinkedEntityRepository.Impl
{
    public class LinkedEntityRepository : ILinkedEntityRepository
    {
        private readonly Dictionary<int, EntityDecorator> _links = new ();
		private readonly Queue<EntityDecorator> _decoratorsPool = new ();

		public IEnumerable<GameEntity> GetAllItems()
		{
			var array = new GameEntity[_links.Count];

			var index = 0;
			foreach (var entityDecorator in _links.Values)
				array[index++] = entityDecorator.GetEntity();

			return array;
		}

		public void Add(int id, GameEntity item)
		{
			var decorator = _decoratorsPool.Count > 0 ? _decoratorsPool.Dequeue() : new EntityDecorator(TryDelete);
			decorator.Decorate(id, item);
			_links.TryAdd(id, decorator);
		}

		public GameEntity Get(int id) => _links[id].GetEntity();

		public bool TryGet(int id, out GameEntity entity)
		{
			entity = null;
			if (!_links.TryGetValue(id, out var decorator))
				return false;

			entity = decorator.GetEntity();
			return true;
		}

		public bool Contains(int id)
		{
			return _links.ContainsKey(id);
		}

		public bool HasItem(int id) => _links.ContainsKey(id);

		public void Update(int id, GameEntity item)
		{
			if (!_links.TryGetValue(id, out var decorator))
				return;

			decorator.Clear();
			decorator.Decorate(id, item);
			_links[id] = decorator;
		}

		public bool TryDelete(int id)
		{
			if (!HasItem(id))
				return false;
			
			var entityDecorator = _links[id];
			entityDecorator.Clear();
			_decoratorsPool.Enqueue(entityDecorator);
			_links.Remove(id);

			return true;
		}

		private struct EntityDecorator
		{
			private readonly Func<int, bool> _destroy;

			private int _id;
			private GameEntity _entity;

			public EntityDecorator(Func<int, bool> destroy)
			{
				_destroy = destroy;
				_id = -1;
				_entity = null;
			}

			public void Decorate(int id, GameEntity entity)
			{
				_id = id;
				_entity = entity;
				_entity.OnDestroyEntity += OnDestroyEntity;
			}

			private void OnDestroyEntity(IEntity entity)
			{
				_destroy(_id);
			}

			public GameEntity GetEntity() => _entity;

			public void Clear()
			{
				_entity.OnDestroyEntity -= OnDestroyEntity;
				_id = -1;
				_entity = null;
			}
		}
    }
}