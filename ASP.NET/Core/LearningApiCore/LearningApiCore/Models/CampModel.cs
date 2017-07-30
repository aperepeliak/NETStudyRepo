using System;
using System.ComponentModel.DataAnnotations;

namespace LearningApiCore.Models
{
    public class CampModel
    {
        public string Url { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Moniker { get; set; }

        [Required]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Required]
        public string Description { get; set; }

        public string LocationAddress1 { get; set; }
        public string LocationAddress2 { get; set; }
        public string LocationAddress3 { get; set; }
        public string LocationCityTown { get; set; }
        public string LocationStateProvince { get; set; }
        public string LocationPostalCode { get; set; }
        public string LocationCountry { get; set; }
    }
}
