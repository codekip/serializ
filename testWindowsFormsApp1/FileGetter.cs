using System.Collections.Generic;
using System.IO;
using System.Linq;
using testWindowsFormsApp1.Properties;

namespace testWindowsFormsApp1
{
    public static class FileGetter
    {
        public static IEnumerable<FileInfo> FileInfoAllFiles()
        {
            return new DirectoryInfo(Settings.Default["TDBpath"].ToString()).EnumerateFiles("*.*", SearchOption.AllDirectories);
        }


        public static IEnumerable<FileInfo> FileinfoFilteredByExtension(IEnumerable<FileInfo> filelist, string filter)
        {
            return filelist.Where(f => f.Extension == filter).ToArray();

        }

        public static IEnumerable<FileInfo> FileinfoFilteredByName(IEnumerable<FileInfo> filelist, string filter)
        {
            return filelist.Where(f => f.FullName.ToUpperInvariant().Contains(filter.ToUpperInvariant())).ToArray();

        }
    }
}
