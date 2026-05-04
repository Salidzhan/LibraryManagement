using System;
using System.IO;
using System.Text.Json;


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
