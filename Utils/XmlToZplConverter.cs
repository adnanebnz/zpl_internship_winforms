using System.Xml.Linq;
using XmlToZpl.Processors;
using System;
using System.IO;
using System.Drawing;
using System.Text;
using System.Xml;

namespace XmlToZpl.Utils
{
    public class XmlToZplConverter
    {
        public static string ConvertDynamicXmlToZpl(string xmlFilePath)
        {
            var xml = XDocument.Load(xmlFilePath);

            string zplRes = "^XA\n";

            foreach (var item in xml.Root?.Element("Items")?.Elements())
            {
                int x = PointsConverter.ConvertDimension(item.Attribute("X")?.Value);
                int y = PointsConverter.ConvertDimension(item.Attribute("Y")?.Value);
                int width = PointsConverter.ConvertDimension(item.Attribute("Width")?.Value);
                int height = PointsConverter.ConvertDimension(item.Attribute("Height")?.Value);
                int strokeThickness = PointsConverter.ConvertDimension(item.Attribute("StrokeThickness")?.Value);

                string name = item.Attribute("Name")?.Value;


                string fontString = item.Attribute("Font")?.Value;
                string foreColorXml = item.Attribute("ForeColor")?.Value;
                string fontName = "0";
                string isBold = "False";
                string isItalic = "False";
                string isUnderline = "False";
                int fontSize = 32;
                if (fontString != null)
                {
                    string[] fontParts = fontString.Split(',');
                    fontName = fontParts.Length > 0 ? fontParts[0] : "0";
                    fontSize = fontParts.Length > 1 ? int.Parse(fontParts[1]) : 32;
                    isBold = fontParts.Length > 2 ? fontParts[2].ToString() : "False";
                    isItalic = fontParts.Length > 3 ? fontParts[3].ToString() : "False";
                    isUnderline = fontParts.Length > 4 ? fontParts[4].ToString() : "False";
                }
                double zplFontSize = Math.Floor(fontSize * 2.82);

                int baseFontSize = 12;
                int baseCharWidthInDots = 3;

                var fontSizeScalingFactor = zplFontSize / baseFontSize;

                var adjustedCharWidth = baseCharWidthInDots * fontSizeScalingFactor;

                switch (item.Name.LocalName)
                {
                    case "RectangleShapeItem":
                        zplRes += $"^FO{x},{y}^GB{width},{height},{strokeThickness}^FS\n";
                        break;
                    case "TextItem":
                        string text = item.Attribute("Text")?.Value;
                        text = PatternProcessor.DecodeString(text);
                        var foreColor = foreColorXml == "White" ? "^FR" : "";


                        // if (isUnderline == "True")
                        // {
                        //     zplRes += "^FO" + x + "," + y + "^A" + fontName + ",N," + zplFontSize + foreColor + "^FD" + text + "^FS";
                        //     zplRes += $"^FO{x},{underlineY}^GB{textWidth},2,2^FS";
                        // }
                        // if (isBold == "True")
                        // {
                        //     zplRes += $"^FO{x},{y}^A{fontName},N,{zplFontSize}^FB{width},1,0,C^FD{text}^FS";
                        // }
                        // if (isItalic == "True")
                        // {
                        //     zplRes += $"^FO{x},{y}^A{fontName},N,{zplFontSize}^FB{width},1,0,C^FD{text}^FS";
                        // }
                        // else
                        // {
                        if (text != "null")
                        {
                            zplRes += "^FO" + x + "," + y + "^A" + "0" + ",N," + zplFontSize + foreColor + "^FD" + text + "^FS";
                        }
                        else
                        {
                            zplRes += "^FO" + x + "," + y + "^A" + "0" + ",N," + zplFontSize + foreColor + "^FD" + "@" + name + "@" + "^FS";
                        }
                        // }

                        zplRes += "\n";
                        break;
                    case "BarcodeItem":
                        string code = item.Attribute("Code")?.Value;
                        var orientationAngle = item.Attribute("RotationAngle")?.Value;
                        code = PatternProcessor.DecodeString(code);
                        string symbology = item.Attribute("Symbology")?.Value;

                        // ROTATION OF THE CODE
                        string orientation = PatternProcessor.RotateCode(orientationAngle);


                        switch (symbology)
                        {
                            case "QRCode":
                                if (code != "")
                                {
                                    zplRes += $"^FO{x},{y}^BQ{orientation},3,{height}^FDQA,{code}^FS\n";
                                }
                                else
                                {
                                    zplRes += $"^FO{x},{y}^BQ{orientation},1,{height}^FDQA,@{name}@^FS\n";
                                }
                                break;
                            case "Code128":
                                if (code != "")
                                {
                                    zplRes += $"^FO{x},{y}^BY3,,{height}^BC{orientation},{height},Y,N,N^FD{code}^FS\n";
                                }
                                else
                                {
                                    zplRes += $"^FO{x},{y}^BY3,,{height}^BC{orientation},{height},Y,N,N^FD@{name}@^FS\n";
                                }
                                break;
                            case "Codabar":
                                if (code != "")
                                {
                                    zplRes += $"^FO{x},{y}^BY3,,{height}^B3{orientation},N,{height},Y,N^FD{code}^FS\n";
                                }
                                else
                                {
                                    zplRes += $"^FO{x},{y}^BY3,,{height}^B3{orientation},N,{height},Y,N^FD@{name}@^FS\n";
                                }
                                break;
                            case "Code11":
                                zplRes += $"^FO{x},{y}^BY3,,{height}^B1{orientation},N,{height},Y,N^FD@{name}@^FS\n";
                                break;
                            case "Code93":
                                zplRes += $"^FO{x},{y}^BY3,,{height}^B9{orientation},N,{height},Y,N^FD@{name}@^FS\n";
                                break;
                            case "Code39":
                                zplRes += $"^FO{x},{y}^BY3,,{height}^B3{orientation},N,{height},Y,N^FD@{name}@^FS\n";
                                break;
                            case "Pdf417":
                                zplRes += $"^FO{x},{y}^B7{orientation},3,8,0,0,N^FD@{name}@^FS\n";
                                break;
                            case "DataMatrix":

                                zplRes += $"^FO{x},{y}^BX{orientation},6,200^FD@{name}@^FS\n";
                                break;

                            case "AztecCode":
                                zplRes += $"^MTD\n^BO,10,N,250,N,1,0\n^FO{x},{y}^FD@{name}@^FS\n";
                                break;
                            default:
                                zplRes += $"^FO{x},{y}^FDUnsupported symbology: {symbology}^FS\n";
                                break;
                        }

                        break;

                    case "ImageItem":
                        string imagePath = item.Attribute("SourceData")?.Value;
                        if (File.Exists(imagePath))
                        {
                            Bitmap originalImage = new Bitmap(imagePath);

                            // Convert image to monochrome
                            originalImage = ImageUtil.ConvertToMonochrome(originalImage);

                            // Resize the image
                            Bitmap resizedImage = new Bitmap(originalImage, width,height);

                            // Convert resized image to binary data
                            string binaryData = "";
                            for (int k = 0; k < height; k++)
                            {
                                for (int l = 0; l < width; l++)
                                {
                                    Color pixel = resizedImage.GetPixel(l, k);
                                    binaryData += pixel.R > 128 ? '0' : '1';
                                }
                                binaryData += new string('0', (int)Math.Ceiling(width / 8.0) * 8 - width);
                            }

                            // Convert binary data to hexadecimal string
                            string hexData = "";
                            for (int i = 0; i < binaryData.Length; i += 8)
                            {
                                string byteString = binaryData.Substring(i, 8);
                                hexData += $"{Convert.ToByte(byteString, 2):X2}";
                            }

                            // Calculate bytes and rows for ZPL
                            int rowBytes = (int)Math.Ceiling(width / 8.0);
                            int totalBytes = rowBytes * height;

                            zplRes += $"~DGimage.GRF,{totalBytes},{rowBytes},{hexData}\n";
                            zplRes += $"^FO{x},{y}^XGimage.GRF,1,1^FS\n";
                        }
                        else
                        {
                            zplRes += $"^FO{x},{y}^FD[ERROR: Image file not found]^FS\n";
                        }
                        break;
                }
            }
            zplRes += "^XZ\n";
            Console.WriteLine("FINISHED CONVERTING!");
            return zplRes;

        }
        private byte[] textToByte(String text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        public static bool CheckIfXmlHasImage(string filePath)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);

                // Find any ImageItem nodes with SourceData attribute
                XmlNodeList imageNodes = xmlDoc.SelectNodes("//ImageItem[@SourceData]");
                return imageNodes.Count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while checking XML file: {ex.Message}");
                return false;
            }
        }

        public static string zplImagePath(string filePath)
        {
            try
            {
                // Load XML document from file
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);

                // Find the ImageItem node and get SourceData attribute value
                XmlNode imageNode = xmlDoc.SelectSingleNode("//ImageItem[@Source='File']");
                if (imageNode != null)
                {
                    XmlAttribute sourceDataAttribute = imageNode.Attributes["SourceData"];
                    if (sourceDataAttribute != null)
                    {
                        return sourceDataAttribute.Value;
                    }
                }
                // If ImageItem with Source='File' or SourceData attribute not found, return null
                return null;
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., file not found, XML format error)
                Console.WriteLine($"Error while reading XML file '{filePath}': {ex.Message}");
                return null;
            }
        }

        public static void ModifyImagePath(string xmlFilePath, string newImagePath)
        {
            try
            {
                // Load XML document from file
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlFilePath);

                // Find the ImageItem node and update SourceData attribute
                XmlNode imageNode = xmlDoc.SelectSingleNode("//ImageItem[@Source='File']");
                if (imageNode != null)
                {
                    XmlAttribute sourceDataAttribute = imageNode.Attributes["SourceData"];
                    if (sourceDataAttribute != null)
                    {
                        sourceDataAttribute.Value = newImagePath;
                    }
                    else
                    {
                        // If SourceData attribute doesn't exist, create and add it
                        XmlElement element = (XmlElement)imageNode;
                        sourceDataAttribute = element.OwnerDocument.CreateAttribute("SourceData");
                        sourceDataAttribute.Value = newImagePath;
                        element.Attributes.Append(sourceDataAttribute);
                    }

                    // Save XML back to file
                    xmlDoc.Save(xmlFilePath);
                    Console.WriteLine($"Image path updated successfully in '{xmlFilePath}'.");
                }
                else
                {
                    Console.WriteLine("ImageItem with Source='File' not found in XML.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error modifying XML file '{xmlFilePath}': {ex.Message}");
            }
        }
    }
}