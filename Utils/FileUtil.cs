using System.IO;

namespace XmlToZpl.Utils
{
    public static class FileUtil
    {

        public static string ReadFile(string filePath)
        {
                return File.ReadAllText(filePath);
        }

        public static void WriteInFile(string filePath, string content)
        {
                File.WriteAllText(filePath, content);
        }
    }
}