using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class DbTest3Context : DbContext
{
    public DbTest3Context()
    {
    }

    public DbTest3Context(DbContextOptions<DbTest3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AnalisisRiesgo> AnalisisRiesgos { get; set; }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<PlanTrabajo> PlanesTrabajos { get; set; }

    public virtual DbSet<PlanTrabajoPunto> PlanesTrabajosPuntos { get; set; }

    public virtual DbSet<Riesgo> Riesgos { get; set; }

    public virtual DbSet<Rol> Roles { get; set; }

    public virtual DbSet<UserRol> UserRols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnalisisRiesgo>(entity =>
        {
            entity.ToTable("analisis_riesgo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.AgenteGenerador)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("agente_generador");
            entity.Property(e => e.Causa)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("causa");
            entity.Property(e => e.Efecto)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("efecto");
            entity.Property(e => e.IdArea).HasColumnName("id_area");
            entity.Property(e => e.IdRiesgo).HasColumnName("id_riesgo");
            entity.Property(e => e.Impacto).HasColumnName("impacto");
            entity.Property(e => e.NivelRiesgo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("nivel_riesgo");
            entity.Property(e => e.Probabilidad).HasColumnName("probabilidad");
            entity.Property(e => e.Resultado).HasColumnName("resultado");
            entity.Property(e => e.Significado)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("significado");

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.AnalisisRiesgos)
                .HasForeignKey(d => d.IdArea)
                .HasConstraintName("FK_analisis_riesgo_area");

            entity.HasOne(d => d.IdRiesgoNavigation).WithMany(p => p.AnalisisRiesgos)
                .HasForeignKey(d => d.IdRiesgo)
                .HasConstraintName("FK_analisis_riesgo_riesgo");
        });

        modelBuilder.Entity<Area>(entity =>
        {
            entity.ToTable("area");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Areas)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_area_departamento");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Areas)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK_area_empresa");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.ToTable("departamento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_departamento_empresa");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.ToTable("empresa");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.CodigoEmpresa)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("codigo_empresa");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Ruc)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ruc");
            entity.Property(e => e.Telefono)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.UsuarioCreacion).HasColumnName("usuario_creacion");
            entity.Property(e => e.UsuarioModificacion).HasColumnName("usuario_modificacion");
        });

        modelBuilder.Entity<PlanTrabajo>(entity =>
        {
            entity.ToTable("plan_trabajo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.CantidadPersonas).HasColumnName("cantidad_personas");
            entity.Property(e => e.Codigo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.EnvioInforme)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("envio_informe");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreada)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecha_creada");
            entity.Property(e => e.FechaFinAuditoria).HasColumnName("fecha_fin_auditoria");
            entity.Property(e => e.FechaIncioAuditoria).HasColumnName("fecha_incio_auditoria");
            entity.Property(e => e.HorasNetas).HasColumnName("horas_netas");
            entity.Property(e => e.IdAreaAuditada).HasColumnName("id_area_auditada");
            entity.Property(e => e.IdAuditorAsignado).HasColumnName("id_auditor_asignado");
            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
            entity.Property(e => e.IdDetalleArea).HasColumnName("id_detalle_area");
            entity.Property(e => e.IdResponsableAreaAuditada).HasColumnName("id_responsable_area_auditada");
            entity.Property(e => e.IdUserCreada).HasColumnName("id_user_creada");
            entity.Property(e => e.Numero).HasColumnName("numero");
            entity.Property(e => e.Objetivos)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("objetivos");
            entity.Property(e => e.Procedimientos)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("procedimientos");
            entity.Property(e => e.Productos).HasColumnName("productos");

            entity.HasOne(d => d.IdAreaAuditadaNavigation).WithMany(p => p.PlanTrabajos)
                .HasForeignKey(d => d.IdAreaAuditada)
                .HasConstraintName("FK_plan_trabajo_area");

            entity.HasOne(d => d.IdAuditorAsignadoNavigation).WithMany(p => p.PlanTrabajoIdAuditorAsignadoNavigations)
                .HasForeignKey(d => d.IdAuditorAsignado)
                .HasConstraintName("FK_plan_trabajo_usuario");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.PlanTrabajos)
                .HasForeignKey(d => d.IdDepartamento)
                .HasConstraintName("FK_plan_trabajo_departamento");

            entity.HasOne(d => d.IdResponsableAreaAuditadaNavigation).WithMany(p => p.PlanTrabajoIdResponsableAreaAuditadaNavigations)
                .HasForeignKey(d => d.IdResponsableAreaAuditada)
                .HasConstraintName("FK_plan_trabajo_usuario1");
        });

        modelBuilder.Entity<PlanTrabajoPunto>(entity =>
        {
            entity.ToTable("plan_trabajo_puntos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdPlanTrabajo).HasColumnName("id_plan_trabajo");
            entity.Property(e => e.TipoPunto)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("L")
                .IsFixedLength()
                .HasColumnName("tipo_punto");

            entity.HasOne(d => d.IdPlanTrabajoNavigation).WithMany(p => p.PlanTrabajoPuntos)
                .HasForeignKey(d => d.IdPlanTrabajo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_plan_trabajo_puntos_plan_trabajo");
        });

        modelBuilder.Entity<Riesgo>(entity =>
        {
            entity.ToTable("riesgo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.UserCreado).HasColumnName("user_creado");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.ToTable("rol");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<UserRol>(entity =>
        {
            entity.ToTable("user_rol");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.UserRols)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_rol_rol");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UserRols)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_rol_usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Apellido)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Clave)
                .HasColumnType("text")
                .HasColumnName("clave");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.FechaCreada)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecha_creada");
            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");
            entity.Property(e => e.Mail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("mail");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
