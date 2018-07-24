using System.Collections.Generic;
using ApiMagazine.Models;
using ApiMagazine.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiMagazine.Controllers
{
    [Route("employee/[Controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _eRep;

        public EmployeeController(IEmployeeRepository empRep)
        {
            _eRep = empRep;
        }
        [HttpGet("{page_size}/{page}")]
        public IEnumerable<Employee> GetAll(int pgSize, int pg)
        {
            return _eRep.GetAll(pgSize, pg);
        }
        [HttpGet("{id}", Name="GetEmployee")]
        public IActionResult GetById(long id)
        {
            var employee = _eRep.Find(id);
            if(employee == null)
            {
                return NotFound();
            }
            return new ObjectResult(employee);
        }
        [HttpPost]
        public IActionResult Create([FromBody] Employee emp) 
        {
            if(emp == null)
            {
                return BadRequest();
            }
            _eRep.Add(emp);
            return CreatedAtRoute("GetEmployee", new {id=emp.EmployeeId}, emp);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var emp = _eRep.Find(id);
            if(emp == null)
            {
                return NotFound();
            }
            _eRep.Remove(id);
            return new NoContentResult();
        }
    }
}