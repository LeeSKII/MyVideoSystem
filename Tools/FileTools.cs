using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class FileTools
    {
        public static void GetFilesByPathAndExt(ref List<string> res,string path,string ext="*")
        {           
            DirectoryInfo theFolder = new DirectoryInfo(@path);

            //遍历文件
            foreach (FileInfo NextFile in theFolder.GetFiles(ext))
            {
                res.Add(Path.GetFileName(NextFile.FullName));
            }

            //遍历文件夹
            foreach (DirectoryInfo NextFolder in theFolder.GetDirectories())
            {
                GetFilesByPathAndExt(ref res, NextFolder.FullName,ext);
            }
        }
        public static void GetFileFullPathByfileNameAndParentPath(string parentPath,string fileName,ref string resFileFullName)
        {
            DirectoryInfo dir = new DirectoryInfo(parentPath);
            FileInfo[] files = dir.GetFiles();
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (var file in files)
            {
                string name = Path.GetFileName(file.FullName);
                if(name.Equals(fileName))
                {
                    resFileFullName = file.FullName;
                    return;
                }
            }
            foreach (var subDir in dirs)
            {
                if (string.IsNullOrEmpty(resFileFullName))
                {
                    GetFileFullPathByfileNameAndParentPath(subDir.FullName, fileName, ref resFileFullName);
                }
            }          
        }

    }
}
