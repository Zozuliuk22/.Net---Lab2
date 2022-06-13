using Application.Contexts;
using Application.Enums;
using Application.Models;
using Application.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class CityRepository
    {
        private readonly Context _context;

        public CityRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<Block> GetAllBlocks()
        {
            return from b in _context.BlocksXml.Root.Elements()
                   select b.ToBlock();
        }

        public Dictionary<string, List<House>> GetFullInfo()
        {
            return _context.BlocksXml.Root.Elements()
                              .GroupJoin(_context.HousesXml.Root.Elements()
                                                    .Join(_context.HouseToBlocksXml.Root.Elements(),
                                                          h => h.Element("Code").Value,
                                                          hb => hb.Element("HouseCode").Value,
                                                          (h, hb) => new
                                                          {
                                                              BlockCode = hb.Element("BlockCode").Value,
                                                              HouseItem = h
                                                          }),
                                         b => b.Element("Code").Value,
                                         bh => bh.BlockCode,
                                         (b, houses) => new
                                         {
                                             BlockName = b.Element("Name").Value,
                                             Houses = houses.Select(h => h.HouseItem.ToHouse())
                                                            .ToList()
                                         })
                              .ToDictionary(b => b.BlockName, h => h.Houses);
        }

        public double GetCityArea()
        {
            return _context.BlocksXml
                    .Root.Elements()
                    .Aggregate(0d, (sum, b) => sum + GeneralParser.ParseDouble(b.Element("Area").Value));
        }

        public double GetAreaByOnePerson()
        {
            return _context.BlocksXml
                    .Root.Elements().Sum(b => GeneralParser.ParseInt(b.Element("InhabitantsNumber").Value)) / GetCityArea();
        }

        public Dictionary<ProjectType, IEnumerable<House>> GetHousesByTypes()
        {
            var query = from h in _context.HousesXml.Root.Elements()
                        group h by GeneralParser.ParseProjectType(h.Element("ProjectType").Value);

            return query.ToDictionary(k => k.Key, v => v.Select(h => h.ToHouse()));
        }

        public Dictionary<int, IEnumerable<House>> GetOneAndNineStoryHouses()
        {
            return _context.HousesXml.Root.Elements().GroupBy(h => GeneralParser.ParseInt(h.Element("FloatsNumber").Value))
                                     .Where(h => h.Key == 1 || h.Key == 9)
                                     .ToDictionary(k => k.Key, v => v.Select(h => h.ToHouse()));
        }

        public IEnumerable<House> GetNewHouses()
        {
            return _context.HousesXml.Root.Elements().OrderByDescending(h => GeneralParser.ParseDateTimeOffset(h.Element("CreationDate").Value))
                                     .Where(h => GeneralParser.ParseDateTimeOffset(h.Element("CreationDate").Value).Year > 2015)
                                     .Select(h => h.ToHouse());
        }

        public IEnumerable<House> GetHappyHouses()
        {
            return _context.HousesXml.Root.Elements().Where(h => h.Element("Code").Value.Contains("7"))
                                                     .Select(h => h.ToHouse());
        }

        public IEnumerable<ProjectType> GetSpecificTypes(int floats)
        {
            var result = from h in _context.HousesXml.Root.Elements()
                         where GeneralParser.ParseInt(h.Element("FloatsNumber").Value) >= floats
                         select GeneralParser.ParseProjectType(h.Element("ProjectType").Value);

            return result.Distinct();
        }

        public string FindAdministrationAddress(string houseCode)
        {
            var house = _context.HouseToBlocksXml.Root.Elements().FirstOrDefault(hb => hb.Element("HouseCode").Value == houseCode);

            if (house is null) return $"No house with {houseCode} code.";

            var block = _context.BlocksXml.Root.Elements().FirstOrDefault(b => b.Element("Code").Value == house.Element("BlockCode").Value);

            return block is null ? "Block is unknown." : block.Element("AdministrationAddress").Value;
        }

        public IEnumerable<House> GetTheBiggestBlockInfo()
        {
            if (!_context.BlocksXml.Root.Elements().Any()) return Enumerable.Empty<House>();

            var blockCodeAndHouses = from h in _context.HousesXml.Root.Elements()
                                     join hb in _context.HouseToBlocksXml.Root.Elements()
                                             on h.Element("Code").Value equals hb.Element("HouseCode").Value
                                     group h by hb.Element("BlockCode").Value into models
                                     select new
                                     {
                                         BlockCode = models.Key,
                                         Houses = models
                                     };

            var biggestBlock = (from b in _context.BlocksXml.Root.Elements()
                                orderby GeneralParser.ParseInt(b.Element("InhabitantsNumber").Value) descending
                                select b)
                               .FirstOrDefault();

            if (biggestBlock is null) return Enumerable.Empty<House>();

            var result = blockCodeAndHouses
                        .FirstOrDefault(m => m.BlockCode == biggestBlock.Element("Code").Value);

            if (result is null) return Enumerable.Empty<House>();

            return result.Houses.Select(h => h.ToHouse()).ToList();
        }

        public IEnumerable<House> GetTopTenOldestHouses()
        {
            var result = from h in _context.HousesXml.Root.Elements()
                         orderby GeneralParser.ParseDateTimeOffset(h.Element("CreationDate").Value).Year
                         select h;

            return result.Take(10).Select(h => h.ToHouse()).ToList();
        }

        public int GetPercentOfHighRiseByBlock(string blockCode)
        {
            var blockCodeAndHouses = from h in _context.HousesXml.Root.Elements()
                                     join hb in _context.HouseToBlocksXml.Root.Elements()
                                             on h.Element("Code").Value equals hb.Element("HouseCode").Value
                                     group h by hb.Element("BlockCode").Value into models
                                     select new
                                     {
                                         BlockCode = models.Key,
                                         Houses = models
                                     };

            var result = blockCodeAndHouses.FirstOrDefault(m => m.BlockCode == blockCode);

            if (result is null) return 0;

            var housesIsHighRise = from h in result.Houses
                                   where GeneralParser.ParseProjectType(h.Element("ProjectType").Value) == ProjectType.HighRise
                                   select h;

            var part = (double)housesIsHighRise.Count() / blockCodeAndHouses.Count();
            return (int)(part * 100);
        }

        public IEnumerable<Block> GetBlocksWithMultiEntrencesHouses()
        {
            var result = from b in _context.BlocksXml.Root.Elements()
                         join hb in _context.HouseToBlocksXml.Root.Elements() on b.Element("Code").Value equals hb.Element("BlockCode").Value
                         where (from h in _context.HousesXml.Root.Elements()
                                where GeneralParser.ParseInt(h.Element("EntrencesNumber").Value) > 1
                                select h.Element("Code").Value)
                               .Contains(hb.Element("HouseCode").Value)
                         select b;

            return result.Select(b => b.ToBlock()).Distinct();
        }

        public Block PlayInBlocks()
        {
            var collection1 = GetRandomHouses(_context.HousesXml.Root.Elements().Count() / 2);
            var collection2 = GetRandomHouses(_context.HousesXml.Root.Elements().Count() / 2);

            var result = collection1.Intersect(collection2).ToList();

            var block = _context.HouseToBlocksXml.Root.Elements()
                                   .GroupJoin(result,
                                              hb => hb.Element("HouseCode").Value,
                                              h => h.Code,
                                              (hb, houses) => new
                                              {
                                                  BlockCode = hb.Element("BlockCode").Value,
                                                  Houses = houses

                                              })
                                   .OrderByDescending(m => m.Houses.Count())
                                   .FirstOrDefault();

            if (block is null) return null;

            return _context.BlocksXml.Root.Elements().First(b => b.Element("Code").Value == block.BlockCode).ToBlock();
        }

        private IEnumerable<House> GetRandomHouses(int count)
        {
            var list = new List<House>();

            for (int i = 0; i < count; i++)
            {
                var index = new Random().Next(_context.HousesXml.Root.Elements().Count());
                list.Add(_context.HousesXml.Root.Elements().ElementAt(index).ToHouse());
            }

            return list;
        }
    }
}
