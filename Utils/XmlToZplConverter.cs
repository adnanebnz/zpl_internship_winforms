using System.Xml.Linq;
using XmlToZpl.Processors;
using System;
using System.IO;
using System.Drawing;
using System.Text;
using System.Xml;

namespace XmlToZpl.Utils
{
    /// <summary>
    /// Converts XML documents to ZPL format.
    /// </summary>
    public class XmlToZplConverter
    {
        /// <summary>
        /// Converts XML data to ZPL (Zebra Programming Language) format for printing on Zebra printers.
        /// The method processes XML elements representing different items (e.g., text, barcodes, images)
        /// and generates corresponding ZPL commands.
        /// </summary>
        /// <param name="xmlFilePath">The path to the XML file containing the data to be converted.</param>
        /// <param name="dpi">The dpi used (203 or 300).</param>
        /// <returns>A string containing the generated ZPL commands.</returns>

        public static string ConvertDynamicXmlToZpl(string xmlFilePath, int dpi)
        {
            string xmlContent = FileUtil.ReadFile(xmlFilePath);
            XDocument xml;
            if (!String.IsNullOrEmpty(xmlContent))
            {
                xml = XDocument.Parse(xmlContent);
            }
            else
            {
                return "";
            }

            string zplRes = "^XA\n";
            zplRes += "^CI28^CWZ,E:MICROSS.TTF";

            foreach (var item in xml.Root?.Element("Items")?.Elements())
            {
                int x = PointsConverter.ConvertDimension(item.Attribute("X")?.Value, dpi);
                int y = PointsConverter.ConvertDimension(item.Attribute("Y")?.Value, dpi);
                int width = PointsConverter.ConvertDimension(item.Attribute("Width")?.Value, dpi);
                int height = PointsConverter.ConvertDimension(item.Attribute("Height")?.Value, dpi);
                int barHeight = PointsConverter.ConvertDimension(item.Attribute("BarHeight")?.Value, dpi);
                int strokeThickness = PointsConverter.ConvertDimension(item.Attribute("StrokeThickness")?.Value, dpi);

                string name = item.Attribute("Name")?.Value.Trim();


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

                double fontSizeScalingFactor = zplFontSize / baseFontSize;

                double adjustedCharWidth = baseCharWidthInDots * fontSizeScalingFactor;


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
                        if (name != "")
                        {
                            zplRes += "^FO" + x + "," + y + "^PA0,1,1,1^A" + "Z" + ",N," + zplFontSize + foreColor + "^FD" + "@" + name + "@" + "^FS";
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
                                    zplRes += $"^FO{x},{y}^BQ{orientation},,6^FDQA,{code}^FS\n";
                                }
                                else
                                {
                                    zplRes += $"^FO{x},{y}^BQ{orientation},,6^FDQA,@{name}@^FS\n";
                                    ;
                                }
                                break;
                            case "Code128":
                                if (code != "")
                                {
                                    zplRes += $"^FO{x},{y}^BY3,,{barHeight}^BC{orientation},{barHeight},Y,N,N^FD{code}^FS\n";
                                }
                                else
                                {
                                    zplRes += $"^FO{x},{y}^BY3,,{barHeight}^BC{orientation},{barHeight},Y,N,N^FD@{name}@^FS\n";
                                }
                                break;
                            case "Codabar":
                                if (code != "")
                                {
                                    zplRes += $"^FO{x},{y}^BY3,,{barHeight}^BK{orientation},N,{barHeight},Y,N^FD{code}^FS\n";
                                }
                                else
                                {
                                    zplRes += $"^FO{x},{y}^BY3,,{barHeight}^BK{orientation},N,{barHeight},Y,N^FD@{name}@^FS\n";
                                }
                                break;
                            case "Code11":
                                zplRes += $"^FO{x},{y}^BY3,,{barHeight}^B1{orientation},N,{barHeight},Y,N^FD@{name}@^FS\n";
                                break;
                            case "Code93":
                                zplRes += $"^FO{x},{y}^BY3,,{barHeight}^B9{orientation},N,{barHeight},Y,N^FD@{name}@^FS\n";
                                break;
                            case "Code39":
                                zplRes += $"^FO{x},{y}^BY3,,{barHeight}^B3{orientation},N,{barHeight},Y,N^FD@{name}@^FS\n";
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
                            originalImage = ImageUtil.ConvertToMonochrome(originalImage);
                            Bitmap resizedImage = new Bitmap(originalImage, width, height);

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

                            string hexData = "";
                            for (int i = 0; i < binaryData.Length; i += 8)
                            {
                                string byteString = binaryData.Substring(i, 8);
                                hexData += $"{Convert.ToByte(byteString, 2):X2}";
                            }

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
        public static byte[] TextToByte(String text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        public static bool CheckIfXmlHasImage(string filePath)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);

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
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);

                XmlNode imageNode = xmlDoc.SelectSingleNode("//ImageItem[@Source='File']");
                if (imageNode != null)
                {
                    XmlAttribute sourceDataAttribute = imageNode.Attributes["SourceData"];
                    if (sourceDataAttribute != null)
                    {
                        return sourceDataAttribute.Value;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while reading XML file '{filePath}': {ex.Message}");
                return null;
            }
        }
        /// <summary>
        /// Modifies the image path based on specific criteria or conditions.
        /// This method is typically used to adjust the file path of an image before it is processed or displayed,
        /// ensuring the path meets certain requirements or conforms to a specific format.
        /// </summary>
        /// <param name="originalPath">The original file path of the image.</param>
        /// <returns>The modified image path that meets the specified criteria or conditions.</returns>
        public static void ModifyImagePath(string xmlFilePath, string newImagePath)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlFilePath);

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