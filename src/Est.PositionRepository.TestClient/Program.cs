using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using EventStore.ClientAPI;
using EventStore.ClientAPI.SystemData;
using NLog;

namespace Est.PositionRepository.TestClient
{
    class Program
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            var connSettings = ConnectionSettings.Create().SetDefaultUserCredentials(new UserCredentials("admin", "changeit"));
            var conn = new ConnectionBuilder(new Uri("tcp://localhost:1113"), connSettings, "testRepository");
            var positionRepo = new PositionRepository($"PositionStream-{conn.ConnectionName}", "PositionUpdated", conn,1000);
            positionRepo.Start().Wait();
            Log.Info($"Initial position is {positionRepo.Get()}");
            using (var connection = conn.Build())
            {
                connection.ConnectAsync().Wait();
                var position = connection.AppendToStreamAsync("positionRepo-tests", ExpectedVersion.Any,
                        new List<EventData> { new EventData(Guid.NewGuid(), "EventTested", true, Encoding.ASCII.GetBytes("abc"), null) })
                    .Result.LogPosition;
                positionRepo.Set(position);
            }
            Thread.Sleep(500);
            Log.Info($"Event saved. Current position is {positionRepo.Get()}");
            Log.Info("Press enter to exit the program");
            Console.ReadLine();
        }
    }
}
