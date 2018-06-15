using System.IO;
using System.IO.Compression;
using System.Text;
using System.Xml;

namespace CraftTheWorldEditor
{
    internal static class ZipHelper
    {
        #region Methods

        public static void SetString(this ZipArchiveEntry entry, string value)
        {
            using (Stream stream = entry.Open())
            {
                byte[] data = Encoding.ASCII.GetBytes(value);

                stream.Seek(0, SeekOrigin.Begin);
                stream.Write(data, 0, data.Length);
                stream.SetLength(stream.Position);
            }
        }

        public static string ReadString(this ZipArchiveEntry entry)
        {
            using (StreamReader reader = new StreamReader(entry.Open()))
            {
                return reader.ReadToEnd();
            }
        }

        public static XmlDocument ReadDocument(this ZipArchiveEntry entry)
        {
            using (Stream stream = entry.Open())
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(stream);

                return doc;
            }
        }

        public static XmlDocument ReadDocument(this ZipArchive archive, string path)
        {
            ZipArchiveEntry entry = archive.GetEntry(path);
            if (entry != null)
            {
                using (Stream stream = entry.Open())
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(stream);

                    return doc;
                }
            }

            return null;
        }

        public static string ReadString(this ZipArchive archive, string path)
        {
            ZipArchiveEntry entry = archive.GetEntry(path);
            if (entry != null)
            {
                using (StreamReader reader = new StreamReader(entry.Open()))
                {
                    return reader.ReadToEnd();
                }
            }

            return null;
        }

        #endregion
    }
}