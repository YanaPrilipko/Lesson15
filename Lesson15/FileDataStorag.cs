using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson15
{
    public abstract class FileDataStorage<T> : IFileDataStorage<T>
    {
        public T[] _data;
        public string _fileName;

        public FileDataStorage(string fileName)
        {
            _fileName = fileName;
            _data = new T[0];
        }

        public void AddData(T newData)
        {
            Array.Resize(ref _data, _data.Length + 1);
            _data[^1] = newData;
        }

        public T[] GetAllData() => _data;

        public abstract bool SaveToFile(string fileName);
    }
}
