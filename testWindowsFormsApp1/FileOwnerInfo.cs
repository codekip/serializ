using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using System;
using System.IO;
using System.Security.Principal;

namespace testWindowsFormsApp1
{
    // from http://forum.codecall.net/topic/54131-getting-file-and-directory-owners/

    public static class FileOwnerInfo
    {
        public static string Getowner(string filepath)
        {
            try
            {
                // string Target_Dir = null;
                // DirectoryInfo di = new DirectoryInfo(Target_Dir);
                FileInfo f = new FileInfo(filepath);
                // System.Security.AccessControl.DirectorySecurity ds = di.GetAccessControl();
                System.Security.AccessControl.FileSecurity fs = f.GetAccessControl();
                // NTAccount owner = (NTAccount)ds.GetOwner(typeof(NTAccount));
                NTAccount owner = (NTAccount)fs.GetOwner(typeof(NTAccount));
                return owner.ToString().Split('\\')[1]; //To remove "EU\ in EU\sawe.nk"
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string LastSavedBy(string path)
        {
            string lastSavedBy = null;
            using (var so = ShellObject.FromParsingName(path))
            {
                var lastAuthorProperty = so.Properties.GetProperty(SystemProperties.System.Document.LastAuthor);
                if (lastAuthorProperty != null)
                {
                    var lastAuthor = lastAuthorProperty.ValueAsObject;
                    if (lastAuthor != null)
                    {
                        lastSavedBy = lastAuthor.ToString();
                    }
                }
            }

            return lastSavedBy;
        }
    }
}
