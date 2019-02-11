﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneApp.Models
{
    public class Phone
    {

        //Phone featuress go here... 
        //Edit following part
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Brand { get; set; } 

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]       
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Rating  { get; set; } //Genre (string) replaced by Rating (decimal)

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        //public int Id { get; set; }
        //public string Title { get; set; }

        //[DataType(DataType.Date)]
        //public DateTime ReleaseDate { get; set; }
        //public string Genre { get; set; }
        //public decimal Price { get; set; }



    }
}
