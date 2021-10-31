using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestReach.Exam.Core.Messages;

namespace TestReach.Exam.Core.Bus
{
    public class MediatorHandler : IMediatorHandler
    {
        public Task PublishEvent<T>(T @event) where T : Event
        {
            throw new NotImplementedException();
        }

        public Task<GenericResult> SendCommand<T>(T command, CancellationToken cancellationToken = default) where T : Command
        {
            throw new NotImplementedException();
        }
    }
}
