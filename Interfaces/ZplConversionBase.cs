namespace XmlToZpl.Interfaces
{
    public abstract class ZplConversionBase
    {

        public abstract bool ConvertXmlToZpl(string xmlFilePath, string zplOutputFile);
        public abstract string GetZplCode(string xmlFilePath);

    }
}