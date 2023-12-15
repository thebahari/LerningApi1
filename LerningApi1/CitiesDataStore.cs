using LerningApi1.Models;

namespace LerningApi1
{
    public class CitiesDataStore
    {
        public List<CityDto> Citys { get; set; }
        //public static CitiesDataStore Instance { get; } = new CitiesDataStore();
        public CitiesDataStore() {
            Citys = new List<CityDto>()
        {
            new CityDto()
            { Id = 1,Name="SHIRAZ",Description="THIS IS MY CITY"
            ,placeOfCities=new List<PlacesToVisitDto>()
            {
                new PlacesToVisitDto()
                {
                     Id=1,Name="Takht Jamshid",Description="jay didani shiraz"
                },
                new PlacesToVisitDto()
                {
                     Id=2,Name="bagh eram",Description="jay didani shiraz"
                },
                new PlacesToVisitDto()
                {
                     Id=3,Name="bagh afif abad",Description="jay didani shiraz"
                }
                }
            },
            new CityDto() { Id = 2,Name="MASHHAD",Description="THIS IS MY CITY"
                        ,placeOfCities=new List<PlacesToVisitDto>()
            {
                new PlacesToVisitDto()
                {
                     Id=4,Name="vakil abad",Description="jay didani mashhad"
                },
                new PlacesToVisitDto()
                {
                     Id=5,Name="torghabe",Description="jay didani mashhad"
                },
                new PlacesToVisitDto()
                {
                     Id=6,Name="shandiz",Description="jay didani mashhad"
                }
                }},
            new CityDto() { Id = 3,Name="MAZANDARAN",Description="THIS IS MY CITY"
                        ,placeOfCities=new List<PlacesToVisitDto>()
            {
                new PlacesToVisitDto()
                {
                     Id=7,Name="darya",Description="jay didani mazandaran"
                },
                new PlacesToVisitDto()
                {
                     Id=8,Name="sahel",Description="jay didani mazandran"
                },
                new PlacesToVisitDto()
                {
                     Id=9,Name="jangal",Description="jay didani mazandaran"
                }
                }},
        };
        }
    }
}
