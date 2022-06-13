using System.IO;
using System.Xml.Linq;

namespace Application.XmlProcessors
{
    public static class XmlModelLoader
    {
        public static XDocument LoadXDocument(string fileName)
        {
            if (!File.Exists(fileName)) return null;

            var xDocument = XDocument.Load(fileName);

            if (xDocument.Root == null) return null;

            return xDocument;
        }
    }
}
