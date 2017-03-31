using System;
using System.IO;

namespace testWindowsFormsApp1
{
    [Serializable]
    public class FileInfoWrapper
    {

        private readonly FileInfo _fileInfo;

        #region ~~~ Constructors ~~~

        public FileInfoWrapper() { }

        public FileInfoWrapper(FileInfo FileInfo) { _fileInfo = FileInfo; }

        #endregion


        #region ~~~ Properties ~~~

        public string Name { get { return _fileInfo.Name; } set { } }

        public string FullName { get { return _fileInfo.FullName; } set { } }

        public long Length { get { return _fileInfo.Length; } set { } }

        public string Extension { get { return _fileInfo.Extension; } set { } }

        public DateTime LastWriteTime { get { return _fileInfo.LastWriteTime; } set { } }

        public string DirectoryName { get { return _fileInfo.DirectoryName; } set { } }

        #endregion
    }
}
