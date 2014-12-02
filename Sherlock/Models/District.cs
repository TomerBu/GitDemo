using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Sherlock.Models
{
    public class District
    {
        public int DistrictID { get; set; }
        [Display(Name = "שם האיזור")]
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
