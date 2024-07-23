using System.IO;

namespace XmlToZpl.Utils
{
    public static class FileUtil
    {

        public static string ReadFile(string filePath)
        {
            string result;
            using (StreamReader reader = new StreamReader(filePath))
            {
                result = reader.ReadToEnd();
                
                reader.Close();
            }
            return result;
        }

        public static void WriteInFile(string filePath, string content)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                writer.Write(content);
                writer.Close();
            }
        }
    }
}