using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Sherlock.Models
{
    public class Street
    {
        public int StreetID { get; set; }
         [Display(Name = "שם הרחוב")]
        public string Name { get; set; }
         [Display(Name = "שם הרחוב באנגלית")]
        public string EnglishName { get; set; }
         [Display(Name = "מחיר")]
        public City City { get; set; }
        public int? CityID { get; set; }
    }
}
