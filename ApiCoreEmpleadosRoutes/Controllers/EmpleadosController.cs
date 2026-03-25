using ApiCoreEmpleadosRoutes.Models;
using ApiCoreEmpleadosRoutes.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoreEmpleadosRoutes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private RepositoryEmpleados repo;
        public EmpleadosController(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Empleado>>> GetEmpleados()
        {
            return await this.repo.GetEmpleadosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> FindEmpleado(int id)
        {
            return await this.repo.FindEmpleadosAsync(id);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<string>>> Oficios()
        {
            return await this.repo.GetOficioAsync();
        }
        [HttpGet]
        [Route("[action]/{oficio}")]
        public async Task<ActionResult<List<Empleado>>> GetEmpleadosOficio(string oficio)
        {
            return await this.repo.GetEmpleadosOficioAsync(oficio);
        }
        [HttpGet]
        [Route("[action]/{salario}/{iddepartamento}")]
        public async Task<ActionResult<List<Empleado>>>
            EmpleadosBySalarioDepartamento(int salario, int iddepartamento)
        {
            return await this.repo.GetEmpleadosSalarioDepartamentoAsync(salario, iddepartamento);
        }
    }
}
