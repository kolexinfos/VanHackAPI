using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VanHackAPI.Models
{
    public class Topic
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string FullText { get; set; }

        //public int CategoryId { get; set; }
        [Required]
        public Category Category { get; set; }

        public ICollection<Comment> Comments { get; set;}

        public DateTime DateCreated { get; set; }

        [Required]
        public ApplicationUser Author { get; set; }
    }
}