using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestReach.Exam.Domain.Entities;

namespace TestReach.Exam.Data.Mappings
{
    class CandidateMapping : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .IsRequired();

            builder.Property(c => c.Email)
                .IsRequired();

            builder.HasMany(c => c.ExamAttempts)
                .WithOne(c => c.Candidate)
                .HasForeignKey(c => c.CandidateId);

            builder.HasIndex(i => new { i.Email, i.Name });
        }
    }
}
