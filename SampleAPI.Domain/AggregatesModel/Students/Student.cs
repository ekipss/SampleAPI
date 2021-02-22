using SampleAPI.Domain.Exceptions;
using SampleAPI.Domain.SeedWork;
using System;

namespace SampleAPI.Domain.AggregatesModel.Students
{
    public class Student : Entity, IAggregateRoot
    {
      
        public string Email { get; private set; }

        public string Name { get; private set; }


        private Student()
        {
        }

        public Student(string name, string email, IStudentUniquenessChecker studentUniquenessChecker)
        {
            this.Uid = Guid.NewGuid();
            this.Email = email;
            this.Name = name;


            var isUnique = studentUniquenessChecker.IsUnique(this);
            if (!isUnique)
            {
                throw new SampleAPIDomainException($"This student is already registered");
            }
        } 


    }
}
