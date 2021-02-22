using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAPI.Domain.AggregatesModel.Students
{
    public interface IStudentUniquenessChecker
    {
        bool IsUnique(Student student);
    }
}
