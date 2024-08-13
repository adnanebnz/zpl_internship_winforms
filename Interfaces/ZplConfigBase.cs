namespace XmlToZpl.Interfaces
{
    public abstract class ZplConfigBase
    {

        public abstract string SaveConfig(string xmlFilePath, string zplResult, string configName);

        public abstract bool DeleteLabelConfig(Models.Label label);
    }
}
