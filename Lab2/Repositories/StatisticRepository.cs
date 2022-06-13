using Application.Enums;
using Application.Models;
using Application.Parsers;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Application.Repositories
{
    public static class StatisticRepository
    {
        public static IEnumerable<HouseToBlock> GetHouseToBlocks(string fileName)
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

        public static IEnumerable<House> GetHouses(string fileName)
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

                model.FloatsNumber = GeneralParser.ParseInt(node["FloatsNumber"]?.InnerText);
                model.EntrencesNumber = GeneralParser.ParseInt(node["EntrencesNumber"]?.InnerText);
                model.CreationDate = GeneralParser.ParseDateTimeOffset(node["CreationDate"]?.InnerText);
                model.ProjectType = GeneralParser.ParseProjectType(node["ProjectType"]?.InnerText);

                result.Add(model);
            }

            return result;
        }

        public static IEnumerable<Block> GetBlocks(string fileName)
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

                model.InhabitantsNumber = GeneralParser.ParseInt(node["InhabitantsNumber"]?.InnerText);
                model.Area = GeneralParser.ParseDouble(node["Area"]?.InnerText);

                result.Add(model);
            }

            return result;
        }        
    }
}
