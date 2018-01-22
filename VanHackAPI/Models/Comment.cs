using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VanHackAPI.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        public string FullText { get; set; }

        public IdentityUser Author { get; set; }

        public DateTime DateCreated { get; set;  }

        public Boolean Edited { get; set; }

        
    }
}