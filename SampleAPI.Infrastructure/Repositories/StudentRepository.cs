using SampleAPI.Domain.AggregatesModel.Students;
using SampleAPI.Domain.SeedWork;
using System;
using System.Threading.Tasks;

namespace SampleAPI.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudyContext _context;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public StudentRepository(StudyContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(Student student)
        {
            await this._context.Students.AddAsync(student);
        }
        public void Add(Student student)
        {
            this._context.Students.Add(student);
        }
    }
}
