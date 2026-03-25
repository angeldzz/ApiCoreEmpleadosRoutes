using ApiCoreEmpleadosRoutes.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace ApiCoreEmpleadosRoutes.Data
{
    public class HospitalContext: DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {
        }
        public DbSet<Empleado> Empleados { get; set; }
    }
}
