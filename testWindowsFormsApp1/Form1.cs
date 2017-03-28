using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var x = FileGetter.FileInfoAllFiles();

            var t = new TheFiles();
            foreach (var file in x)
            {
                FileInfoWrapper f = new FileInfoWrapper(file);
                t.Add(f);
            }


            var stream = new FileStream("TDBlist.xml", FileMode.Create);
            new XmlSerializer(typeof(FileInfoWrapper)).Serialize(stream, t);

            foreach (var file in x)
            {
                Debug.WriteLine(file.FullName + ' ' + file.LastWriteTime);
            }

        }
    }

    public class TheFiles
    {
        List<FileInfoWrapper> filez;
        public TheFiles()
        {
            filez = new List<FileInfoWrapper>();
        }

        public void Add(FileInfoWrapper m)
        {
            filez.Add(m);
        }
    }

    public class FileInfoWrapper
    {
        private FileInfo _file;
        public string Name { get { return _file.FullName; } }
        public DateTime LastWrite { get { return _file.LastWriteTime; } }
        public string Extension { get { return _file.Extension; } }

        public FileInfoWrapper(FileInfo f)
        {
            _file = f;
        }

        public FileInfoWrapper()
        {

        }
    }
}
