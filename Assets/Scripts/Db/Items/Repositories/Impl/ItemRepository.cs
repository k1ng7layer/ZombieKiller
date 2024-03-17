using System;
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

        public T Get(string id)
        {
            foreach (var item in Items)
            {
                if (item.Id == id)
                    return item;
            }

            throw new Exception($"[{nameof(ItemRepository<T>)}] cant find {nameof(T)} in repository");
        }

        public bool Contains(string id)
        {
            foreach (var item in Items)
            {
                if (item.Id == id)
                    return true;
            }
            
            return false;
        }
    }
}