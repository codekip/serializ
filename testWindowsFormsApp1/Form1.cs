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




}
