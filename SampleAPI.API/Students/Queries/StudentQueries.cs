using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SampleAPI.API.Students.Queries
{
    internal class StudentQueries : IStudentQueries
    {

        private string _connectionString = string.Empty;

        public StudentQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                const string sql = "SELECT " +
                                  "[Student].[Name], " +
                                  "[Student].[Email] " +
                                  "FROM university.Students AS [Student] ";

                return await connection.QueryAsync<StudentDto>(sql); 
            }
        }
    }
}
