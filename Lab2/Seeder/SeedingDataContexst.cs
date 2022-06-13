using Application.Enums;
using Application.Models;
using System;
using System.Collections.Generic;

namespace Application.Seeder
{
    public static class SeedingDataContext
    {
        public static List<House> Houses = new()
        {
            new House()
            {
                Code = "70/1",
                ProjectType = ProjectType.HighRise,
                FloatsNumber = 5,
                EntrencesNumber = 4,
                CreationDate = DateTimeOffset.Now.AddYears(-20)
            },
            new House()
            {
                Code = "70/3",
                ProjectType = ProjectType.HighRise,
                FloatsNumber = 5,
                EntrencesNumber = 4,
                CreationDate = DateTimeOffset.Now.AddYears(-30)
            },
            new House()
            {
                Code = "68/1",
                ProjectType = ProjectType.HighRise,
                FloatsNumber = 9,
                EntrencesNumber = 7,
                CreationDate = DateTimeOffset.Now.AddYears(-15)
            },
            new House()
            {
                Code = "47",
                ProjectType = ProjectType.HighRise,
                FloatsNumber = 9,
                EntrencesNumber = 7,
                CreationDate = DateTimeOffset.Now.AddYears(-2)
            },
            new House()
            {
                Code = "9",
                ProjectType = ProjectType.OneStory,
                FloatsNumber = 1,
                EntrencesNumber = 1,
                CreationDate = DateTimeOffset.Now.AddYears(-6)
            },
            new House()
            {
                Code = "8",
                ProjectType = ProjectType.OneStory,
                FloatsNumber = 1,
                EntrencesNumber = 1,
                CreationDate = DateTimeOffset.Now.AddYears(-9)
            },
            new House()
            {
                Code = "65a",
                ProjectType = ProjectType.Hostel,
                FloatsNumber = 9,
                EntrencesNumber = 1,
                CreationDate = DateTimeOffset.Now.AddYears(-20)
            },
            new House()
            {
                Code = "65b",
                ProjectType = ProjectType.Hostel,
                FloatsNumber = 5,
                EntrencesNumber = 1,
                CreationDate = DateTimeOffset.Now.AddYears(-41)
            },
            new House()
            {
                Code = "65c",
                ProjectType = ProjectType.Hostel,
                FloatsNumber = 5,
                EntrencesNumber = 1,
                CreationDate = DateTimeOffset.Now.AddYears(-11)
            },
            new House()
            {
                Code = "11/3",
                ProjectType = ProjectType.HighRise,
                FloatsNumber = 7,
                EntrencesNumber = 3,
                CreationDate = DateTimeOffset.Now.AddYears(-20)
            },
            new House()
            {
                Code = "11a",
                ProjectType = ProjectType.Cottage,
                FloatsNumber = 2,
                EntrencesNumber = 1,
                CreationDate = DateTimeOffset.Now.AddYears(-4)
            },
            new House()
            {
                Code = "11c",
                ProjectType = ProjectType.Cottage,
                FloatsNumber = 3,
                EntrencesNumber = 1,
                CreationDate = DateTimeOffset.Now.AddYears(-7)
            },
            new House()
            {
                Code = "11b",
                ProjectType = ProjectType.Cottage,
                FloatsNumber = 1,
                EntrencesNumber = 1,
                CreationDate = DateTimeOffset.Now.AddYears(-1)
            },
        };

        public static List<Block> Blocks = new()
        {
            new Block()
            {
                Code = "N120",
                Name = "North",
                AdministrationAddress = "Sun, 15",
                InhabitantsNumber = 1200,
                Area = 10.5
            },
            new Block()
            {
                Code = "S200",
                Name = "South",
                AdministrationAddress = "Cloud, 22",
                InhabitantsNumber = 20000,
                Area = 32.1
            },
            new Block()
            {
                Code = "W186",
                Name = "West",
                AdministrationAddress = "Qwerty, 11/7",
                InhabitantsNumber = 18652,
                Area = 29.47
            },
            new Block()
            {
                Code = "E192",
                Name = "East",
                AdministrationAddress = "Center, 13d",
                InhabitantsNumber = 19200,
                Area = 27.14
            },
        };

        public static List<HouseToBlock> HouseToBlocks = new()
        {
            new HouseToBlock
            {
                HouseCode = "11a",
                BlockCode = "N120"
            },
            new HouseToBlock
            {
                HouseCode = "11c",
                BlockCode = "N120"
            },
            new HouseToBlock
            {
                HouseCode = "65c",
                BlockCode = "N120"
            },
            new HouseToBlock
            {
                HouseCode = "70/1",
                BlockCode = "S200"
            },
            new HouseToBlock
            {
                HouseCode = "70/3",
                BlockCode = "S200"
            },
            new HouseToBlock
            {
                HouseCode = "9",
                BlockCode = "S200"
            },
            new HouseToBlock
            {
                HouseCode = "11/3",
                BlockCode = "W186"
            },
            new HouseToBlock
            {
                HouseCode = "47",
                BlockCode = "W186"
            },
            new HouseToBlock
            {
                HouseCode = "65a",
                BlockCode = "W186"
            },
            new HouseToBlock
            {
                HouseCode = "8",
                BlockCode = "E192"
            },
            new HouseToBlock
            {
                HouseCode = "65b",
                BlockCode = "E192"
            },
            new HouseToBlock
            {
                HouseCode = "68/1",
                BlockCode = "E192"
            },
            new HouseToBlock
            {
                HouseCode = "11b",
                BlockCode = "S200"
            },
        };
    }
}
