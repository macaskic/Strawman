using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using NLog;

namespace PubApi.Models
{
    public partial class db843153744Context : DbContext
    {
        Logger log = LogManager.GetCurrentClassLogger();
        public db843153744Context()
        {
        }

        public db843153744Context(DbContextOptions<db843153744Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<PubRegistration> PubRegistration { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
             

                /*
                log.Debug("This is a debug message");
                log.Error(new Exception(), "This is an error message");
                log.Fatal("This is a fatal message");
                */

                log.Debug("About to connect");
                try
                {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
               //   optionsBuilder.UseSqlServer("Server=DEVELOPMENT;Database=db843153744;Trusted_Connection=True;MultipleActiveResultSets=True");
                 //   optionsBuilder.UseSqlServer("Server=db843153744.hosting-data.io;Database=db843153744;Trusted_Connection=True;MultipleActiveResultSets=True");
                      optionsBuilder.UseSqlServer("Server=db843153744.hosting-data.io;Database=db843153744;User Id=dbo843153744;Password=Test1234;MultipleActiveResultSets=True");
                    log.Debug("Connected!");
                }
                catch (Exception e)
                {

                    log.Debug(".................... EXCEPTION...............");
                    log.Debug(e.Message);
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            log.Debug("....................Start Create Model...............");
            modelBuilder.Entity<Login>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PubRegistration>(entity =>
            {
                entity.HasKey(e => e.PubId)
                    .HasName("PK__pubRegis__F5EF5616C2D0529C");

                entity.ToTable("pubRegistration");

                entity.Property(e => e.PubId).HasColumnName("PubID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMail")
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.TelephoneNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.VisitDate)
                    .IsRequired()
                    .HasMaxLength(100);
            });
            log.Debug("................... Created first...............");
            OnModelCreatingPartial(modelBuilder);
            log.Debug("................... Created Second...............");
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
