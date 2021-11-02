using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestReach.Exam.Application.Helpers.Contracts;
using TestReach.Exam.Application.Services;
using TestReach.Exam.Core.Bus;
using TestReach.Exam.Core.Messages;
using TestReach.Exam.Domain.CommandHandlers;
using TestReach.Exam.Domain.Commands;
using TestReach.Exam.Domain.Dtos;
using TestReach.Exam.Domain.Entities;
using TestReach.Exam.Domain.Events;
using TestReach.Exam.Domain.Repositories;
using Xunit;


namespace TestReach.Exam.UnitTests.Application.Services
{
    
    public class ExamAttemptServiceTests
    {
        [Fact]
        public async Task Should_ExportExamAttemptToFile_When_ReceivingValidFileTypeAndFindingAttempts()
        {
            var fixture = new Fixture();
            var autoMocker = new AutoMocker();
            var cancelationToken = new CancellationToken();

            autoMocker.Setup<IExamAttemptRepository, Task<List<ExamAttemptDto>>>(x => x.GetByExamIdAndCandidate(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(fixture.Create<List<ExamAttemptDto>>());

            var result = await autoMocker.CreateInstance<ExamAttemptService>().ExportExamAttemptToFile("1", "1", "csv", cancelationToken);

            result.ResponseCode.Should().Be(Core.Enums.Response.Success);
            result.Data.Should().BeOfType<byte[]>();

            autoMocker.Verify<IExamAttemptRepository>(x => x.GetByExamIdAndCandidate(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
            autoMocker.Verify<IExamAttemptFileParser>(x => x.ParseToFile(It.IsAny<Stream>(), It.IsAny<List<ExamAttemptDto>>()), Times.Once);
        }

        [Fact]
        public async Task ExportExamAttemptToFile_Should_ReturnNotFoundResult_When_ReceivingValidFileTypeAndNotFindingAttempts()
        {
            var autoMocker = new AutoMocker();
            var cancelationToken = new CancellationToken();

            autoMocker.Setup<IExamAttemptRepository, Task<List<ExamAttemptDto>>>(x => x.GetByExamIdAndCandidate(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(new List<ExamAttemptDto>());

            var result = await autoMocker.CreateInstance<ExamAttemptService>().ExportExamAttemptToFile("1", "1", "csv", cancelationToken);

            result.ResponseCode.Should().Be(Core.Enums.Response.NotFound);

            autoMocker.Verify<IExamAttemptRepository>(x => x.GetByExamIdAndCandidate(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
            autoMocker.Verify<IExamAttemptFileParser>(x => x.ParseToFile(It.IsAny<Stream>(), It.IsAny<List<ExamAttemptDto>>()), Times.Never);
        }

        [Fact]
        public async Task Should_ImportAttempts_When_ReceivingValidFile()
        {
            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var autoMocker = new AutoMocker();
            var cancelationToken = new CancellationToken();
            var commandResult = new GenericResult(Core.Enums.Response.Success, "test");

            autoMocker.Setup<IExamAttemptFileParser, Task<IEnumerable<CreateExamAttemptCommand>>>(x => x.GetExamAttemps(It.IsAny<Stream>())).ReturnsAsync(fixture.Create<IEnumerable<CreateExamAttemptCommand>>());
            autoMocker.Setup<IMediatorHandler, Task<GenericResult>>(x => x.SendCommand(It.IsAny<BatchCreateExamAttemptCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(commandResult);

            using var stream = new MemoryStream();
            var result = await autoMocker.CreateInstance<ExamAttemptService>().ImportAttempts(stream, "csv", cancelationToken);

            result.Should().Be(commandResult);

            autoMocker.Verify<IMediatorHandler>(x => x.SendCommand(It.IsAny<BatchCreateExamAttemptCommand>(), It.IsAny<CancellationToken>()), Times.Once);
            autoMocker.Verify<IExamAttemptFileParser>(x => x.GetExamAttemps(It.IsAny<Stream>()), Times.Once);
        }
    }
}
