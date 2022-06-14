using Application.Models;
using System.Xml.Linq;

namespace Application.Parsers
{
    public static class XmlModelsParser
    {
        public static Block ToBlock(this XElement xElement)
        {
            var model = new Block()
            {
                Code = xElement.Element("Code")?.Value,
                Name = xElement.Element("Name")?.Value,
                AdministrationAddress = xElement.Element("AdministrationAddress")?.Value                
            };

            model.InhabitantsNumber = Parser.ToInt(xElement.Element("InhabitantsNumber")?.Value);
            model.Area = Parser.ToDouble(xElement.Element("Area")?.Value);

            return model;
        }

        public static House ToHouse(this XElement xElement)
        {
            var model = new House()
            {
                Code = xElement.Element("Code")?.Value,                
            };

            model.FloatsNumber = Parser.ToInt(xElement.Element("FloatsNumber")?.Value);
            model.EntrencesNumber = Parser.ToInt(xElement.Element("EntrencesNumber")?.Value);
            model.CreationDate = Parser.ToDateTimeOffset(xElement.Element("CreationDate")?.Value);
            model.ProjectType = Parser.ToProjectType(xElement.Element("ProjectType")?.Value);

            return model;
        }

        public static HouseToBlock ToHouseToBlock(this XElement xElement)
        {
            var model = new HouseToBlock()
            {
                BlockCode = xElement.Element("BlockCode")?.Value,
                HouseCode = xElement.Element("HouseCode")?.Value,
            };
            return model;
        }
    }
}
