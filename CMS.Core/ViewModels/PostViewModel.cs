using CMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        public int TimeInMinute { get; set; }
        public CategoryViewModel Category { get; set; }

        public string Status { get; set; }
        public UserViewModel Author { get; set; }

        public List<PostAttachmentViewModel> Attachments { get; set; }
        public string CreatedAt { get; set; }


    }
}
