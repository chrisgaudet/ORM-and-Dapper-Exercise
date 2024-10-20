using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public class DapperDepartmentRepo : IDepartmentRepo
    {
        private readonly IDbConnection _connection;
        public DapperDepartmentRepo(IDbConnection connection)
        {
            _connection = connection;

        }

        public IEnumerable<Department> GetAllDepts()
        {
            return _connection.Query<Department>("SELECT * FROM departments;");
        }

        public void InsertDepartment(string name)
        {
            _connection.Execute("INSER INTO Departments (Name) VALUES (@name)", new {name = name});
        }
    }
}
