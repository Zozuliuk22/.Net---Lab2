using Application.Constants;
using Application.Enums;
using Application.Models;
using Application.XmlProcessors;
using System;
using System.Linq;

namespace Application.ConsoleProcessors
{
    public static class ConsoleReader
    {
        public static Block ReadBlock(XmlModelReader xmlReader)
        {
            Console.Write("Please, enter the Code: ");
            var code = Console.ReadLine();

            while(xmlReader.GetBlocks(Paths.Blocks).FirstOrDefault(b => b.Code == code) != null)
            {
                Console.Write("Please, enter the Code: ");
                code = Console.ReadLine();
            }

            Console.Write("Please, enter the Name: ");
            var name = Console.ReadLine();

            Console.Write("Please, enter the Administration Address: ");
            var address = Console.ReadLine();

            Console.Write("Please, enter the Inhabitants Number: ");
            var inhabitantsNumberStr = Console.ReadLine();
            int inhabitantsNumber = 0;

            while(!Int32.TryParse(inhabitantsNumberStr, out inhabitantsNumber) && inhabitantsNumber <= 0)
            {
                Console.Write("Please, enter the Inhabitants Number: ");
                inhabitantsNumberStr = Console.ReadLine();
            }

            Console.Write("Please, enter the Area like 10,12: ");
            var areaStr = Console.ReadLine();
            double area = 0;

            while (!Double.TryParse(areaStr, out area) && area <= 0)
            {
                Console.Write("Please, enter the Area like 10,12: ");
                areaStr = Console.ReadLine();
            }

            return new Block()
            {
                Code = code,
                Name = name,
                AdministrationAddress = address,
                Area = area,
                InhabitantsNumber = inhabitantsNumber
            };
        }

        public static House ReadHouse(XmlModelReader xmlReader)
        {
            Console.Write("Please, enter the Code: ");
            var code = Console.ReadLine();

            while (xmlReader.GetBlocks(Paths.Houses).FirstOrDefault(h => h.Code == code) != null)
            {
                Console.Write("Please, enter the Code: ");
                code = Console.ReadLine();
            }            

            Console.Write("Please, enter the Floats Number: ");
            var floatsNumberStr = Console.ReadLine();
            int floatsNumber = 0;

            while (!Int32.TryParse(floatsNumberStr, out floatsNumber) && floatsNumber <= 0)
            {
                Console.Write("Please, enter the Floats Number: ");
                floatsNumberStr = Console.ReadLine();
            }

            Console.Write("Please, enter the Entrences Number: ");
            var entrencesNumberStr = Console.ReadLine();
            int entrencesNumber = 0;

            while (!Int32.TryParse(entrencesNumberStr, out entrencesNumber) && entrencesNumber <= 0)
            {
                Console.Write("Please, enter the Entrences Number: ");
                entrencesNumberStr = Console.ReadLine();
            }

            foreach (var type in Enum.GetValues(typeof(ProjectType)))
                Console.WriteLine(type);
            Console.Write("\nPlease, enter the Project Type: ");
            var projectTypeStr = Console.ReadLine();
            ProjectType projectType;

            while (!ProjectType.TryParse(projectTypeStr, out projectType))
            {
                foreach (var type in Enum.GetValues(typeof(ProjectType)))
                    Console.WriteLine(type);
                Console.Write("\nPlease, enter the Project Type: ");
                projectTypeStr = Console.ReadLine();
            }


            Console.Write("Please, enter the Creation Date in dd/mm/yyyy format: ");
            var dateStr = Console.ReadLine();
            DateTimeOffset date;

            while (!DateTimeOffset.TryParse(dateStr, out date) && date.CompareTo(DateTimeOffset.Now) > 0)
            {
                Console.Write("Please, enter the Creation Date in dd/mm/yyyy format: ");
                dateStr = Console.ReadLine();
            }

            return new House()
            {
                Code = code,
                FloatsNumber = floatsNumber,
                EntrencesNumber = entrencesNumber,
                CreationDate = date,
                ProjectType = projectType
            };
        }

        public static HouseToBlock ReadHouseToBlock(XmlModelReader xmlReader)
        {
            var houseToBlock = xmlReader.GetHouseToBlocks(Paths.HouseToBlocks);
            var resultHouseToBlock = houseToBlock;

            string blockCode = String.Empty;
            string houseCode = String.Empty;

            while (resultHouseToBlock.Count > 0)
            {
                Console.Write("Please, enter the blockCode: ");
                blockCode = Console.ReadLine();
                var resultBlock = xmlReader.GetBlocks(Paths.Blocks)
                                           .FirstOrDefault(b => b.Code == blockCode);

                while (resultBlock == null)
                {
                    Console.Write("Please, enter the blockCode: ");
                    blockCode = Console.ReadLine();
                    resultBlock = xmlReader.GetBlocks(Paths.Blocks)
                                           .FirstOrDefault(b => b.Code == blockCode);
                }

                Console.Write("Please, enter the houseCode: ");
                houseCode = Console.ReadLine();
                var resultHouse = xmlReader.GetHouses(Paths.Houses)
                                           .FirstOrDefault(h => h.Code == houseCode);

                while (resultHouse == null)
                {
                    Console.Write("Please, enter the houseCode: ");
                    houseCode = Console.ReadLine();
                    resultHouse = xmlReader.GetHouses(Paths.Houses)
                                               .FirstOrDefault(h => h.Code == houseCode);
                }

                resultHouseToBlock = houseToBlock.Where(hb => hb.BlockCode == blockCode && 
                                                              hb.HouseCode == houseCode)
                                                 .ToList();
            }


            return new HouseToBlock()
            {
                HouseCode = houseCode,
                BlockCode = blockCode
            };
        }
    }
}
