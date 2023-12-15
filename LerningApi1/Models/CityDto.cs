namespace LerningApi1.Models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int NumberOfPlace
        {
            get
            {
                return placeOfCities.Count;
            }
        }
        public ICollection<PlacesToVisitDto> placeOfCities { get; set; } = new List<PlacesToVisitDto>();
    }
}
