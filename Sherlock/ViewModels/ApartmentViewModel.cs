using Sherlock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sherlock.ViewModels
{
    public class ApartmentViewModel
    {
        public Apartment Apartment { get; set; }
        public Address Address { get; set; }
    }
}