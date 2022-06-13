using Application.Enums;
using System;

namespace Application.Parsers
{
    public static class GeneralParser
    {
        public static int ParseInt(string value)
        {
            int result = 0;
            Int32.TryParse(value, out result);
            return result;
        }

        public static double ParseDouble(string value)
        {
            double result = 0;
            Double.TryParse(value, out result);
            return result;
        }

        public static DateTimeOffset ParseDateTimeOffset(string value)
        {
            DateTimeOffset result = DateTimeOffset.MinValue;
            DateTimeOffset.TryParse(value, out result);
            return result;
        }

        public static ProjectType ParseProjectType(string value)
        {
            ProjectType projectType = ProjectType.HighRise;
            Enum.TryParse(value, out projectType);
            return projectType;
        }
    }
}
