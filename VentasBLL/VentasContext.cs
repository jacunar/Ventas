using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VentasBLL {
    public partial class VentasContext : DbContext {
        public VentasContext() {
        }

        public VentasContext(DbContextOptions<VentasContext> options)
            : base(options) {
        }

        public virtual DbSet<Articulo> Articulos { get; set; } = null!;
        public virtual DbSet<Categoria> Categorias { get; set; } = null!;
        public virtual DbSet<DetalleIngreso> DetalleIngresos { get; set; } = null!;
        public virtual DbSet<DetalleVenta> DetalleVentas { get; set; } = null!;
        public virtual DbSet<Ingreso> Ingresos { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Proveedor> Proveedores { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Venta> Ventas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Articulo>(entity => {
                entity.HasKey(e => e.IdArticulo)
                    .HasName("PK__Articulo__F8FF5D520A5FB734");

                entity.HasIndex(e => e.Nombre, "UQ__Articulo__75E3EFCFB0BD285A")
                    .IsUnique();

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Costo).HasColumnType("decimal(11, 2)");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioVenta).HasColumnType("decimal(11, 2)");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Articulos__IdCat__2A4B4B5E");
            });

            modelBuilder.Entity<Categoria>(entity => {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__A3C02A103F7A88FD");

                entity.HasIndex(e => e.Nombre, "UQ__Categori__75E3EFCFA820A542")
                    .IsUnique();

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetalleIngreso>(entity => {
                entity.HasKey(e => e.IdDetalleIngreso)
                    .HasName("PK__DetalleI__62A16E0B5E147315");

                entity.ToTable("DetalleIngreso");

                entity.Property(e => e.Precio).HasColumnType("decimal(11, 2)");

                entity.HasOne(d => d.IdArticuloNavigation)
                    .WithMany(p => p.DetalleIngresos)
                    .HasForeignKey(d => d.IdArticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DetalleIn__IdArt__3E52440B");

                entity.HasOne(d => d.IdIngresoNavigation)
                    .WithMany(p => p.DetalleIngresos)
                    .HasForeignKey(d => d.IdIngreso)
                    .HasConstraintName("FK__DetalleIn__IdIng__3D5E1FD2");
            });

            modelBuilder.Entity<DetalleVenta>(entity => {
                entity.HasKey(e => e.IdDetalleVenta)
                    .HasName("PK__DetalleV__AAA5CEC22A565CEE");

                entity.Property(e => e.Descuento).HasColumnType("decimal(11, 2)");

                entity.Property(e => e.Precio).HasColumnType("decimal(11, 2)");

                entity.HasOne(d => d.IdArticuloNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.IdArticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DetalleVe__IdArt__45F365D3");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.IdVenta)
                    .HasConstraintName("FK__DetalleVe__IdVen__44FF419A");
            });

            modelBuilder.Entity<Ingreso>(entity => {
                entity.HasKey(e => e.IdIngreso)
                    .HasName("PK__Ingresos__901EF2E3911C511F");

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Impuesto).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.NumComprobante)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SerieComprobante)
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.TipoComprobante)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Total).HasColumnType("decimal(11, 2)");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Ingresos)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ingresos__IdProv__398D8EEE");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Ingresos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ingresos__IdUsua__3A81B327");
            });

            modelBuilder.Entity<Persona>(entity => {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK__Personas__2EC8D2AC889F57E6");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumDocumento)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoPersona)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Proveedor>(entity => {
                entity.HasKey(e => e.IdProveedor)
                    .HasName("PK__Proveedo__E8B631AF7AB07A42");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Contacto)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity => {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Roles__2A49584C94F56BE1");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity => {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__5B65BF97D6F30C80");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("login");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuarios__IdPers__33D4B598");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuarios__IdRol__32E0915F");
            });

            modelBuilder.Entity<Venta>(entity => {
                entity.HasKey(e => e.IdVenta)
                    .HasName("PK__Ventas__BC1240BD10A9B092");

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaHora).HasColumnType("datetime");

                entity.Property(e => e.Impuesto).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.NumComprobante)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SerieComprobante)
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.TipoComprobante)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Total).HasColumnType("decimal(11, 2)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ventas__IdClient__412EB0B6");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ventas__IdUsuari__4222D4EF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}