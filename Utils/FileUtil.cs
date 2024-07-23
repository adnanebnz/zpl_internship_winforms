using System;
using System.IO;

namespace XmlToZpl.Utils
{
    public static class FileUtil
    {

        public static string ReadFile(string filePath)
        {
            string result = "";
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    result = reader.ReadToEnd();

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;

        }

        public static bool WriteInFile(string filePath, string content)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    writer.Write(content);
                    writer.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}