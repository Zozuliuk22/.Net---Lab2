using Application.Models;
using Application.Parsers;
using System.Collections.Generic;
using System.Linq;

namespace Application.XmlProcessors
{
    public static class XmlModelReader
    {
        public static IEnumerable<HouseToBlock> GetHouseToBlocks(string fileName)
        {
            return XmlModelLoader.LoadXDocument(fileName)?
                            .Root
                            .Elements()
                            .Select(hb => hb.ToHouseToBlock());
        }

        public static IEnumerable<House> GetHouses(string fileName)
        {
            return XmlModelLoader.LoadXDocument(fileName)?
                            .Root
                            .Elements()
                            .Select(hb => hb.ToHouse());
        }

        public static IEnumerable<Block> GetBlocks(string fileName)
        {
            return XmlModelLoader.LoadXDocument(fileName)?
                            .Root
                            .Elements()
                            .Select(hb => hb.ToBlock());
        }        
    }
}
