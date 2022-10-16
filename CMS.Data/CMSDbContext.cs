using CMS.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Web.Data
{
    public class CMSDbContext : IdentityDbContext<User>
    { 
        public CMSDbContext(DbContextOptions<CMSDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts;
        public DbSet<Track> Tracks;
        public DbSet<PostAttachment> PostAttachments;
        public DbSet<Email> Emails;
        public DbSet<Category> Categories;
        public DbSet<Notification> Notifications;
        public DbSet<Advertisement> Advertisements;
        public DbSet<ContentChangeLog> ContentChangeLogs;




    }
}
