using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Tracking.Models.Tracking
{
    public partial class TrackingContext : DbContext
    {
        public TrackingContext()
        {
        }

        public TrackingContext(DbContextOptions<TrackingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AwbtoProcess> AwbtoProcesses { get; set; }
        public virtual DbSet<CustomTrackingEvent> CustomTrackingEvents { get; set; }
        public virtual DbSet<RawFtpserviceDatum> RawFtpserviceData { get; set; }
        public virtual DbSet<RawServiceDatum> RawServiceData { get; set; }
        public virtual DbSet<ServiceTrackingEventLookup> ServiceTrackingEventLookups { get; set; }
        public virtual DbSet<StagingServiceDatum> StagingServiceData { get; set; }
        public virtual DbSet<Subscriber> Subscribers { get; set; }
        public virtual DbSet<TrackingEvent> TrackingEvents { get; set; }
        public virtual DbSet<TrackingService> TrackingServices { get; set; }
        public virtual DbSet<UnMappedServiceEvent> UnMappedServiceEvents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SRQ-DEV-SQL1.myus.local;Database=Tracking;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AwbtoProcess>(entity =>
            {
                entity.ToTable("AWBToProcess", "dbo");

                entity.Property(e => e.Awb)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("AWB");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CustomAwb)
                    .HasMaxLength(255)
                    .HasColumnName("CustomAWB");

                entity.Property(e => e.LastProcessedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ShipDate).HasColumnType("datetime");

                entity.Property(e => e.StopProcessingAfterXdays)
                    .HasColumnName("StopProcessingAfterXDays")
                    .HasComment("Max Days we will Process this AWB for.");

                entity.Property(e => e.StopProcessingDate).HasColumnType("datetime");

                entity.Property(e => e.UniqueId).HasMaxLength(255);

                entity.HasOne(d => d.Subscriber)
                    .WithMany(p => p.AwbtoProcesses)
                    .HasForeignKey(d => d.SubscriberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AWBToProcess_Subscriber");

                entity.HasOne(d => d.TrackingService)
                    .WithMany(p => p.AwbtoProcesses)
                    .HasForeignKey(d => d.TrackingServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AWBToProcess_TrackingService");
            });

            modelBuilder.Entity<CustomTrackingEvent>(entity =>
            {
                entity.ToTable("CustomTrackingEvent", "dbo");

                entity.Property(e => e.Code).HasMaxLength(255);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Subscriber)
                    .WithMany(p => p.CustomTrackingEvents)
                    .HasForeignKey(d => d.SubscriberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomTrackingEvent_Subscriber");
            });

            modelBuilder.Entity<RawFtpserviceDatum>(entity =>
            {
                entity.ToTable("RawFTPServiceData", "dbo");

                entity.Property(e => e.Awb)
                    .HasMaxLength(255)
                    .HasColumnName("AWB");

                entity.Property(e => e.ImportDate).HasColumnType("datetime");

                entity.Property(e => e.ProcessedDate).HasColumnType("datetime");

                entity.Property(e => e.RawData).IsRequired();
            });

            modelBuilder.Entity<RawServiceDatum>(entity =>
            {
                entity.ToTable("RawServiceData", "dbo");

                entity.Property(e => e.Awb)
                    .HasMaxLength(255)
                    .HasColumnName("AWB");

                entity.Property(e => e.AwbtoProcessId).HasColumnName("AWBToProcessId");

                entity.Property(e => e.ImportDate).HasColumnType("datetime");

                entity.Property(e => e.ProcessedDate).HasColumnType("datetime");

                entity.Property(e => e.RawData).IsRequired();

                entity.HasOne(d => d.AwbtoProcess)
                    .WithMany(p => p.RawServiceData)
                    .HasForeignKey(d => d.AwbtoProcessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RawServiceData_AWBToProcess");
            });

            modelBuilder.Entity<ServiceTrackingEventLookup>(entity =>
            {
                entity.ToTable("ServiceTrackingEventLookup", "dbo");

                entity.Property(e => e.Code).HasMaxLength(255);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CustomTrackingEventId).HasComment("This field is required, if exists, to match a value in the CustomTrackingEvent table");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.TrackingService)
                    .WithMany(p => p.ServiceTrackingEventLookups)
                    .HasForeignKey(d => d.TrackingServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceTrackingEventLookup_TrackingService");
            });

            modelBuilder.Entity<StagingServiceDatum>(entity =>
            {
                entity.ToTable("StagingServiceData", "dbo");

                entity.Property(e => e.AwbtoProcessId).HasColumnName("AWBToProcessId");

                entity.Property(e => e.Code).HasMaxLength(255);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.ImportDate).HasColumnType("datetime");

                entity.Property(e => e.Location).HasMaxLength(1000);

                entity.Property(e => e.ProcessedDate).HasColumnType("datetime");

                entity.HasOne(d => d.AwbtoProcess)
                    .WithMany(p => p.StagingServiceData)
                    .HasForeignKey(d => d.AwbtoProcessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StagingServiceData_AWBToProcess");

                entity.HasOne(d => d.RawServiceData)
                    .WithMany(p => p.StagingServiceData)
                    .HasForeignKey(d => d.RawServiceDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StagingServiceData_RawServiceData");
            });

            modelBuilder.Entity<Subscriber>(entity =>
            {
                entity.ToTable("Subscriber", "dbo");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Subscriber1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("Subscriber");

                entity.Property(e => e.UnsubscribeDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TrackingEvent>(entity =>
            {
                entity.ToTable("TrackingEvents", "dbo");

                entity.Property(e => e.AwbtoProcessId).HasColumnName("AWBToProcessId");

                entity.Property(e => e.Code).HasMaxLength(255);

                entity.Property(e => e.DeliveredDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.LastProcessedDate).HasColumnType("datetime");

                entity.Property(e => e.Location).HasMaxLength(1000);

                entity.HasOne(d => d.AwbtoProcess)
                    .WithMany(p => p.TrackingEvents)
                    .HasForeignKey(d => d.AwbtoProcessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrackingEvents_AWBToProcess");
            });

            modelBuilder.Entity<TrackingService>(entity =>
            {
                entity.ToTable("TrackingService", "dbo");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.IntegrationType).HasComment("Type of Integration. \r\n1: API EndPoint\r\n2: FTP");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ServiceTrackingUrl)
                    .HasMaxLength(1000)
                    .HasColumnName("ServiceTrackingURL");

                entity.Property(e => e.StopProcessingAfterXdays).HasColumnName("StopProcessingAfterXDays");
            });

            modelBuilder.Entity<UnMappedServiceEvent>(entity =>
            {
                entity.ToTable("UnMappedServiceEvents", "dbo");

                entity.Property(e => e.Code).HasMaxLength(255);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.TrackingService)
                    .WithMany(p => p.UnMappedServiceEvents)
                    .HasForeignKey(d => d.TrackingServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UnMappedServiceEvents_TrackingService");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
