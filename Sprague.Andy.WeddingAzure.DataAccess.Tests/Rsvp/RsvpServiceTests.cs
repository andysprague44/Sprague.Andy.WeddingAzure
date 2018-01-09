using System;
using System.Threading.Tasks;
using Sprague.Andy.WeddingAzure.Models.Rsvp;
using NUnit.Framework;
using Sprague.Andy.WeddingAzure.DataAccess.Rsvp;

namespace Sprague.Andy.WeddingAzure.DataAccess.Tests.Rsvp
{
    [TestFixture]
    public class RsvpServiceTests
    {
        private Random _rand;
        private IRsvpRepository _rsvpService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            AzureStorageEmulatorManager.StartStorageEmulator();
            _rand = new Random();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            AzureStorageEmulatorManager.StopStorageEmulator();
        }

        [SetUp]
        public void SetUp()
        {
            _rsvpService = new RsvpRepository(new ServiceConfiguration());
        }

        [Test]
        public async Task Test_CanAddRsvpAsync()
        {
            var rsvp = new RsvpEntity("testName");
            try
            {
                await _rsvpService.AddRsvpAsync(rsvp);
                var rsvpFromStorage = await _rsvpService.GetRsvpAsync("testName");

                Assert.IsNotNull(rsvpFromStorage);
                Assert.IsFalse(rsvpFromStorage.AttendingWedding, "default entry should be created with AttendingWedding=False");

            }
            finally
            {
                await _rsvpService.DeleteRsvpAsync(rsvp);
            }
        }

        [Test]
        public async Task Test_CanAddOrReplaceRsvpAsync_Add()
        {
            var rsvp = new RsvpEntity("theBride") {AttendingWedding = true};
            try
            {
                await _rsvpService.AddOrReplaceRsvpAsync(rsvp);

                var rsvpFromStorage = await _rsvpService.GetRsvpAsync("theBride");
                Assert.IsNotNull(rsvpFromStorage);
                Assert.IsTrue(rsvpFromStorage.AttendingWedding);
            }
            finally
            {
                await _rsvpService.DeleteRsvpAsync(rsvp);
            }
        }

        [Test]
        public async Task Test_CanAddOrReplaceRsvpAsync_Replace()
        {
            var rsvp = new RsvpEntity("theBride");
            try
            {
                await _rsvpService.AddRsvpAsync(rsvp);
                rsvp.AttendingWedding = true;
                
                await _rsvpService.AddOrReplaceRsvpAsync(rsvp);

                var rsvpFromStorage = await _rsvpService.GetRsvpAsync("theBride");
                Assert.IsNotNull(rsvpFromStorage);
                Assert.IsTrue(rsvpFromStorage.AttendingWedding);
            }
            finally
            {
                await _rsvpService.DeleteRsvpAsync(rsvp);
            }
        }

        

        [Test]
        public void Test_GetRsvpAsync_NoEntryThrowsException()
        {
            var rsvp = new RsvpEntity("theGroom");
            Assert.ThrowsAsync<ArgumentException>(async () =>
                await _rsvpService.GetRsvpAsync(rsvp.Name)
            );
        }

        [Test]
        public void Test_DeleteRsvpAsync_NoEntryThrowsException()
        {
            var rsvp = new RsvpEntity("theGroom");
            Assert.ThrowsAsync<ArgumentException>(async () =>
                await _rsvpService.DeleteRsvpAsync(rsvp)
            );
        }

    }
}
