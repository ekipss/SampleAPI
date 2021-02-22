using Dapper;
using SampleAPI.Domain.AggregatesModel.Students;
using SampleAPI.Infrastructure;
using System;
using System.Data.SqlClient;

namespace SampleAPI.API.Students.DomainServices
{
    public class StudentUniquenessChecker : IStudentUniquenessChecker
    {
        private string _connectionString = string.Empty;

        public StudentUniquenessChecker(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public bool IsUnique(Student student)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
               

                const string sql = "SELECT TOP 1 1" +
                                "FROM [university].[Students] AS [Student] " +
                                "WHERE [Student].[Email] = @Email" +
                                " AND [Student].[Name] = @Name";

                var studentsNumber = connection.QuerySingleOrDefault<int?>(sql, new
                {
                     Email = student.Email, Name = student.Name
                });

                return !studentsNumber.HasValue;
            }

        }
    }
}
