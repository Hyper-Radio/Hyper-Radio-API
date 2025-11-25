using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyper_Radio_API.Models;
using Hyper_Radio_API.Repositories.TrackRepositories;
using Hyper_Radio_API.Services.TrackServices;
using Moq;

namespace Hyper_Radio_API.Test.Services
{
    public class TrackServiceTests
    {
        [Fact]
        public async Task GetTrackByIdAsync_ReturnsDTO_WhenTrackExists()
        {
            //Arrange
            var mockTrack = new Track
            {
                Id = 1,
                Title = "Test Track",
                ReleaseYear = 2023,
                Description = "Test Description",
                Genre = "Test Genre",
                Duration = 200,
                TrackURL = "http://example.com/track.mp3"
            };

            var mockRepo = new Mock<ITrackRepository>();

            mockRepo.Setup(repo => repo.GetTrackByIdAsync(mockTrack.Id))
                .ReturnsAsync(mockTrack);

            var trackService = new TrackService(mockRepo.Object);

            //Act 
            var result = await trackService.GetTrackByIdAsync(mockTrack.Id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Test Track", result.Title);   
            Assert.Equal(2023, result.ReleaseYear);
        }
        [Fact]
        public async Task GetAllTracksAsync_ReturnsDTOList_WhenTracksExists()
        {
            //Arrange
            var tracks = new List<Track>
            {
                new Track {
                Id = 1,
                Title = "Test Track",
                ReleaseYear = 2023,
                Description = "Test Description",
                Genre = "Test Genre",
                Duration = 200,
                TrackURL = "http://example.com/track.mp3"
                },
                new Track {
                Id = 2,
                Title = "Test Track 2",
                ReleaseYear = 2023,
                Description = "Test Description",
                Genre = "Test Genre",
                Duration = 200,
                TrackURL = "http://example.com/track.mp3"
                }
            };

            var mockRepo = new Mock<ITrackRepository>();

            mockRepo.Setup(repo => repo.GetAllTracksAsync()).ReturnsAsync(tracks);

            var trackService = new TrackService(mockRepo.Object);
            //Act 
            var result = await trackService.GetAllTracksAsync();
            //Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Collection(result, dto =>
            {
                Assert.Equal(1, dto.Id);
                Assert.Equal("Test Track", dto.Title);
                Assert.Equal(2023, dto.ReleaseYear);
            },
            dto =>
            {
                Assert.Equal(2, dto.Id);
                Assert.Equal("Test Track 2", dto.Title);
                Assert.Equal(2023, dto.ReleaseYear);
            }); 
        }

    }
}
