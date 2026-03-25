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
        public async Task<List<string>> GetOficioAsync()
        {
            var consulta = (from datos in this.context.Empleados
                            select datos.Oficio).Distinct();
            return await consulta.ToListAsync();
        }
        public async Task<List<Empleado>> GetEmpleadosOficioAsync(string oficio)
        {
            return await this.context.Empleados.Where(x => x.Oficio == oficio).ToListAsync();
        }
        public async Task<List<Empleado>> GetEmpleadosSalarioDepartamentoAsync(int salario, int idDepartamento)
        {
            return await this.context.Empleados
                .Where(x => x.Salario >= salario 
                && x.DeptNo == idDepartamento)
                .ToListAsync();
        }
    }
}
