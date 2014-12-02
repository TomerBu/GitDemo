using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sherlock.Models
{
    public class Apartment
    {

        public int ApartmentID { get; set; }
        [Display(Name = "מספר חדרים")]
        [Required]
        public float Rooms { get; set; }
        [Display(Name="מחיר")]
        public decimal Price { get; set; }
         [Display(Name = "שטח הדירה")]
        public float Area { get; set; }

        //1 to 1
        [Required]
        [Display(Name = "כתובת")]
        public Address Address { get; set; }
    }
}