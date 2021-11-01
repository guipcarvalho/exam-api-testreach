using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestReach.Exam.Core.Messages;

namespace TestReach.Exam.Core.Bus
{
    public interface IMediatorHandler
    {
        Task<GenericResult> SendCommand<T>(T command, CancellationToken cancellationToken = default) where T : Command;
        Task PublishEvent<T>(T @event, CancellationToken cancellationToken = default) where T : Event;
    }
}
