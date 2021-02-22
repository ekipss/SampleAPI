using MediatR;
using SampleAPI.API.Students.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SampleAPI.API.Students.Commands
{
    public class AddStudentCommand : IRequest<bool>
    { 
        [DataMember]
        public string Name { get;private set; }
        [DataMember]
        public string Email { get; private set; }
        private AddStudentCommand()
        { }
        public AddStudentCommand(StudentDto student)
        {
            this.Name = student.Name;
            this.Email = student.Email;
        }
    }
}
