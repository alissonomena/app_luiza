using System.Collections.Generic;
using ApiMagazine.Models;

namespace ApiMagazine.Repository
{
    public interface IEmployeeRepository
    {
        void Add(Employee emp);
        IEnumerable<Employee> GetAll(int pgSize, int pg);
        Employee Find(long id);
        void Remove(long id);
    }
}