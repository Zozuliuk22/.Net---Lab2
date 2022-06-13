using Application.Constants;
using Application.Models;
using System.Collections.Generic;
using System.Xml;

namespace Application.Seeder
{
    public static class DataSeeder
    {
        public static void Seed()
        {
            SeedList<Block>(Paths.Blocks, SeedingDataContext.Blocks);
            SeedList<House>(Paths.Houses, SeedingDataContext.Houses);
            SeedList<HouseToBlock>(Paths.HouseToBlocks, SeedingDataContext.HouseToBlocks);
        }

        private static void SeedList<T>(string path, List<T> list)
        {
            var settings = new XmlWriterSettings();
            settings.Indent = true;

            var type = typeof(T);
            var properties = type.GetProperties();

            using (var xmlWriter = XmlWriter.Create(path, settings))
            {
                xmlWriter.WriteStartElement($"{type.Name}s");

                foreach (var item in list)
                {
                    xmlWriter.WriteStartElement($"{type.Name}");

                    foreach (var property in properties)
                    {
                        var value = property.GetValue(item).ToString();
                        xmlWriter.WriteElementString(property.Name, value);
                    }

                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();
            }
        }
    }
}
