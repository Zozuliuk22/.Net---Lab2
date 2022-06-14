using Application.ConsoleProcessors;
using Application.Constants;
using Application.Contexts;
using Application.Models;
using Application.Properties;
using Application.Repositories;
using Application.XmlProcessors;
using System;

namespace Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ConsoleTexts.Title);

            var xmlReader = new XmlModelReader();
            var xmlWriter = new XmlModelWriter();

            //DataSeeder.Seed();
            ShowAll(xmlReader);

            Console.WriteLine(ConsoleTexts.Menu);

            Console.Write("\nEnter your choice: ");
            int choice = 0;  

            while (Int32.TryParse(Console.ReadLine(), out choice))
            {
                if (choice == 16)
                {
                    Console.WriteLine($"{ConsoleTexts.AdditionalMenu}\n");
                    Console.Write("\nEnter your inner choice: ");
                    int innerChoice = 0;

                    while (Int32.TryParse(Console.ReadLine(), out innerChoice))
                    {
                        if (innerChoice > 3)
                            break;
                        AdditionalMenu(innerChoice, xmlWriter, xmlReader);
                        Console.Write("\nEnter your inner choice: ");
                    }                    
                }
                    
                Menu(choice, xmlReader);
                Console.Write("\nEnter your choice: ");
            }
        }

        private static void ShowAll(XmlModelReader xmlReader)
        {
            var blocks = xmlReader.GetBlocks(Paths.Blocks);
            ConsoleViewer.ShowList<Block>(blocks);

            var houses = xmlReader.GetHouses(Paths.Houses);
            ConsoleViewer.ShowList<House>(houses);

            var houseToBlocks = xmlReader.GetHouseToBlocks(Paths.HouseToBlocks);
            ConsoleViewer.ShowList<HouseToBlock>(houseToBlocks);
        }

        private static void Menu(int choice, XmlModelReader xmlReader)
        {
            var city = new CityRepository(new Context());

            switch (choice)
            {
                case 1:
                    var result1 = city.GetAllBlocks();
                    ConsoleViewer.ShowAllBlocks(result1);
                    break;
                case 2:
                    var result2 = city.GetFullInfo();
                    ConsoleViewer.ShowCityFullInfo(result2);
                    break;
                case 3:
                    var result3 = city.GetCityArea();
                    ConsoleViewer.ShowCityArea(result3);
                    break;
                case 4:
                    var result4 = city.GetAreaByOnePerson();
                    ConsoleViewer.ShowCityAreaByOnePerson(result4);
                    break;
                case 5:
                    var result5 = city.GetHousesByTypes();
                    ConsoleViewer.ShowHousesByTypes(result5);
                    break;
                case 6:
                    var result6 = city.GetOneAndNineStoryHouses();
                    ConsoleViewer.ShowOneAndNineStoryHouses(result6);
                    break;
                case 7:
                    var result7 = city.GetNewHouses();
                    ConsoleViewer.ShowNewHouses(result7);
                    break;
                case 8:
                    var result8 = city.GetHappyHouses();
                    ConsoleViewer.ShowHappyHouses(result8);
                    break;
                case 9:
                    var result9 = city.GetSpecificTypes(5);
                    ConsoleViewer.ShowSpecificTypes(result9);
                    break;
                case 10:
                    var houses = xmlReader.GetHouses(Paths.Houses);
                    var index = new Random().Next(houses.Count);
                    var codeHouse = houses[index].Code;
                    var result10 = city.FindAdministrationAddress(codeHouse);
                    ConsoleViewer.ShowAdministrationAddress(codeHouse, result10);
                    break;
                case 11:
                    var result11 = city.GetTheBiggestBlockInfo();
                    ConsoleViewer.ShowTheBiggestBlockInfo(result11);
                    break;
                case 12:
                    var result12 = city.GetTopTenOldestHouses();
                    ConsoleViewer.ShowTopTenOldestHouses(result12);
                    break;
                case 13:
                    var blocks = xmlReader.GetBlocks(Paths.Blocks);
                    index = new Random().Next(blocks.Count);
                    var codeBlock = blocks[index].Code;
                    var result13 = city.GetPercentOfHighRiseByBlock(codeBlock);
                    ConsoleViewer.ShowPercentOfHighRise(codeBlock, result13);
                    break;
                case 14:
                    var result14 = city.GetBlocksWithMultiEntrencesHouses();
                    ConsoleViewer.ShowBlocksWithMultiEntrencesHouses(result14);
                    break;
                case 15:
                    var result15 = city.PlayInBlocks();
                    ConsoleViewer.ShowBlocksGameResult(result15);
                    break;
            }
        }

        private static void AdditionalMenu(int choice, XmlModelWriter xmlWriter, XmlModelReader xmlReader)
        {            
            switch (choice)
            {
                case 1:
                    var block = ConsoleReader.ReadBlock(xmlReader);
                    xmlWriter.AddElement<Block>(block, Paths.Blocks);
                    ConsoleViewer.ShowList<Block>(xmlReader.GetBlocks(Paths.Blocks));
                    break;
                case 2:
                    var house = ConsoleReader.ReadHouse(xmlReader);
                    xmlWriter.AddElement<House>(house, Paths.Houses);
                    ConsoleViewer.ShowList<House>(xmlReader.GetHouses(Paths.Houses));
                    break;
                case 3:
                    var houseToBlock = ConsoleReader.ReadHouseToBlock(xmlReader);
                    xmlWriter.AddElement<HouseToBlock>(houseToBlock, Paths.HouseToBlocks);
                    ConsoleViewer.ShowList<HouseToBlock>(xmlReader.GetHouseToBlocks(Paths.HouseToBlocks));
                    break;
            }
        }
    }
}
