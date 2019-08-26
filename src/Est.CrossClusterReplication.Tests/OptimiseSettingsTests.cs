using NUnit.Framework;

namespace Est.CrossClusterReplication.Tests
{
    [TestFixture]
    public class OptimiseSettingsTests
    {
        [Test]
        public void given_replicahelper_while_replicating_when_replica_is_fast_then_buffersize_is_increased()
        {
            // Set up
            const int fastReplicaTime = 100;
            var sut = new ReplicaHelper();

            // Act
            var result = sut.OptimizeSettings(fastReplicaTime, PerfTuneSettings.Default);

            // Verify
            Assert.IsTrue(PerfTuneSettings.Default.MaxBufferSize < result.MaxBufferSize);
        }
    }
}