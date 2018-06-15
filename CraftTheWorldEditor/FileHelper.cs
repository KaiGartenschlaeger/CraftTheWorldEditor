using System.IO;
using System.Threading.Tasks;

namespace CraftTheWorldEditor
{
    internal class FileHelper
    {
        #region Helper

        public static Task<bool> CopyAsync(string sourcePath, string targetPath, bool overwriteFile)
        {
            return Task.Factory.StartNew(() =>
            {
                File.Copy(sourcePath, targetPath, overwriteFile);
                return true;
            });
        }

        #endregion
    }
}