using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core01_Api.Infrastarcture;
using System.Collections.Concurrent;

namespace Core01_Api
{
    public class TodoRepository : IRepository
    {
        private static ConcurrentDictionary<string, TodoItem> _todos =
            new ConcurrentDictionary<string, TodoItem>();

        public TodoRepository()
        {
            for (int i = 100; i < 105; i++)
            {
                Add(new TodoItem { Name = "Item" + i });
            }
        }

        public void Add(TodoItem item)
        {
            item.Key = Guid.NewGuid().ToString();
            _todos[item.Key] = item;
        }

        public void Update(TodoItem item)
        {
            _todos[item.Key] = item;
        }

        public TodoItem Remove(string Key)
        {
            TodoItem item;
            _todos.TryRemove(Key, out item);
            return item;
        }

        public TodoItem Find(string Key)
        {
            TodoItem item;
            _todos.TryGetValue(Key, out item);
            return item;
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _todos.Values;
        }
    }
}
