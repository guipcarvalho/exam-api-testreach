using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestReach.Exam.Domain.Entities;

namespace TestReach.Exam.Data.Mappings
{
    class QuestionMapping : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.QuestionNumber)
                .IsRequired();

            builder.Property(c => c.CorrectAnswer)
                .IsRequired();

            builder.HasOne(c => c.Exam)
                .WithMany(c => c.Questions);
        }
    }
}
