using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleAPI.API.Students.Queries
{
    public interface IStudentQueries
    {
        Task<IEnumerable<StudentDto>> GetStudentsAsync();

    }
}
