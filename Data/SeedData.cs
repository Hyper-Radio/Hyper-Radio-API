using Hyper_Radio_API.Models;

namespace Hyper_Radio_API.Data
{
    public static class SeedData
    {
        public static void InitializeDB(HyperRadioDbContext _context)
        {
            if (_context.Tracks.Any())
            {
                return;
            }

            var creator = new Creator { Email = "Demo@Creator", PasswordHash = "123", Username = "Democreator", Description = "Description" };

            _context.Creators.Add(creator);

            _context.SaveChanges();

            var tracks = new List<Track>
            {
                new Track { Title = "Song A", ReleaseYear = 1999, Genre = "Rock", Description = "Demo track 1", TrackURL = "Hls/Track1", Duration = 1, CreatorId_FK = creator.Id},
                new Track { Title = "Song B", ReleaseYear = 2000, Genre = "Soul", Description = "Demo track 2", TrackURL = "Hls/Track2", Duration = 1, CreatorId_FK = creator.Id},
                new Track { Title = "Song C", ReleaseYear = 2005, Genre = "Jazz", Description = "Demo track 3", TrackURL = "Hls/Track3", Duration = 1, CreatorId_FK = creator.Id}
            };

            _context.Tracks.AddRange(tracks);
            _context.SaveChanges();

            var show = new Show
            {
                Name = "Demo Show",
                ScheduledStart = DateTime.UtcNow.AddDays(1), // for example
                ShowTracks = new List<ShowTrack>()
            };

            // Add all tracks to the show with order and fades
            int order = 1;
            foreach (var track in tracks)
            {
                show.ShowTracks.Add(new ShowTrack
                {
                    TrackId = track.Id,
                    Order = order++,
                    FadeIn = 0.5f,
                    FadeOut = 0.5f
                });
            }

            _context.Shows.Add(show);
            _context.SaveChanges();
        }
    }
   
}

