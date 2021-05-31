using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBShowImage
{
    class CImageDir
    {
        public string DirName;  // 目錄名稱
        public List<string> FileNameList = new List<string>();

        // 取得目錄中的所有檔名
        public void GetFileNameList()
        {
            FileNameList.Clear();
            string[] files = Directory.GetDirectories(DirName);

            foreach(string file in files) {
                string dir = Path.GetFileName(file);
                FileNameList.Add(dir);
            }

            files = Directory.GetFiles(DirName);
            foreach(string f in files) {
                string file = Path.GetFileName(f);
                if(CheckFileType.IsImage(file) || CheckFileType.IsZip(file)) {
                    FileNameList.Add(file);
                }
            }
        }

        public bool IsZip(int index)
        {
            return CheckFileType.IsZip(FileNameList[index]);
        }
        public bool IsDir(int index)
        {
            string dir = Path.Combine(DirName, FileNameList[index]);
            return CheckFileType.IsDir(dir);
        }

    }
}
