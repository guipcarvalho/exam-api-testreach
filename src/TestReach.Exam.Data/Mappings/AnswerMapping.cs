using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestReach.Exam.Domain.Entities;

namespace TestReach.Exam.Data.Mappings
{
    class AnswerMapping : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.QuestionNumber)
                .IsRequired();

            builder.Property(c => c.ChosenOption)
                .IsRequired();

            builder.HasOne(c => c.ExamAttempt)
                .WithMany(c => c.Answers);
        }
    }
}
