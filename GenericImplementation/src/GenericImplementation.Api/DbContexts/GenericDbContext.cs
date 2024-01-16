using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GenericImplementation.Api.Models;

namespace GenericImplementation.Api.DbContexts
{
    public partial class GenericDbContext : DbContext
    {
        public GenericDbContext()
        {
        }

        public GenericDbContext(DbContextOptions<GenericDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<edge> edges { get; set; } = null!;
        public virtual DbSet<endpoint> endpoints { get; set; } = null!;
        public virtual DbSet<o> os { get; set; } = null!;
        public virtual DbSet<parameter> parameters { get; set; } = null!;
        public virtual DbSet<protocol> protocols { get; set; } = null!;
        public virtual DbSet<site> sites { get; set; } = null!;
        public virtual DbSet<uom> uoms { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<edge>(entity =>
            {
                entity.ToTable("edge");

                entity.HasIndex(e => e.code, "edge_uk_code")
                    .IsUnique();

                entity.HasIndex(e => e.row_id, "edge_uk_row_id")
                    .IsUnique();

                entity.Property(e => e.id).UseIdentityAlwaysColumn();

                entity.Property(e => e.audit).HasColumnType("json");

                entity.Property(e => e.code).HasMaxLength(400);

                entity.Property(e => e.comments).HasMaxLength(1500);

                entity.Property(e => e.created_date).HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.ip_address).HasMaxLength(100);

                entity.Property(e => e.mac_id).HasMaxLength(100);

                entity.Property(e => e.make).HasMaxLength(400);

                entity.Property(e => e.model).HasMaxLength(400);

                entity.Property(e => e.name).HasMaxLength(200);

                entity.Property(e => e.row_id).HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.status)
                    .IsRequired()
                    .HasDefaultValueSql("true");

                entity.HasOne(d => d.os)
                    .WithMany(p => p.edges)
                    .HasForeignKey(d => d.os_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("edge_fk_os");
            });

            modelBuilder.Entity<endpoint>(entity =>
            {
                entity.ToTable("endpoint");

                entity.HasIndex(e => e.id, "endpoint_id_idx");

                entity.HasIndex(e => e.row_id, "endpoint_uk")
                    .IsUnique();

                entity.Property(e => e.id).UseIdentityAlwaysColumn();

                entity.Property(e => e.audit).HasColumnType("json");

                entity.Property(e => e.created_date).HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.name).HasMaxLength(200);

                entity.Property(e => e.row_id).HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.server_url).HasMaxLength(100);

                entity.Property(e => e.setting).HasColumnType("json");

                entity.Property(e => e.status)
                    .IsRequired()
                    .HasDefaultValueSql("true");

                entity.HasOne(d => d.protocol)
                    .WithMany(p => p.endpoints)
                    .HasForeignKey(d => d.protocol_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("endpoint_fk_protocol");
            });

            modelBuilder.Entity<o>(entity =>
            {
                entity.Property(e => e.id).UseIdentityAlwaysColumn();

                entity.Property(e => e.code).HasColumnType("character varying");

                entity.Property(e => e.created_date).HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.name).HasColumnType("character varying");

                entity.Property(e => e.row_id).HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.status).HasDefaultValueSql("true");
            });

            modelBuilder.Entity<parameter>(entity =>
            {
                entity.ToTable("parameter");

                entity.HasIndex(e => e.code, "parameter_uk_code")
                    .IsUnique();

                entity.HasIndex(e => e.row_id, "parameter_uk_row_id")
                    .IsUnique();

                entity.Property(e => e.id).UseIdentityAlwaysColumn();

                entity.Property(e => e.audit).HasColumnType("json");

                entity.Property(e => e.code).HasMaxLength(100);

                entity.Property(e => e.comments).HasMaxLength(1500);

                entity.Property(e => e.created_date).HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.name).HasMaxLength(200);

                entity.Property(e => e.row_id).HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.status)
                    .IsRequired()
                    .HasDefaultValueSql("true");
            });

            modelBuilder.Entity<protocol>(entity =>
            {
                entity.ToTable("protocol");

                entity.HasIndex(e => e.code, "protocol_uk_code")
                    .IsUnique();

                entity.HasIndex(e => e.row_id, "protocol_uk_row_id")
                    .IsUnique();

                entity.Property(e => e.id).UseIdentityAlwaysColumn();

                entity.Property(e => e.audit).HasColumnType("json");

                entity.Property(e => e.code).HasMaxLength(400);

                entity.Property(e => e.created_date).HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.name).HasMaxLength(200);

                entity.Property(e => e.row_id).HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.status)
                    .IsRequired()
                    .HasDefaultValueSql("true");
            });

            modelBuilder.Entity<site>(entity =>
            {
                entity.ToTable("site");

                entity.HasIndex(e => e.code, "site_uk_code")
                    .IsUnique();

                entity.HasIndex(e => e.prefix, "site_uk_prefix")
                    .IsUnique();

                entity.HasIndex(e => e.row_id, "site_uk_row_id")
                    .IsUnique();

                entity.Property(e => e.id).UseIdentityAlwaysColumn();

                entity.Property(e => e.code).HasMaxLength(200);

                entity.Property(e => e.comments).HasMaxLength(1500);

                entity.Property(e => e.created_date).HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.deleted).HasDefaultValueSql("false");

                entity.Property(e => e.description).HasMaxLength(1500);

                entity.Property(e => e.name).HasMaxLength(400);

                entity.Property(e => e.prefix).HasMaxLength(20);

                entity.Property(e => e.row_id).HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.status)
                    .IsRequired()
                    .HasDefaultValueSql("true");
            });

            modelBuilder.Entity<uom>(entity =>
            {
                entity.ToTable("uom");

                entity.HasIndex(e => e.row_id, "uom_uk_row_id")
                    .IsUnique();

                entity.Property(e => e.id).UseIdentityAlwaysColumn();

                entity.Property(e => e.audit).HasColumnType("json");

                entity.Property(e => e.code).HasMaxLength(50);

                entity.Property(e => e.created_date).HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.description).HasMaxLength(1000);

                entity.Property(e => e.name).HasMaxLength(200);

                entity.Property(e => e.row_id).HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.status)
                    .IsRequired()
                    .HasDefaultValueSql("true");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
