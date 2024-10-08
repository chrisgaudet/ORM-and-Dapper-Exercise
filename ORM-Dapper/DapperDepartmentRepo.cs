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

        IEnumerable<Department> GetAllDepts()
        {
            _connection.Query<Department>("SELECT * FROM departments;")
        }
    }
}
