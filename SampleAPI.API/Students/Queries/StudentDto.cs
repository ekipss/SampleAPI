using System;

namespace SampleAPI.API.Students.Queries
{
    public record StudentDto
    {
        public string Email { get; init; }
        public string Name { get; init; }
    }
}
