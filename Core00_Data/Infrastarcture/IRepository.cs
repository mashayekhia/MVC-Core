using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core00_Data.Infrastarcture
{
    public interface IRepository<T>
    {
        void Find(string Key);
        void Add(T Key);
        void Update(T Key);
        void Remove(string Key);
        IEnumerable<T> GetAll();
    }
}
