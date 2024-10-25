
using CMCSWebApp.Data.Enum;
using CMCSWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CMCSWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Define DbSets for your application models
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<ClaimForm> ClaimForms { get; set; } // DbSet for claim submission forms
        public DbSet<Claims> Claims { get; set; } // DbSet for submitted claims
        public DbSet<ReviewClaims> ReviewClaims { get; set; } // DbSet for claims under review (if applicable)
        public DbSet<Users> Users { get; set; } // DbSet for users
        public DbSet<SubmittedClaims> SubmittedClaims { get; set; } // DbSet for submitted claims
        public DbSet<ItemsFeature> ItemsFeatures { get; set; } // DbSet for supporting documents

        // Override the OnModelCreating method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure properties with decimal types
            modelBuilder.Entity<ClaimForm>()
                .Property(cf => cf.HourlyRate)
                .HasColumnType("decimal(18, 2)"); // Set the precision and scale

            modelBuilder.Entity<SubmittedClaims>()
                .Property(sc => sc.Hours)
                .HasColumnType("decimal(18, 2)"); // Set the precision and scale for Hours

            modelBuilder.Entity<SubmittedClaims>()
                .Property(sc => sc.Total)
                .HasColumnType("decimal(18, 2)"); // Set the precision and scale for Total

            modelBuilder.Entity<ItemsFeature>()
                .HasKey(i => i.ItemID); // Specify ItemID as the primary key

            // Configure the relationship between ClaimForm and ItemsFeature
            modelBuilder.Entity<ClaimForm>()
                .HasMany(cf => cf.SupportingDocs) // Collection of ItemsFeature
                .WithOne(i => i.ClaimForm) // Each ItemsFeature is linked to one ClaimForm
                .HasForeignKey(i => i.ClaimID) // Foreign key for ItemsFeature
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes

            modelBuilder.Entity<ReviewClaims>()
                .HasOne<ClaimForm>()
                .WithMany() // Adjust if ReviewClaims needs to reference multiple Claims
                .HasForeignKey(rc => rc.ClaimID); // Foreign key to ClaimForm

            modelBuilder.Entity<Module>()
                .HasOne(m => m.Programme)
                .WithMany(p => p.Modules)
                .HasForeignKey(m => m.ProgrammeID); // Foreign key in Module

            // Configure the Claims model with a primary key
            modelBuilder.Entity<Claims>()
                .HasKey(pc => pc.ClaimsID); // Specify the primary key

            // Configure decimal properties for ReviewClaims
            modelBuilder.Entity<ReviewClaims>()
                .Property(rc => rc.HourlyRate)
                .HasColumnType("decimal(18, 2)"); // Adjust precision and scale as needed

            modelBuilder.Entity<Claims>()
                .Property(pc => pc.TotalAmount)
                .HasColumnType("decimal(18, 2)"); // Adjust precision and scale as needed

            // User-Role relationship
            modelBuilder.Entity<Users>()
                .HasOne<Roles>() // Each User has one Role
                .WithMany(r => r.Users) // Each Role has many Users
                .HasForeignKey(u => u.ID); // Ensure that RoleId exists in Users

            // Ensure SubmittedClaims has a primary key
            modelBuilder.Entity<SubmittedClaims>()
                .HasKey(sc => sc.ClaimID); // Specify the primary key for SubmittedClaims

            modelBuilder.Entity<Claims>()
                .Property(c => c.Status)
                .HasConversion<string>(); // Store enum as string
            modelBuilder.Entity<Roles>()
                .HasKey(r => r.RoleID); // Specify the primary key
        }
    }
}