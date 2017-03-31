using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using System.IO;

namespace testWindowsFormsApp1
{
    // from https://dzone.com/articles/extracting-file-metadata-c-and-0
    // https://channel9.msdn.com/coding4fun/blog/Something-that-should-be-in-everyones-pack-the-Windows-API-Code-Pack


    public static class FileOwnerInfo
    {
        public static string LastSavedBy(string path)
        {
            string lastSavedBy = null;

            if (File.Exists(path))
            {

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

            }
            return lastSavedBy;
        }
    }
}
