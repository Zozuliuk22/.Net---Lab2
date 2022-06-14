using Application.Models;
using Application.Parsers;
using System.Collections.Generic;
using System.Xml;

namespace Application.XmlProcessors
{
    public class XmlModelReader
    {
        public List<HouseToBlock> GetHouseToBlocks(string fileName)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);

            var result = new List<HouseToBlock>();

            foreach (XmlNode node in xmlDoc.DocumentElement)
            {
                result.Add(new HouseToBlock()
                {
                    BlockCode = node["BlockCode"]?.InnerText,
                    HouseCode = node["HouseCode"]?.InnerText
                });
            }

            return result;
        }

        public List<House> GetHouses(string fileName)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);

            var result = new List<House>();

            foreach (XmlNode node in xmlDoc.DocumentElement)
            {
                var model = new House()
                {
                    Code = node["Code"]?.InnerText,
                };

                model.FloatsNumber = Parser.ToInt(node["FloatsNumber"]?.InnerText);
                model.EntrencesNumber = Parser.ToInt(node["EntrencesNumber"]?.InnerText);
                model.CreationDate = Parser.ToDateTimeOffset(node["CreationDate"]?.InnerText);
                model.ProjectType = Parser.ToProjectType(node["ProjectType"]?.InnerText);

                result.Add(model);
            }

            return result;
        }

        public List<Block> GetBlocks(string fileName)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);

            var result = new List<Block>();

            foreach (XmlNode node in xmlDoc.DocumentElement)
            {
                var model = new Block()
                {
                    Code = node["Code"]?.InnerText,
                    Name = node["Name"]?.InnerText,
                    AdministrationAddress = node["AdministrationAddress"]?.InnerText
                };

                model.InhabitantsNumber = Parser.ToInt(node["InhabitantsNumber"]?.InnerText);
                model.Area = Parser.ToDouble(node["Area"]?.InnerText);

                result.Add(model);
            }

            return result;
        }
    }
}
