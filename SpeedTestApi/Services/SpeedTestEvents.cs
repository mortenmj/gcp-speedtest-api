using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpeedTestApi.Models;
using Google.Cloud.PubSub.V1;
using Google.Protobuf;

namespace SpeedTestApi.Services
{
    public class SpeedTestEvents : ISpeedTestEvents, IDisposable
    {
        private PublisherClient _publisher { get; set; }

        public Task Initialization { get; private set; }

        public SpeedTestEvents(string projectId, string topicId)
        {
            var publisherClient = PublisherServiceApiClient.Create();
            _publisher = PublisherClient.CreateAsync(
                new TopicName(projectId, topicId))
                .GetAwaiter().GetResult();
        }

        public async Task PublishSpeedTest(TestResult speedTest)
        {
            var message = JsonConvert.SerializeObject(speedTest);
            await _publisher.PublishAsync(message);
        }

        public void Dispose()
        {
            /* Nothing to do */
        }
    }
}