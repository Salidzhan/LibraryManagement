using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace LibraryManagement.Data
{
    public class FileStorage
    {
        private readonly string path;

        public FileStorage(string path)
        {
            this.path = path;
        }

        public LibraryStorage Load()
        {
            if (!File.Exists(path))
            {
                return new LibraryStorage();
            }

            var json = File.ReadAllText(path);

            var storage = JsonSerializer.Deserialize<LibraryStorage>(json);
            if (storage == null)
                throw new Exception("Deserialization returned null.");


            return storage;

        }

        public void Save(LibraryStorage storage)
        {

            var json = JsonSerializer.Serialize(storage);

            File.WriteAllText(path, json);
        }
    }
}
