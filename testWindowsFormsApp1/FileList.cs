using System;
using System.Collections.Generic;

namespace testWindowsFormsApp1
{
    [Serializable]
    public class FileList
    {
        public List<FileInfoWrapper> filez { get; set; }

        public FileList()
        {
            filez = new List<FileInfoWrapper>();
        }

        public void Add(FileInfoWrapper m)
        {
            filez.Add(m);
        }
    }
}
