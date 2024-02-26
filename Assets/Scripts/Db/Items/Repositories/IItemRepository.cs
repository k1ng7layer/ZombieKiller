using System.Collections.Generic;

namespace Db.Items.Repositories
{
    public interface IItemRepository<T> where T : Item
    {
        IReadOnlyList<T> Items { get; }
        // void Add(T item);
        // void Clear();
    }
}