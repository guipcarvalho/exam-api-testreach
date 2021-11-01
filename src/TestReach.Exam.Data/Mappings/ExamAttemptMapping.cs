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
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.AttemptDate)
                .IsRequired();

            builder.Property(c => c.Score)
                .IsRequired();

            builder.HasOne(c => c.Candidate)
                .WithMany(c => c.ExamAttempts)
                .IsRequired();

            builder.HasOne(c => c.Exam)
                .WithMany(c => c.ExamAttempts)
                .IsRequired();

            builder.HasMany(c => c.Answers)
                .WithOne(c => c.ExamAttempt)
                .HasForeignKey(c => c.ExamAttemptId);
        }
    }
}
