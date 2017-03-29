using System;
using System.Collections.Generic;

namespace testWindowsFormsApp1
{
    [Serializable]
    public class FileList
    {
        public List<FileInfoSerializable> filez { get; set; }

        public FileList()
        {
            filez = new List<FileInfoSerializable>();
        }

        public void Add(FileInfoSerializable m)
        {
            filez.Add(m);
        }
    }
}
