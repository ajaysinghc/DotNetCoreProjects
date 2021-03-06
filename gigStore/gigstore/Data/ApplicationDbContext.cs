﻿using gigstore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace gigstore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Attendance>(c => c.HasKey(a => new { a.GigId, a.AttendeeId }));
            builder.Entity<Attendance>().HasOne<Gig>().WithMany().HasForeignKey(a => a.GigId).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Attendance>().HasOne(a => a.Attendee).WithMany().HasForeignKey(a => a.AttendeeId).OnDelete(DeleteBehavior.SetNull);


            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
