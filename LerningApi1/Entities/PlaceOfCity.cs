using System.ComponentModel.DataAnnotations.Schema;

namespace LerningApi1.Entities
{
    public class PlaceOfCity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        [ForeignKey("CityId")]
        public Cities Cities { get; set; }
        public int CityId { get; set; }
    }
}
