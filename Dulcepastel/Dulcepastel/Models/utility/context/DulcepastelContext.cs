using Dulcepastel.Models.cliente;
using Dulcepastel.Models.ocupacion;
using Dulcepastel.Models.tipoDocumento;
using Microsoft.EntityFrameworkCore;

namespace Dulcepastel.Models.context;

public partial class DulcepastelContext : DbContext
{
    public DulcepastelContext() { }

    public DulcepastelContext(DbContextOptions<DulcepastelContext> options)
        : base(options) { }

    public virtual DbSet<Cliente> Cliente { get; set; }
    public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }

    public virtual DbSet<Ocupacion> Ocupacion { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__clientes__");

            entity.ToTable("clientes");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cliente_id");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cliente_nombre");

            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cliente_apellido");

            entity.Property(e => e.TipoDocId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("tipo_documento_id");

            entity.Property(e => e.NroDoc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cliente_nroDoc");

            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("cliente_direccion");

            entity.Property(e => e.Celular)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cliente_celular");

            entity.Property(e => e.TelFijo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cliente_telefonoFijo");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cliente_email");

            entity.Property(e => e.FNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("f_nacimiento");

            entity.Property(e => e.IdUserCre)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("usuario_id_create");

            entity.Property(e => e.Create)
                .HasColumnType("datetime")
                .HasColumnName("cliente_create");

            entity.Property(e => e.IduserUpd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("usuario_id_update");

            entity.Property(e => e.CUpdate)
                .HasColumnType("datetime")
                .HasColumnName("cliente_update");
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(t => t.TipoDocId).HasName("PK__TIPO_DOCUMENTO_ID__");
            
            entity.ToTable("tipo_documento");

            entity.Property(t => t.TipoDocId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("tipo_documento_id");

            entity.Property(t => t.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tipo_documento_descripcion");

            entity.Property(t => t.IdUserCre)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("usuario_id_create");

            entity.Property(t => t.Create)
                .HasColumnType("datetime")
                .HasColumnName("tipo_documento_create");

            entity.Property(t => t.IdUserUpd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("usuario_id_update");

            entity.Property(t => t.Update)
                .HasColumnType("datetime")
                .HasColumnName("tipo_documento_update");

        });

        modelBuilder.Entity<Ocupacion>(entity =>
        {
            entity.HasKey(o => o.Id).HasName("PK__OCUPACION_ID__");

            entity.ToTable("ocupacion");

            entity.Property(o => o.Id)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ocupacion_id");

            entity.Property(o => o.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("ocupacion_descripcion");
            
            entity.Property(o => o.UserIdCre)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("usuario_id_create");
            
            entity.Property(o => o.Create)
                .HasColumnType("datetime")
                .HasColumnName("ocupacion_create");

            entity.Property(o => o.IdUserUpd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("usuario_id_update");
                
            
            entity.Property(o => o.Update)
                .HasColumnType("datetime")
                .HasColumnName("ocupacion_update");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

