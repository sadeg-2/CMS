﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.ViewModels
{
    public class PostAttachmentViewModel
    {
        public int Id { get; set; }

        public string AttachmentUrl { get; set; }
    }
}
