using System.Collections.Generic;
using UnityEngine;

namespace Db.Items.Repositories.Impl
{
    public abstract class ItemRepository<T> : ScriptableObject where T: Item
    {
        public abstract List<T> Items { get; }

        // public void Clear()
        // {
        //     Items.Clear();
        // }
        //
        // public void Add(T item)
        // {
        //     Items.Add(item);
        // }
    }
}