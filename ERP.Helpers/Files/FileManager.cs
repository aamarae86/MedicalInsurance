using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Front.Helpers.Files
{
    public static class FileManager
    {

        public static bool CreateFolder(string path)
        {
            try
            {
                if (Directory.Exists(path)) return true;

                Directory.CreateDirectory(path); return true;
            }
            catch (Exception x)
            {
                return false;
            }
        }
    }
}
