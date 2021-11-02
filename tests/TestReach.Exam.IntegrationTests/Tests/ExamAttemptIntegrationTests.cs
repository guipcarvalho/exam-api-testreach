using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestReach.Exam.IntegrationTests.Config;
using TestReach.Exam.Registration;
using Xunit;

namespace TestReach.Exam.IntegrationTests.Tests
{
    [Collection(nameof(IntegrationTestsFixtureCollection))]
    public class ExamAttemptIntegrationTests
    {
        private readonly IntegrationTestsFixture<Startup> _testsFixture;

        public ExamAttemptIntegrationTests(IntegrationTestsFixture<Startup> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Import and export to see if the data is there")]
        public async Task Should_ImportAndExport_With_ValidFiles()
        {
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            writer.WriteLine("Exam Id| Exam Date|Candidate Email|Candidate Name|Question Number|Answer");
            writer.WriteLine("EX202001|2020-08-01|jdoe@email.com|John Doe|1|A");
            writer.WriteLine("EX202001|2020-08-01|jdoe@email.com|John Doe|2|C");
            writer.Flush();

            using var content = new MultipartFormDataContent();
            content.Add(new StreamContent(stream), "file", "attempt.csv");
            var responseImport = await _testsFixture.Client.PostAsync("/exam-attempts/import", content);

            responseImport.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseExport = await _testsFixture.Client.GetAsync("/exam-attempts/export/exam/EX202001/candidate/jdoe@email.com");

            responseExport.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact(DisplayName = "Import should return bad request when no file is provided")]
        public async Task Should_NotImport_Without_FileParam()
        {
            var response = await _testsFixture.Client.PostAsync("/exam-attempts/import", null);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact(DisplayName = "Export should return not found when no exam attempt was found for the given parameters")]
        public async Task Export_Should_ReturnNotFound_When_NotFindingWithParameters()
        {
            var response = await _testsFixture.Client.GetAsync("/exam-attempts/export/exam/123213213/candidate/123@123123");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
