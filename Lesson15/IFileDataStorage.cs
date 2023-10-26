using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson15
{
    public interface IFileDataStorage<T>
    {
        void AddData(T newData);
        T[] GetAllData();
        bool SaveToFile(string fileName);
    }
}
