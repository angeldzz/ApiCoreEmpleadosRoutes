using ApiCoreEmpleadosRoutes.Data;
using ApiCoreEmpleadosRoutes.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreEmpleadosRoutes.Repositories
{
    public class RepositoryEmpleados
    {
        private HospitalContext context;
        public RepositoryEmpleados(HospitalContext context)
        {
            this.context = context;
        }
        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            return await this.context.Empleados.ToListAsync();
        }

        public async Task<Empleado> FindEmpleadosAsync(int idEmpleado)
        {
            return await this.context.Empleados.FirstOrDefaultAsync(x => x.IdEmpleado == idEmpleado);
        }
    }
}
