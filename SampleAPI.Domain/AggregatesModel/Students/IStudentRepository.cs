using SampleAPI.Domain.SeedWork;
using System.Threading.Tasks;

namespace SampleAPI.Domain.AggregatesModel.Students
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task AddAsync(Student student);
        void Add(Student student);
    }
}
