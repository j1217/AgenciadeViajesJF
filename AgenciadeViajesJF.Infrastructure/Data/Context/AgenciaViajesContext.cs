using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using AgenciadeViajesJF.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AgenciadeViajesJF.Infrastructure.Data.Context;

public partial class AgenciaViajesContext : DbContext
{
    public AgenciaViajesContext()
    {
    }

    public AgenciaViajesContext(DbContextOptions<AgenciaViajesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ContactosEmergencium> ContactosEmergencia { get; set; }

    public virtual DbSet<Habitacione> Habitaciones { get; set; }

    public virtual DbSet<Hotele> Hoteles { get; set; }

    public virtual DbSet<Huespede> Huespedes { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactosEmergencium>(entity =>
        {
            entity.HasKey(e => e.IdContactoEmergencia).HasName("PK__Contacto__3A12A766ADC52B14");

            entity.Property(e => e.Nombres).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(20);

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.ContactosEmergencia)
                .HasForeignKey(d => d.IdReserva)
                .HasConstraintName("FK__Contactos__IdRes__571DF1D5");
        });

        modelBuilder.Entity<Habitacione>(entity =>
        {
            entity.HasKey(e => e.IdHabitacion).HasName("PK__Habitaci__8BBBF9019CB14ECC");

            entity.Property(e => e.CostoBase).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Habilitada)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Impuestos).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.TipoHabitacion).HasMaxLength(50);
            entity.Property(e => e.Ubicacion).HasMaxLength(255);

            entity.HasOne(d => d.IdHotelNavigation).WithMany(p => p.Habitaciones)
                .HasForeignKey(d => d.IdHotel)
                .HasConstraintName("FK__Habitacio__IdHot__4D94879B");
        });

        modelBuilder.Entity<Hotele>(entity =>
        {
            entity.HasKey(e => e.IdHotel).HasName("PK__Hoteles__653BCCC475CBB42E");

            entity.Property(e => e.CorreoElectronico).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Habilitado)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.SitioWeb).HasMaxLength(255);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Huespede>(entity =>
        {
            entity.HasKey(e => e.IdHuesped).HasName("PK__Huespede__939EC061205781A8");

            entity.Property(e => e.Apellidos).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Genero).HasMaxLength(20);
            entity.Property(e => e.Nombres).HasMaxLength(50);
            entity.Property(e => e.NumeroDocumento).HasMaxLength(20);
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.TipoDocumento).HasMaxLength(20);

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.Huespedes)
                .HasForeignKey(d => d.IdReserva)
                .HasConstraintName("FK__Huespedes__IdRes__5441852A");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK__Reservas__0E49C69DD6099C67");

            entity.Property(e => e.FechaEntrada).HasColumnType("datetime");
            entity.Property(e => e.FechaSalida).HasColumnType("datetime");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdHabitacion)
                .HasConstraintName("FK__Reservas__IdHabi__5165187F");

            entity.HasOne(d => d.IdHotelNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdHotel)
                .HasConstraintName("FK__Reservas__IdHote__5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
