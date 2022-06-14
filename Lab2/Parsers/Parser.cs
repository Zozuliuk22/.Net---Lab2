using Application.Enums;
using System;

namespace Application.Parsers
{
    public static class Parser
    {
        public static int ToInt(string value)
        {
            int result = 0;
            Int32.TryParse(value, out result);
            return result;
        }

        public static double ToDouble(string value)
        {
            double result = 0;
            Double.TryParse(value, out result);
            return result;
        }

        public static DateTimeOffset ToDateTimeOffset(string value)
        {
            DateTimeOffset result = DateTimeOffset.MinValue;
            DateTimeOffset.TryParse(value, out result);
            return result;
        }

        public static ProjectType ToProjectType(string value)
        {
            ProjectType projectType = ProjectType.HighRise;
            Enum.TryParse(value, out projectType);
            return projectType;
        }
    }
}
