namespace Application.Models
{
    public class HouseToBlock
    {
        public string HouseCode { get; set; }

        public string BlockCode { get; set; }

        public override string ToString()
        {
            return $"{BlockCode} - {HouseCode}";
        }
    }
}
