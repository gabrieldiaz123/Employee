using Employee.Functions;
using Employee.Models;
using Employee.Services;
using Microsoft.AspNetCore.Mvc;


namespace Employee.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class EmployeeController : Controller
    {

        public readonly EmployeeService _Services;
        public IConfiguration _configuration { get; set; }
        public GeneralFunctions FunctionsGeneral;
        public EmployeeController(IConfiguration configuration, EmployeeService employeeService)
        {
            FunctionsGeneral = new GeneralFunctions(configuration);
            _configuration = configuration;
            _Services = employeeService;
        }
        [HttpPost("Registrer Employee")]
        public IActionResult Create(EmployeeModel entity)
        {
            try
            {
                _Services.Add(entity);
                return Ok("Employee registrado con exito");
            }
            catch (Exception ex)
            {
                FunctionsGeneral.AddLog(ex.Message);
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpGet("Lister Employee")]
        public ActionResult<IEnumerable<EmployeeModel>> GetEmployee()
        {
            try
            {
                return Ok(_Services.GetEmployee());
            }
            catch (Exception ex)
            {
                FunctionsGeneral.AddLog(ex.Message);
                return StatusCode(500, ex.ToString());
            }
        }

    }
}
