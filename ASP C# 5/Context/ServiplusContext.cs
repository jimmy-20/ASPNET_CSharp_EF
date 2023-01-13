using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using ServiplusEF.Models;

namespace ServiplusEF.Context
{
    public class ServiplusContext : DbContext
    {
        public DbSet<Cliente> Cliente {get;set;}
        public DbSet<Mecanico> Mecanico;
        public DbSet<Servicio> Servicio;
        public DbSet<Repuesto> Repuesto;
        public DbSet<Vehiculo> Vehiculo;
        public DbSet<Mantenimiento> Mantenimiento;
        public DbSet<DetalleMantenimiento> DetalleMantenimiento; 
        public DbSet<DetalleRepuesto> DetalleRepuesto;

        public ServiplusContext(DbContextOptions<ServiplusContext> opcion) : base (opcion) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            //Creando Tabla Cliente
            modelBuilder.Entity<Cliente>(cliente => {
                cliente.ToTable("Cliente");

                cliente.HasKey(c => c.Id);

                cliente.Property(c => c.PrimerNombre).HasMaxLength(50).IsRequired();
                cliente.Property(c => c.SegundoNombre).HasMaxLength(50);
                cliente.Property(c => c.PrimerApellido).HasMaxLength(50).IsRequired();
                cliente.Property(c => c.SegundoApellido).HasMaxLength(50);
                cliente.Property(c => c.Telefono).HasMaxLength(50);
                cliente.Property(c => c.Direccion).HasMaxLength(100);
                cliente.Property(c => c.Correo).IsRequired(false);
                cliente.Property(c => c.Estado);
                cliente.HasData(InitClientes());
            });

            //Creando Tabla Mecanico
            modelBuilder.Entity<Mecanico>(mecanico => {
                mecanico.ToTable("Mecanico");

                mecanico.HasKey(c => c.Id);
                mecanico.Property(c => c.PrimerNombre).HasMaxLength(50).IsRequired();
                mecanico.Property(c => c.SegundoNombre).HasMaxLength(50);
                mecanico.Property(c => c.PrimerApellido).HasMaxLength(50).IsRequired();
                mecanico.Property(c => c.SegundoApellido).HasMaxLength(50);
                mecanico.Property(c => c.Telefono).HasMaxLength(50);
                mecanico.Property(c => c.Direccion).HasMaxLength(100);
                mecanico.Property(c => c.Correo).IsRequired(false);
                mecanico.Property(c => c.Estado);
            });

            modelBuilder.Entity<Servicio>(servicio => {
                servicio.ToTable("Servicio");

                servicio.HasKey(s => s.ServicioId);
                servicio.Property(s => s.Descripcion).HasMaxLength(50).IsRequired();
                servicio.Property(s => s.TipoMantenimiento);
                servicio.Property(s => s.Precio).HasPrecision(8);
                servicio.Property(s => s.Estado);
            });

            modelBuilder.Entity<Repuesto>(repuesto => {
                repuesto.ToTable("Repuesto");

                repuesto.HasKey(r =>  r.RepuestoId);
                repuesto.Property(r => r.Descripcion).HasMaxLength(50).IsRequired();
                repuesto.Property(r => r.Marca).HasMaxLength(50).IsRequired();
                repuesto.Property(r => r.Modelo);
                repuesto.Property(r => r.Precio).HasPrecision(8);
                repuesto.Property(r => r.Cantidad);
                repuesto.Property(r => r.Estado);
            });

            modelBuilder.Entity<Vehiculo>(vehiculo => {
                vehiculo.ToTable("Vehiculo");

                vehiculo.HasKey(v => v.VehiculoId);
                vehiculo.HasOne(v => v.Cliente).WithMany(c => c.Vehiculos).HasForeignKey(v => v.ClienteId);
                vehiculo.Property(v => v.Marca);
                vehiculo.Property(v => v.Modelo);
                vehiculo.Property(v => v.Año);
            });

            modelBuilder.Entity<Mantenimiento>(mantenimiento => {
                mantenimiento.ToTable("Mantenimiento");

                mantenimiento.HasKey(m => m.MantenimientoId);
                mantenimiento.HasOne(m => m.Vehiculo).WithMany(v => v.Mantenimientos).HasForeignKey(m => m.VehiculoId);
                mantenimiento.Property(m => m.FechaIngreso).IsRequired();
                mantenimiento.Property(m => m.FechaSalida).IsRequired();
                mantenimiento.Property(m => m.Estado);
            });

            modelBuilder.Entity<DetalleMantenimiento>(detM => {
                detM.ToTable("DetalleMantenimiento");

                detM.HasKey(dm => dm.DetalleMantenimientoId);
                detM.HasOne(dm => dm.Mantenimiento).WithMany(m => m.DetalleMantenimientos).HasForeignKey(dm => dm.MantenimientoId);
                detM.HasOne(dm => dm.Servicio).WithMany(s => s.DetalleMantenimientos).HasForeignKey(dm => dm.ServicioId);
                detM.HasOne(dm => dm.Mecanico).WithMany(m => m.DetalleMantenimientos).HasForeignKey(dm => dm.MecanicoId);
                detM.Property(dm => dm.Precio).HasPrecision(8).HasComment("Precio del servicio");
                detM.Property(dm => dm.Estado);
            });

            modelBuilder.Entity<DetalleRepuesto>(detR => {
                detR.ToTable("DetalleRepuesto");

                detR.HasOne(dr => dr.Repuesto).WithMany(r => r.DetalleRepuestos).HasForeignKey(dr => dr.RepuestoId);
                detR.HasOne(dr => dr.DetalleMantenimiento).WithMany(dm => dm.DetalleRepuestos).HasForeignKey(dr => dr.DetalleMantenimientoId);
                detR.Property(dr => dr.Precio).HasPrecision(8);
                detR.Property(dr => dr.Cantidad);

                detR.HasKey(dr => new {dr.DetalleMantenimientoId ,dr.RepuestoId});
            });
        }

        private List<Cliente> InitClientes(){
            List<Cliente> clientes = new List<Cliente>();
            Cliente[] data = {
                new Cliente(){
                    Id = 1,
                    PrimerNombre = "Jimmy",
                    SegundoNombre = "Alexander", 
                    PrimerApellido = "Soza", 
                    SegundoApellido = "Ortiz",
                    Telefono = "78029756",
                    Direccion = "Praderas de Sandino H-9",
                    Correo = "develop@gmail.com"}
                ,
                new Cliente(){
                    Id = 2,
                    PrimerNombre = "Maria",
                    SegundoNombre = "José",
                    PrimerApellido = "Ramirez",
                    SegundoApellido = "Rodriguez",
                    Telefono = "89890000",
                    Direccion = "Praderas de Sandino H-9",
                    Correo = "mariajose@gmail.com",
                    Estado = Enum.Estado.Habilitado
                }
                ,
                new Cliente(){
                    Id = 3,
                    PrimerNombre = "Pedro",
                    PrimerApellido =  "Cabrera",
                    Direccion = "Residencial San andres Casa M9",
                    Correo = "pedrocabrera@gmail.com",
                    Estado = Enum.Estado.Habilitado
                }
            };

            clientes.AddRange(data);
            return clientes;
        }
    }
}