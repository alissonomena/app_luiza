using System.Collections.Generic;
using System.Linq;
using ApiMagazine.Models;

namespace ApiMagazine.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _ctx;
        public EmployeeRepository(EmployeeDbContext c)
        {
            _ctx = c;
        }
        public void Add(Employee emp)
        {
            _ctx.Employee.Add(emp);
            _ctx.SaveChanges();
        }
        public IEnumerable<Employee> GetAll(int pgSize, int pg)
        {
            return _ctx.Employee.Skip(pg * pgSize).Take(pgSize);
        }
        public Employee Find(long id)
        {
            return _ctx.Employee.FirstOrDefault(e => e.EmployeeId == id);
        }
        public void Remove(long id)
        {
            var entity = _ctx.Employee.First(e => e.EmployeeId == id);
            _ctx.Employee.Remove(entity);
            _ctx.SaveChanges();
        }
        
    }
}