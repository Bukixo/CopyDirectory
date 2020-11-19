using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CopyDirectory.calculation
{
    class CalculationMethod : ICalculationMethod
    {
        public void CreateNewDirectory(string sourcePath, string targetPath)
        {
            Directory.CreateDirectory(targetPath);

            if (Directory.Exists(sourcePath))
            {
                FindFolders(sourcePath, targetPath);
                //FindFiles(sourcePath, targetPath); // I found that I wasn't able to copy the files but by adding this method I found that it would create the files but 
                //leave out files that is why I decided to go with the folders instead and it's content
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        }


        public void FindFolders(string path, string targetPath)
        {
            string[] folders = Directory.GetDirectories(path, "*.*", SearchOption.AllDirectories);

            foreach (string folder in folders)
            {
                CopyItems(folder, targetPath);
            };
        }

        public void FindFiles(string path, string targetPath)
        {
            string[] filesInFolder = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            foreach (string file in filesInFolder)
            {
                CopyItems(file, targetPath);
            };
        }

        public void CopyItems(string path, string targetPath)
        {
            if (Directory.Exists(path))
            {
                var fileName = Path.GetFileName(path);
                var destFile = Path.Combine(targetPath, fileName);
                Console.WriteLine(destFile);
                Directory.CreateDirectory(destFile);
                //I also found that my copying only goes a layer deep.Here I tried to add a method should call on itself to check the filename for any items and create directories for that instance too 
                FindFiles(path, destFile);
            }

            if (File.Exists(path))
            {
                var fileName = Path.GetFileName(path);
                var destFile = Path.Combine(targetPath, fileName);
                Console.WriteLine(destFile);
                File.Copy(path, destFile, true);
            }

        }
    }
}
