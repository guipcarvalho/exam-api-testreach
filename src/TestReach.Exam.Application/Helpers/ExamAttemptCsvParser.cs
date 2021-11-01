using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestReach.Exam.Application.Helpers.Contracts;
using TestReach.Exam.Domain.Commands;
using TestReach.Exam.Domain.Dtos;
using TestReach.Exam.Domain.Entities;

namespace TestReach.Exam.Application.Helpers
{
    public class ExamAttemptCsvParser : IExamAttemptFileParser
    {
        public async Task<IEnumerable<CreateExamAttemptCommand>> GetExamAttemps(Stream stream)
        {
            var commands = new List<CreateExamAttemptCommand>();
            using var reader = new StreamReader(stream);

            CreateExamAttemptCommand lastCommand = null;
            string currentLine;
            while((currentLine = await reader.ReadLineAsync()) != null)
            {
                var fields = currentLine.Split('|');

                if (fields.Length != 6)
                    throw new NotSupportedException("Columns different than expected");

                var examId = fields[0];
                DateTime.TryParseExact(fields[1], "yyyy-MM-dd", new CultureInfo("en-US"), DateTimeStyles.None, out var examDate);
                var candidateEmail = fields[2];
                var candidateName = fields[3];
                int.TryParse(fields[4], out var question);
                var answer = fields[5].FirstOrDefault();

                if (lastCommand?.ExamId == examId && lastCommand?.ExamDate == examDate && lastCommand?.CandidateEmail == candidateEmail && lastCommand?.CandidateName == candidateName)
                    lastCommand.Answers.Add(new Answer { QuestionNumber = question, ChosenOption = answer });
                else
                {
                    if(lastCommand != null)
                        commands.Add(lastCommand);

                    lastCommand = new CreateExamAttemptCommand
                    {
                        ExamId = examId,
                        ExamDate = examDate,
                        CandidateEmail = candidateEmail,
                        CandidateName = candidateName,
                        Answers = new List<Answer>
                        {
                            new Answer { QuestionNumber = question, ChosenOption = answer }
                        }
                    };
                }
            }

            if (lastCommand != null)
                commands.Add(lastCommand);

            return commands;
        }

        public async Task ParseToFile(Stream outputStream, IEnumerable<ExamAttemptFlatDto> examAttempts)
        {
            using var streamWriter = new StreamWriter(outputStream);

            foreach (var examAttempt in examAttempts)
            {
                await streamWriter.WriteLineAsync($"{examAttempt.ExamId}|{examAttempt.ExamDate}|{examAttempt.CandidateEmail}|{examAttempt.CandidateName}|{examAttempt.QuestionNumber}|{examAttempt.Answer}");
            }
        }
    }
}
