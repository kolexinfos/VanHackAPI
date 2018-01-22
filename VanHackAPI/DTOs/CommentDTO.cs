using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VanHackAPI.DTOs
{
    public class CommentDTO
    {
        public string Fulltext { get; set; }
        public string Username { get; set; }

        public DateTime DateCreated { get; set; }

        public Boolean Edited { get; set; }
    }
}