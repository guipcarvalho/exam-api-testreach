using System;
using System.Collections.Generic;
using System.Net.Http;
using TestReach.Exam.Registration;
using Xunit;

namespace TestReach.Exam.IntegrationTests.Config
{
    [CollectionDefinition(nameof(IntegrationTestsFixtureCollection), DisableParallelization = true)]
    public class IntegrationTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture<Startup>> { }

    public sealed class IntegrationTestsFixture<TStartup> : IDisposable where TStartup : class
    {
        public readonly ApiFactory<TStartup> Factory;
        public HttpClient Client;

        public IntegrationTestsFixture()
        {
            Factory = new ApiFactory<TStartup>();
            Client = Factory.CreateClient();
        }

        public void Dispose()
        {
            Client?.Dispose();
            Factory?.Dispose();
        }
    }
}
