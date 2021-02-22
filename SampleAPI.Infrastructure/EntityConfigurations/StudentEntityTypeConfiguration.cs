using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleAPI.Domain.AggregatesModel.Students;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAPI.Infrastructure.EntityConfigurations
{
    internal class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        internal const string CourseList = "_courses";
        internal const string EducationCourses = "_educationCourses";

        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students", SchemaNames.University);

            builder.HasKey(b => b.Uid);


        }
    }
}
