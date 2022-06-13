using Application.Constants;
using System.Xml.Linq;

namespace Application.Contexts
{
    public class Context
    {
        public XDocument BlocksXml { get; }
        public XDocument HousesXml { get; }
        public XDocument HouseToBlocksXml { get; }

        public Context()
        {
            BlocksXml = XDocument.Load(Paths.Blocks);
            HousesXml = XDocument.Load(Paths.Houses);
            HouseToBlocksXml = XDocument.Load(Paths.HouseToBlocks);
        }
    }
}
