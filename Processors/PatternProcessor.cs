
using System;
using System.Collections.Generic;

namespace XmlToZpl.Processors
{
    public static class PatternProcessor
    {
        public static Dictionary<string, string> GetEncodedPatterns()
        {
            return new Dictionary<string, string>
        {
                    {"_x002F_", "/"}, {"_x0020_", " "},
                    {"_x0040_", "@"}, {"_x0026_", "&"},
                    {"_x0023_", "#"}, {"_x0025_", "%"},
                    {"_x0028_", "("}, {"_x0029_", ")"},
                    {"_x002D_", "-"}, {"_x002B_", "+"},
                    {"_x002E_", "."}, {"_x002C_", ","},
                    {"_x0021_", "!"}, {"_x003F_", "?"},
                    {"_x0022_", "\""}, {"_x0027_", "'"},
                    {"_x003A_", ":"}, {"_x003B_", ";"},
                    {"_x003D_", "="}, {"_x003C_", "<"},
                    {"_x003E_", ">"}, {"_x005B_", "["},
                    {"_x005D_", "]"}, {"_x007B_", "{"},
                    {"_x007D_", "}"}, {"_x005C_", "\\"},
                    {"_x007C_", "|"}, {"_x002A_", "*"},
                    {"_x00A3_", "£"}, {"_x20AC_", "€"},
                    {"_x00A5_", "¥"}, {"_x00A7_", "§"},
                    {"_x00A9_", "©"}, {"_x00AE_", "®"},
                    {"_x2122_", "™"}, {"_x0031_", "1"},
                    {"_x0032_", "2"}, {"_x0033_", "3"},
                    {"_x0034_", "4"}, {"_x0035_", "5"},
                    {"_x0036_", "6"}, {"_x0037_", "7"},
                    {"_x0038_", "8"}, {"_x0039_", "9"},
                    {"_x0030_", "0"}

        };
        }

        public static string DecodeString(string encodedString)
        {
            try
            {
                var patterns = GetEncodedPatterns();
                foreach (var pattern in patterns)
                {
                    encodedString = encodedString.Replace(pattern.Key, pattern.Value);
                }
                return encodedString;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }

        }

        public static string RotateCode(string rotationAngle)
        {
            switch (rotationAngle)
            {
                case "0":
                    return "N";
                case "90":
                    return "R";
                case "180":
                    return "I";
                case "270":
                    return "B";
                default:
                    return "N";
            }
        }
    }
}