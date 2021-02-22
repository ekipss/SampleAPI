using MediatR;
using Microsoft.Extensions.Logging;
using SampleAPI.Domain.AggregatesModel.Students;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SampleAPI.API.Students.Commands
{
    public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, bool>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMediator _mediator;
        private readonly ILogger<AddStudentCommandHandler> _logger;
        private readonly IStudentUniquenessChecker _studentUniquenessChecker;
        public AddStudentCommandHandler(IMediator mediator,
                IStudentRepository studentRepository, 
                IStudentUniquenessChecker studentUniquenessChecker,
                ILogger<AddStudentCommandHandler> logger)
        {
      
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(_studentRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _studentUniquenessChecker = studentUniquenessChecker ?? throw new ArgumentNullException(nameof(studentUniquenessChecker));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student(request.Name, request.Email, this._studentUniquenessChecker);

            await this._studentRepository.AddAsync(student);

            return  await this._studentRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }

    }
}
