using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.Models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name
         { get; set; } = string.Empty;

        public string? Description {get; set;}
        public List<PointOfInterestDto>? PointsOfInterest {get;set;}
    }
}