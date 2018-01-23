using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VanHackAPI.DTOs
{
    public class TopicDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public string FullText { get; set; }

        public string Category { get; set; }

        public int CategoryId { get; set; }

        public string Username { get; set; }

        public DateTime DateCreated { get; set; }

        public IEnumerable<CommentDTO> Comments { get; set; }
    }
}