using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestReach.Exam.Core.Bus;
using TestReach.Exam.Domain.CommandHandlers;
using TestReach.Exam.Domain.Commands;
using TestReach.Exam.Domain.Entities;
using TestReach.Exam.Domain.Events;
using TestReach.Exam.Domain.Repositories;
using Xunit;


namespace TestReach.Exam.UnitTests.Domain.CommandHandlers
{
    
    public class ExamAttemptCommandHandlerTests
    {
        [Fact]
        public async Task Should_BatchCreateExamAttempt_When_ReceivingValidCommand()
        {
            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            
            var existingExams = fixture.Create<Dictionary<string, Exam.Domain.Entities.Exam>>();
            fixture.Customize<CreateExamAttemptCommand>(cust => cust.With(x => x.ExamId, existingExams.Keys.First()));
            var cancelationToken = new CancellationToken();
            var command = fixture.Create<BatchCreateExamAttemptCommand>();
            var examAttemptMock = new Mock<ExamAttempt>();

            var autoMocker = new AutoMocker();

            examAttemptMock.Setup(x => x.CalculateScore());
            autoMocker.Setup<IExamRepository, Task<Dictionary<string, Exam.Domain.Entities.Exam>>>(x => x.GetExistingExams(It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>())).ReturnsAsync(existingExams);
            autoMocker.Setup<IMapper, ExamAttempt>(x => x.Map<ExamAttempt>(It.IsAny<CreateExamAttemptCommand>())).Returns(examAttemptMock.Object);
            autoMocker.Setup<IExamAttemptRepository>(x => x.UnitOfWork.Commit(It.IsAny<CancellationToken>()));
            autoMocker.Setup<IExamAttemptRepository>(x => x.Add(It.IsAny<ExamAttempt>()));

            var result = await autoMocker.CreateInstance<ExamAttemptCommandHandler>().Handle(command, cancelationToken);

            result.ResponseCode.Should().Be(Core.Enums.Response.Success);
            autoMocker.Verify<IExamRepository>(x => x.GetExistingExams(It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()), Times.Once);
            autoMocker.Verify<IExamAttemptRepository>(x => x.Add(It.IsAny<ExamAttempt>()), Times.Exactly(command.Commands.Count()));
            autoMocker.Verify<IExamAttemptRepository>(x => x.UnitOfWork.Commit(It.IsAny<CancellationToken>()), Times.Once);
            autoMocker.Verify<IMediatorHandler>(x => x.PublishEvent(It.IsAny<ExamAttemptCreatedEvent>(), It.IsAny<CancellationToken>()), Times.Exactly(command.Commands.Count()));
            examAttemptMock.Verify(x => x.CalculateScore(), Times.Exactly(command.Commands.Count()));
        }
    }
}
