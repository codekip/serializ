using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace testWindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            IEnumerable<FileInfo> allfiles = FileGetter.FileInfoAllFiles();

            FileList filelist = new FileList();

            foreach (var file in allfiles)
            {
                filelist.Add(new FileInfoSerializable(file));
            }

            var stream = new FileStream("Xmllist.xml", FileMode.Create);
            new XmlSerializer(typeof(FileList)).Serialize(stream, filelist);

        }
    }

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

    [Serializable]
    public class FileInfoSerializable
    {

        private readonly FileInfo _fileInfo;

        #region ~~~ Constructors ~~~

        public FileInfoSerializable() { }

        public FileInfoSerializable(FileInfo FileInfo) { _fileInfo = FileInfo; }

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
