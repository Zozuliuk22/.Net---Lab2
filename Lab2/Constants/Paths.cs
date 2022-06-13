using System;
using System.Text.RegularExpressions;

namespace Application.Constants
{
    public static class Paths
    {
        private const string _pattern = @"bin.*";
        private const string _dataDirectory = "XmlData";
        private static readonly string _baseDirectory = AppContext.BaseDirectory;
        private static readonly string _defaultPath = 
                       Regex.Replace(_baseDirectory, _pattern, "");

        public static string Blocks => 
                      $"{_defaultPath}{_dataDirectory}\\Blocks.xml";

        public static string Houses => 
                      $"{_defaultPath}{_dataDirectory}\\Houses.xml";

        public static string HouseToBlocks =>  
                      $"{_defaultPath}{_dataDirectory}\\HouseToBlocks.xml";

    }
}
