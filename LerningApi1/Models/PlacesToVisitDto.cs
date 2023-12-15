using LerningApi1.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace LerningApi1.Models
{
    public class PlacesToVisitDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int CityId { get; set; }
    }
}
