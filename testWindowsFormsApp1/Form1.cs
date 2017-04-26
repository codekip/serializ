using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using testWindowsFormsApp1.Properties;

namespace testWindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public string xmlfile = @"Xmllist.xml";
        public string tdbpath = Settings.Default["TDBpath"].ToString();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Stopwatch s = new Stopwatch();

            s.Start();
            IEnumerable<FileInfo> allfiles = FileGetter.FileInfoAllFiles(tdbpath);
            Debug.WriteLine("Got files:" + s.Elapsed.ToString());

            FileList filelist = new FileList();

            foreach (var file in allfiles)
            {
                filelist.Add(new FileInfoWrapper(file));
            }

            var stream = new FileStream(xmlfile, FileMode.Create);
            new XmlSerializer(typeof(FileList)).Serialize(stream, filelist);

            Debug.WriteLine("Written xml file:" + s.Elapsed.ToString());
        }


        private void button2_Click(object sender, System.EventArgs e)
        {
            XDocument docs = XDocument.Load(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + xmlfile);

            var dd = from d in docs.Descendants("FileInfoWrapper")
                     //where d.Element("Extension").Value == ".xlsm"
                     select new Show
                     {
                         Name = (string)d.Element("Name"),
                         FullName = (string)d.Element("FullName"),
                         Size = (int)d.Element("Length"),
                         Extension = (string)d.Element("Extension"),
                         LastSaved = (DateTime)d.Element("LastWriteTime"),
                     };

            var doc = dd
                .GroupBy(d => new { d.Name, d.LastSaved })
                .OrderBy(d => d.Key.Name)
                .ThenBy(d => d.Key.LastSaved)
                .Select(d => new { Nm = d.Key.Name, ls = d.Key.LastSaved, thecount = d.Count() });

            var source = new BindingSource();
            source.DataSource = doc.ToList();

            dataGridView1.DataSource = source;

            MessageBox.Show(doc.Count().ToString());
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            Close();
        }

    }

    class Show
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public int Size { get; set; }
        public string Extension { get; set; }
        public DateTime LastSaved { get; set; }

    }

}
