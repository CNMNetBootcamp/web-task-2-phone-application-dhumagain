using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneApp.Models
{
    public class PhoneRatingViewModel
    {
        public List<Phone> Phones;
        public SelectList Rating;
        public string PhoneRating { get; set; }
        public string SearchString { get; set; }

    }
}
