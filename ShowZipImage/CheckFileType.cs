using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShowZipImage
{
    static public class CheckFileType
    {
        static public bool IsZip(string file)
        {
            return file.EndsWith(".zip", true, null);
        }

        public static bool IsDir(string file)
        {
            return Directory.Exists(file);
        }

        public static bool IsImage(string file)
        {
            if(file.EndsWith(".gif", true, null)) {
                return true;
            } else if(file.EndsWith(".jpg", true, null)) {
                return true;
            } else if(file.EndsWith(".tif", true, null)) {
                return true;
            } else {
                return false;
            }
        }
    }
}
