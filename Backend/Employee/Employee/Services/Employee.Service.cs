using Employee.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Employee.Services
{

    public class EmployeeService
    {
        private readonly AppDbContext _context;
        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }
        //este public sirve para listar todos los registros //
        public IEnumerable<EmployeeModel> GetEmployee()
        {
            return _context.employee.ToList();
        }
        //este public sirve para crear  registros //
        public void Add(EmployeeModel entity)
        {
            _context.employee.Add(entity);
            _context.SaveChanges();
        }

    }
}
