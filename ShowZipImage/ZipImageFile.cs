using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBShowImage
{
    class CZipImageFile
    {
        public string FileName;
        public List<string> FileNameList = new List<string>();
        public Stream stream = null;

        // 取得壓縮檔中的所有檔名
        public void GetFileNameList()
        {
            FileNameList.Clear();
            using(ZipArchive archive = ZipFile.OpenRead(FileName)) 
            {
                foreach(ZipArchiveEntry entry in archive.Entries) {
                    if(CheckFileType.IsImage(entry.Name)) {
                        FileNameList.Add(entry.FullName);
                    }
                }
            }
        }
        public void OpenImageFile(string filename)
        {
            ZipArchive a = ZipFile.OpenRead(FileName);
            ZipArchiveEntry e = a.GetEntry(filename);
            if(stream != null) {
                stream.Dispose();
            }
            stream = e.Open();
        }
    }
}
