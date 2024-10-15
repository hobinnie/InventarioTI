using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InventarioTI.Models
{
    public partial class GestionActivosDBContext : DbContext
    {
        public GestionActivosDBContext()
        {
        }

        public GestionActivosDBContext(DbContextOptions<GestionActivosDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Catalogo> Catalogos { get; set; } = null!;
        public virtual DbSet<CatalogoDpto> CatalogoDptos { get; set; } = null!;
        public virtual DbSet<CatalogoEmpresa> CatalogoEmpresas { get; set; } = null!;
        public virtual DbSet<CatalogoEstatus> CatalogoEstatuses { get; set; } = null!;
        public virtual DbSet<CatalogoMarca> CatalogoMarcas { get; set; } = null!;
        public virtual DbSet<CatalogoPermiso> CatalogoPermisos { get; set; } = null!;
        public virtual DbSet<CatalogoPuesto> CatalogoPuestos { get; set; } = null!;
        public virtual DbSet<CatalogoZona> CatalogoZonas { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Inventario> Inventarios { get; set; } = null!;
        public virtual DbSet<Linea> Lineas { get; set; } = null!;
        public virtual DbSet<Permiso> Permisos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263. //
                optionsBuilder.UseSqlServer("Server=localhost;Database=GestionActivosDB;User Id=sa;Password=min9398##;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalogo>(entity =>
            {
                entity.HasKey(e => e.IdCatalogo)
                    .HasName("PK__Catalogo__B6E8CB1DDE7DE46F");

                entity.ToTable("Catalogo");

                entity.Property(e => e.IdCatalogo).HasColumnName("Id_Catalogo");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatalogoDpto>(entity =>
            {
                entity.HasKey(e => e.IdDpto)
                    .HasName("PK__Catalogo__0A242C839A5BED2E");

                entity.ToTable("Catalogo_Dpto");

                entity.Property(e => e.IdDpto).HasColumnName("Id_Dpto");

                entity.Property(e => e.Departamento)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatalogoEmpresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK__Catalogo__443B3D9D426F2926");

                entity.ToTable("Catalogo_Empresa");

                entity.Property(e => e.IdEmpresa).HasColumnName("Id_Empresa");

                entity.Property(e => e.Clave)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FkIdMarca).HasColumnName("fk_Id_marca");

                entity.Property(e => e.FkIdZona).HasColumnName("fk_Id_Zona");

                entity.HasOne(d => d.FkIdMarcaNavigation)
                    .WithMany(p => p.CatalogoEmpresas)
                    .HasForeignKey(d => d.FkIdMarca)
                    .HasConstraintName("fk_Id_marca");

                entity.HasOne(d => d.FkIdZonaNavigation)
                    .WithMany(p => p.CatalogoEmpresas)
                    .HasForeignKey(d => d.FkIdZona)
                    .HasConstraintName("fk_Id_zona");
            });

            modelBuilder.Entity<CatalogoEstatus>(entity =>
            {
                entity.HasKey(e => e.IdEstatus)
                    .HasName("PK__Catalogo__A114FD1B07C8BEBC");

                entity.ToTable("Catalogo_Estatus");

                entity.Property(e => e.IdEstatus).HasColumnName("Id_Estatus");

                entity.Property(e => e.Estatus)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatalogoMarca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK__Catalogo__7189A73270735A80");

                entity.ToTable("Catalogo_Marca");

                entity.Property(e => e.IdMarca).HasColumnName("Id_marca");

                entity.Property(e => e.Marca)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatalogoPermiso>(entity =>
            {
                entity.HasKey(e => e.IdPermiso)
                    .HasName("PK__Catalogo__153CFB6D2FEE3D6D");

                entity.ToTable("Catalogo_Permisos");

                entity.Property(e => e.IdPermiso).HasColumnName("Id_Permiso");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatalogoPuesto>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PK__Catalogo__74056223C928CF6D");

                entity.ToTable("Catalogo_puestos");

                entity.Property(e => e.IdEmpleado).HasColumnName("Id_Empleado");

                entity.Property(e => e.FkIdDpto).HasColumnName("fk_Id_Dpto");

                entity.Property(e => e.Puesto)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkIdDptoNavigation)
                    .WithMany(p => p.CatalogoPuestos)
                    .HasForeignKey(d => d.FkIdDpto)
                    .HasConstraintName("fk_Id_Dpto");
            });

            modelBuilder.Entity<CatalogoZona>(entity =>
            {
                entity.HasKey(e => e.IdZona)
                    .HasName("PK__Catalogo__65DC4CC5BBBF87C5");

                entity.ToTable("Catalogo_Zona");

                entity.Property(e => e.IdZona).HasColumnName("Id_zona");

                entity.Property(e => e.Zona)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdPuesto)
                    .HasName("PK__Puesto__71BE91D3AFA8856E");

                entity.Property(e => e.IdPuesto).HasColumnName("Id_Puesto");

                entity.Property(e => e.Puesto)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.Clave)
                    .HasName("PK__Inventar__E8181E10FD0C40C0");

                entity.ToTable("Inventario");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FechaA)
                    .HasColumnType("date")
                    .HasColumnName("fecha_A");

                entity.Property(e => e.FechaBaja)
                    .HasColumnType("date")
                    .HasColumnName("fecha_baja");

                entity.Property(e => e.FechaC)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_C");

                entity.Property(e => e.FechaReasignacion)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_reasignacion");

                entity.Property(e => e.Hdd)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("HDD");

                entity.Property(e => e.IdEmpresaKf).HasColumnName("Id_Empresa_kf");

                entity.Property(e => e.IdMarcaKf).HasColumnName("Id_marca_kf");

                entity.Property(e => e.IdZonaKf).HasColumnName("Id_zona_kf");

                entity.Property(e => e.Linea)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("linea");

                entity.Property(e => e.Marca)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.MemoriaRam)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Memoria_RAM");

                entity.Property(e => e.Modelo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("modelo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.PrecioTotal)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("precio_total");

                entity.Property(e => e.PrecioUnitario)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("precio_unitario");

                entity.Property(e => e.Procesador)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("procesador");

                entity.Property(e => e.Serie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("serie");

                entity.Property(e => e.SistemaOp)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("sistema_op");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.HasOne(d => d.IdEmpresaKfNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.IdEmpresaKf)
                    .HasConstraintName("Id_Empresa_kf");

                entity.HasOne(d => d.IdMarcaKfNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.IdMarcaKf)
                    .HasConstraintName("Id_marca_kf");

                entity.HasOne(d => d.IdZonaKfNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.IdZonaKf)
                    .HasConstraintName("Id_Zona_kf");
            });

            modelBuilder.Entity<Linea>(entity =>
            {
                entity.HasKey(e => e.IdLinea)
                    .HasName("PK__Linea__F8F153FA97F7201C");

                entity.ToTable("Linea");

                entity.Property(e => e.IdLinea).HasColumnName("Id_Linea");

                entity.Property(e => e.Linea1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Linea");
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FkIdEmpresa).HasColumnName("fk_Id_Empresa");

                entity.Property(e => e.FkIdUsuario).HasColumnName("fk_Id_usuario");

                entity.Property(e => e.IdMarcaFk).HasColumnName("Id_marca_fk");

                entity.Property(e => e.IdZonaFk).HasColumnName("Id_Zona_fk");

                entity.HasOne(d => d.FkIdEmpresaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FkIdEmpresa)
                    .HasConstraintName("fk_Id_Empresa");

                entity.HasOne(d => d.FkIdUsuarioNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FkIdUsuario)
                    .HasConstraintName("fk_Id_usuario");

                entity.HasOne(d => d.IdMarcaFkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdMarcaFk)
                    .HasConstraintName("Id_marca_fk");

                entity.HasOne(d => d.IdZonaFkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdZonaFk)
                    .HasConstraintName("Id_Zona_fk");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__EF59F7627682E64B");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");

                entity.Property(e => e.Contraseña).HasMaxLength(55);

                entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");

                entity.Property(e => e.IdMarca).HasColumnName("id_marca");

                entity.Property(e => e.IdPuesto).HasColumnName("id_puesto");

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_usuario");

                entity.Property(e => e.Rol)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK_Usuario_Empresa");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("FK_Usuario_Marca");

                entity.HasOne(d => d.IdPuestoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPuesto)
                    .HasConstraintName("FK_Usuario_Puesto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
