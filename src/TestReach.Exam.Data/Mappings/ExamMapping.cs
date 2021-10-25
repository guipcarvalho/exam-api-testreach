using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestReach.Exam.Domain.Entities;

namespace TestReach.Exam.Data.Mappings
{
    class ExamMapping : IEntityTypeConfiguration<Domain.Entities.Exam>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Exam> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired();

            builder.Property(c => c.CreationDate)
                .IsRequired();

            builder.HasMany(c => c.Questions)
                .WithOne(c => c.Exam)
                .HasForeignKey(c => c.ExamId);

            builder.HasMany(c => c.ExamAttempts)
                .WithOne(c => c.Exam)
                .HasForeignKey(c => c.ExamId);


            SetupInitialData(builder);
        }

        private void SetupInitialData(EntityTypeBuilder<Domain.Entities.Exam> builder)
        {
            builder.HasData(
                    new Domain.Entities.Exam { Id = "EX202001", Name = "Exam 1" },
                    new Domain.Entities.Exam { Id = "EX202002", Name = "Exam 2" },
                    new Domain.Entities.Exam { Id = "EX202003", Name = "Exam 3" },
                    new Domain.Entities.Exam { Id = "EX202004", Name = "Exam 4" }
                );
        }
    }
}

