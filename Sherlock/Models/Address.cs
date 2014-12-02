using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Sherlock.Models
{
    public class Address
    {
        //has the apartment id
        [Key, ForeignKey("Apartment")]
        public int ApartmentID { get; set; }

        [Display(Name = "מספר בית")]
        public int BuildingNumber { get; set; }
        [Display(Name = "מספר דירה")]
        public int? AptNumber { get; set; }
        [Display(Name = "רחוב")]
        public Street Street { get; set; }
        public int StreetID { get; set; }
        [Display(Name = "עיר")]
        public City City { get { return Street.City; } }
        [Display(Name = "דירה")]
        public Apartment Apartment { get; set; }
    }

}
