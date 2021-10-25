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
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.QuestionNumber)
                .IsRequired();

            builder.Property(c => c.CorrectAnswer)
                .IsRequired();

            builder.HasOne(c => c.Exam)
                .WithMany(c => c.Questions)
                .IsRequired();

            SetupInitialData(builder);
        }

        private void SetupInitialData(EntityTypeBuilder<Question> builder)
        {
            builder.HasData(
                    new Question { ExamId = "EX202001", QuestionNumber = 1, CorrectAnswer= 'A' },
                    new Question { ExamId = "EX202001", QuestionNumber = 2, CorrectAnswer= 'C' },
                    new Question { ExamId = "EX202001", QuestionNumber = 3, CorrectAnswer= 'C' },
                    new Question { ExamId = "EX202001", QuestionNumber = 4, CorrectAnswer= 'A' },
                    new Question { ExamId = "EX202001", QuestionNumber = 5, CorrectAnswer= 'B' },
                    new Question { ExamId = "EX202001", QuestionNumber = 6, CorrectAnswer= 'B' },
                    new Question { ExamId = "EX202001", QuestionNumber = 7, CorrectAnswer= 'C' },
                    new Question { ExamId = "EX202001", QuestionNumber = 8, CorrectAnswer= 'A' },
                    new Question { ExamId = "EX202001", QuestionNumber = 9, CorrectAnswer= 'D' },
                    new Question { ExamId = "EX202001", QuestionNumber = 10, CorrectAnswer= 'A' },

                    new Question { ExamId = "EX202002", QuestionNumber = 1, CorrectAnswer = 'B' },
                    new Question { ExamId = "EX202002", QuestionNumber = 2, CorrectAnswer = 'D' },
                    new Question { ExamId = "EX202002", QuestionNumber = 3, CorrectAnswer = 'C' },
                    new Question { ExamId = "EX202002", QuestionNumber = 4, CorrectAnswer = 'C' },
                    new Question { ExamId = "EX202002", QuestionNumber = 5, CorrectAnswer = 'A' },
                    new Question { ExamId = "EX202002", QuestionNumber = 6, CorrectAnswer = 'D' },
                    new Question { ExamId = "EX202002", QuestionNumber = 7, CorrectAnswer = 'E' },
                    new Question { ExamId = "EX202002", QuestionNumber = 8, CorrectAnswer = 'E' },
                    new Question { ExamId = "EX202002", QuestionNumber = 9, CorrectAnswer = 'C' },
                    new Question { ExamId = "EX202002", QuestionNumber = 10, CorrectAnswer = 'A' },
                    new Question { ExamId = "EX202002", QuestionNumber = 11, CorrectAnswer = 'E' },
                    new Question { ExamId = "EX202002", QuestionNumber = 12, CorrectAnswer = 'C' },
                    new Question { ExamId = "EX202002", QuestionNumber = 13, CorrectAnswer = 'D' },
                    new Question { ExamId = "EX202002", QuestionNumber = 14, CorrectAnswer = 'E' },
                    new Question { ExamId = "EX202002", QuestionNumber = 15, CorrectAnswer = 'A' },
                    new Question { ExamId = "EX202002", QuestionNumber = 16, CorrectAnswer = 'B' },
                    new Question { ExamId = "EX202002", QuestionNumber = 17, CorrectAnswer = 'D' },

                    new Question { ExamId = "EX202003", QuestionNumber = 1, CorrectAnswer = 'B' },
                    new Question { ExamId = "EX202003", QuestionNumber = 2, CorrectAnswer = 'C' },
                    new Question { ExamId = "EX202003", QuestionNumber = 3, CorrectAnswer = 'E' },
                    new Question { ExamId = "EX202003", QuestionNumber = 4, CorrectAnswer = 'E' },
                    new Question { ExamId = "EX202003", QuestionNumber = 5, CorrectAnswer = 'A' },
                    new Question { ExamId = "EX202003", QuestionNumber = 6, CorrectAnswer = 'C' },
                    new Question { ExamId = "EX202003", QuestionNumber = 7, CorrectAnswer = 'D' },
                    new Question { ExamId = "EX202003", QuestionNumber = 8, CorrectAnswer = 'E' },
                    new Question { ExamId = "EX202003", QuestionNumber = 9, CorrectAnswer = 'A' },
                    new Question { ExamId = "EX202003", QuestionNumber = 10, CorrectAnswer = 'A' },
                    new Question { ExamId = "EX202003", QuestionNumber = 11, CorrectAnswer = 'E' },
                    new Question { ExamId = "EX202003", QuestionNumber = 12, CorrectAnswer = 'C' },
                    new Question { ExamId = "EX202003", QuestionNumber = 13, CorrectAnswer = 'B' },
                    new Question { ExamId = "EX202003", QuestionNumber = 14, CorrectAnswer = 'A' },
                    new Question { ExamId = "EX202003", QuestionNumber = 15, CorrectAnswer = 'B' },
                    new Question { ExamId = "EX202003", QuestionNumber = 16, CorrectAnswer = 'C' },
                    new Question { ExamId = "EX202003", QuestionNumber = 17, CorrectAnswer = 'A' },
                    new Question { ExamId = "EX202003", QuestionNumber = 18, CorrectAnswer = 'B' },
                    new Question { ExamId = "EX202003", QuestionNumber = 19, CorrectAnswer = 'B' },
                    new Question { ExamId = "EX202003", QuestionNumber = 20, CorrectAnswer = 'D' },

                    new Question { ExamId = "EX202004", QuestionNumber = 1, CorrectAnswer = 'E' },
                    new Question { ExamId = "EX202004", QuestionNumber = 2, CorrectAnswer = 'A' },
                    new Question { ExamId = "EX202004", QuestionNumber = 3, CorrectAnswer = 'C' },
                    new Question { ExamId = "EX202004", QuestionNumber = 4, CorrectAnswer = 'D' },
                    new Question { ExamId = "EX202004", QuestionNumber = 5, CorrectAnswer = 'E' },
                    new Question { ExamId = "EX202004", QuestionNumber = 6, CorrectAnswer = 'A' },
                    new Question { ExamId = "EX202004", QuestionNumber = 7, CorrectAnswer = 'A' },
                    new Question { ExamId = "EX202004", QuestionNumber = 8, CorrectAnswer = 'E' },
                    new Question { ExamId = "EX202004", QuestionNumber = 9, CorrectAnswer = 'C' },
                    new Question { ExamId = "EX202004", QuestionNumber = 10, CorrectAnswer = 'B' },
                    new Question { ExamId = "EX202004", QuestionNumber = 11, CorrectAnswer = 'A' },
                    new Question { ExamId = "EX202004", QuestionNumber = 12, CorrectAnswer = 'B' }

                );
        }
    }
}