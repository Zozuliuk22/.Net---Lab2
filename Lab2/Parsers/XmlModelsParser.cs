using Application.Models;
using Application.Enums;
using System;
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

            model.InhabitantsNumber = GeneralParser.ParseInt(xElement.Element("InhabitantsNumber")?.Value);
            model.Area = GeneralParser.ParseDouble(xElement.Element("Area")?.Value);

            return model;
        }

        public static House ToHouse(this XElement xElement)
        {
            var model = new House()
            {
                Code = xElement.Element("Code")?.Value,                
            };

            model.FloatsNumber = GeneralParser.ParseInt(xElement.Element("FloatsNumber")?.Value);
            model.EntrencesNumber = GeneralParser.ParseInt(xElement.Element("EntrencesNumber")?.Value);
            model.CreationDate = GeneralParser.ParseDateTimeOffset(xElement.Element("CreationDate")?.Value);
            model.ProjectType = GeneralParser.ParseProjectType(xElement.Element("ProjectType")?.Value);

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
