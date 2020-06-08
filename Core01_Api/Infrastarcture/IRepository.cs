using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core01_Api.Infrastarcture
{
    public interface IRepository
    {
        TodoItem Find(string Key);
        void Add(TodoItem item);
        void Update(TodoItem item);
        TodoItem Remove(string Key);
        IEnumerable<TodoItem> GetAll();
    }
}
