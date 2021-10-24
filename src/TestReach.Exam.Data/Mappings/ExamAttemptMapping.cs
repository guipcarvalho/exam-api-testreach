using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestReach.Exam.Domain.Entities;

namespace TestReach.Exam.Data.Mappings
{
    class ExamAttemptMapping : IEntityTypeConfiguration<ExamAttempt>
    {
        public void Configure(EntityTypeBuilder<ExamAttempt> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.AttemptDate)
                .IsRequired();

            builder.HasOne(c => c.Candidate)
                .WithMany(c => c.ExamAttempts);

            builder.HasMany(c => c.Answers)
                .WithOne(c => c.ExamAttempt)
                .HasForeignKey(c => c.ExamAttemptId);
        }
    }
}
