using Application.Enums;
using System;

namespace Application.Models
{
    public class House
    {
        public string Code { get; set; }

        public ProjectType ProjectType { get; set; }

        public int FloatsNumber { get; set; }

        public int EntrencesNumber { get; set; }

        public DateTimeOffset CreationDate { get; set; }

        public override string ToString()
        {
            return $"{Code} - {ProjectType} - {CreationDate.Year}";
        }
    }
}
