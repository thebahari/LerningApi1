namespace LerningApi1.Entities
{
    public class Cities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<PlaceOfCity> placeOfCities { get; set; }
    }
}
