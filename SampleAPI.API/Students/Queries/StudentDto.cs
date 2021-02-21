using System;

namespace SampleAPI.API.Students.Queries
{
    public record StudentDto
    {
        public Guid Uid { get; init; }
        public string Email { get; init; }
        public string Name { get; init; }
        public decimal SpentTotal { get; init; }
    }
}
