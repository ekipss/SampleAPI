using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleAPI.API.Students.Commands;
using SampleAPI.API.Students.Queries;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SampleAPI.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IStudentQueries _stundentQueries;
        private readonly ILogger<StudentsController> _logger;
        

        public StudentsController(IMediator mediator, IStudentQueries studentQueries, ILogger<StudentsController> logger)
        {
            _mediator = mediator;
            _stundentQueries = studentQueries;
            _logger = logger;
        }

        [Route("students")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StudentDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetCardTypesAsync()
        {
            var cardTypes = await _stundentQueries.GetStudentsAsync();

            return Ok(cardTypes);
        }


        /// <summary>
        /// Add student.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="email">Email.</param>
        [Route("students/AddStudent")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddStudent(
            [FromBody] StudentDto student)
        {
            await _mediator.Send(new AddStudentCommand(student));

            return Created(string.Empty, null);
        }


    }
}
