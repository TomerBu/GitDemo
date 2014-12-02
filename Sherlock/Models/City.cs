using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Sherlock.Models
{
    public class City
    {
        public int CityID { get; set; }
        [Display(Name = "שם העיר")]
        public string Name { get; set; }
        [Display(Name = "איזור")]
        public District Ditrict { get; set; }
        public int? DitrictID { get; set; }
 
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Street> Streets { get; set; }
    }
}
