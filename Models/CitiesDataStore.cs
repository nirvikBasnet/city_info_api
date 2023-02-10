using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.Models
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities {get; set;}

        //singleton
        public static CitiesDataStore Current{get;} = new CitiesDataStore();

        public CitiesDataStore(){
            //dummy data
            Cities = new List<CityDto>(){
                     new CityDto(){
                Id=1,
                Name="New York",
                Description="The one with that big park.",
                PointsOfInterest = new List<PointOfInterestDto>(){
                    new PointOfInterestDto(){
                        Id =1,
                        Name = "Central Park",
                        Description = "The most visited urban park in the united states."
                    },
                     new PointOfInterestDto(){
                        Id =2,
                        Name = "Empire State Building",
                        Description = "A 102-story skyscraper located in Midtown Manhattan."
                    }

                }
            },
             new CityDto(){
                Id=2,
                Name="Sydney",
                Description="The one with the bridge.",
                      PointsOfInterest = new List<PointOfInterestDto>(){
                    new PointOfInterestDto(){
                        Id =1,
                        Name = "Harbour Bridge",
                        Description = "A metal structure that connect two bank of river."
                    },
                     new PointOfInterestDto(){
                        Id =2,
                        Name = "Opera House",
                        Description = "Where everyone takes pictures."
                    }

                }
            }
            };
        }
    }
}