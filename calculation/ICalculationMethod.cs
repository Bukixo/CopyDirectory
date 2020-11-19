namespace CopyDirectory.calculation
{
    interface ICalculationMethod
    {
        void CopyItems(string path, string targetPath);
        void CreateNewDirectory(string sourcePath, string targetPath);
        void FindFiles(string path, string targetPath);
        void FindFolders(string path, string targetPath);
    }
}