using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestReach.Exam.Domain.Events;

namespace TestReach.Exam.Domain.EventHandlers
{
    public class ExamAttemptEventHandler : 
        INotificationHandler<ExamAttemptCreatedEvent>
    {
        public Task Handle(ExamAttemptCreatedEvent notification, CancellationToken cancellationToken)
        {
            //could be used to integrate with other business rules
            //do event sourcing and/or communicate with other services
            return Task.CompletedTask;
        }
    }
}
