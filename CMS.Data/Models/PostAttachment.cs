using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Data.Models
{
    public class PostAttachment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
       
        [Required]
        public string AttachmentUrl { get; set; }

    }
}
