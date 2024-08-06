using System.Text;
using System.Drawing;
using System;
namespace XmlToZpl.Utils
{
    public static class ImageUtil
    {
        public static string ConvertToBinaryData(Bitmap image)
        {
            StringBuilder binaryData = new StringBuilder();
            try
            {

                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        Color pixelColor = image.GetPixel(x, y);
                        // Convert pixel to grayscale using the formula: 0.3*R + 0.59*G + 0.11*B
                        int grayScale = (int)((pixelColor.R * 0.3) + (pixelColor.G * 0.59) + (pixelColor.B * 0.11));
                        // If the grayscale value is greater than 128, consider it "white" (0), else "black" (1)
                        binaryData.Append(grayScale > 128 ? '0' : '1');
                    }
                }

                return binaryData.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        public static string BinaryStringToHexString(string binaryData)
        {
            StringBuilder hexString = new StringBuilder();
            try
            {
                // Ensure the binary data length is a multiple of 8
                int paddingLength = 8 - (binaryData.Length % 8);
                if (paddingLength > 0 && paddingLength < 8)
                {
                    binaryData = binaryData.PadRight(binaryData.Length + paddingLength, '0');
                }

                for (int i = 0; i < binaryData.Length; i += 8)
                {
                    // Safely create a substring for each byte of data
                    string byteString = binaryData.Substring(i, 8);
                    hexString.AppendFormat("{0:X2}", Convert.ToByte(byteString, 2));
                }

                return hexString.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        public static Bitmap ConvertToMonochrome(Bitmap originalImage)
        {
            try
            {
                int width = originalImage.Width;
                int height = originalImage.Height;
                Bitmap monochromeImage = new Bitmap(width, height);

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        // Get the pixel's color.
                        Color originalColor = originalImage.GetPixel(x, y);

                        int grayScale = (int)((originalColor.R * 0.3) + (originalColor.G * 0.59) + (originalColor.B * 0.11));

                        Color bwColor = grayScale > 128 ? Color.White : Color.Black;

                        monochromeImage.SetPixel(x, y, bwColor);
                    }
                }

                return monochromeImage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return originalImage;
            }

        }

    }
}