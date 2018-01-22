using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VanHackAPI.DTOs
{
    public class TopicDTO
    {
        [Required]
        public string Title { get; set; }

        public string FullText { get; set; }

        public string Category { get; set; }

        public string Username { get; set; }

        public DateTime DateCreated { get; set; }

        public IEnumerable<CommentDTO> Comments { get; set; }
    }
}