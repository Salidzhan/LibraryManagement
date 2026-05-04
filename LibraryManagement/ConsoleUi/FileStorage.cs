using LibraryManagement.Data;

namespace LibraryManagement
{
    internal class FileStorage<T>
    {
        private FileStorage storage;

        public FileStorage(FileStorage storage)
        {
            this.storage = storage;
        }
    }
}