namespace ML.SavingSystem
{
    public class FileHandlerFactory
    {
        public FileHandler GetFileHandler(FileHandlerType fileHandlerType,
        string fileName, string filePath, bool useEncryption, bool useCloudSaveLoadSystem)
        {
            switch (fileHandlerType)
            {
                case FileHandlerType.JSON:
                    return new JSONFileHandler(fileName, filePath, useEncryption, useCloudSaveLoadSystem);
                default:
                    return null;
            }
        }
    }
    public enum FileHandlerType
    {
        JSON
    }

}