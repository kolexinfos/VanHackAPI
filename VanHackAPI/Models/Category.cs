using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VanHackAPI.Models
{
    public class Category
    {
        [ForeignKey("Topic")]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual Topic Topic { get; set; }
    }
}