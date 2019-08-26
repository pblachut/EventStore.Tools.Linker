using EventStore.ClientAPI;
using Moq;
using NUnit.Framework;

namespace Est.CrossClusterReplication.Tests
{
    public class ReplicaServiceTests
    {
        [Test]
        public void given_replicaservice_is_created_when_started_then_no_errors_expected()
        {
            // Set up
            var originBuilder = new Mock<IConnectionBuilder>();
            var connection = new Mock<IEventStoreConnection>();
            originBuilder.Setup(a => a.Build()).Returns(connection.Object);
            var destinationBuilder = new Mock<IConnectionBuilder>();
            destinationBuilder.Setup(a => a.Build()).Returns(connection.Object);
            var positionRepo = new Mock<IPositionRepository>();
            var sut = new ReplicaService(originBuilder.Object, destinationBuilder.Object, positionRepo.Object, null,
                ReplicaSettings.Default());

            // Act
            var result = sut.Start().Result;

            // Verify
            Assert.IsTrue(result);
        }
    }
}