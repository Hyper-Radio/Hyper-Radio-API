using Hyper_Radio_API.Data;
using Hyper_Radio_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Hyper_Radio_API.Repositories;

public class ShowRepository : IShowRepository
{

    private readonly HyperRadioDbContext _context;

    public ShowRepository(HyperRadioDbContext context)
    {
        _context = context;
    }


    public async Task<List<Show>> GetAllShowsAsync()
    {
        var shows = await _context.Shows.ToListAsync();
        return shows;
    }

    public async Task<Show> GetShowByIdAsync(int showId)
    {
        var show = await _context.Shows.FirstOrDefaultAsync(s => s.Id == showId);
        return show;
    }

    public async Task<int> CreateShowAsync(Show show)
    {
        await _context.Shows.AddAsync(show);
        await _context.SaveChangesAsync();

        return show.Id;
    }

    public Task<Show> UpdateShowAsync(Show show)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteShowAsync(int showId)
    {
        throw new NotImplementedException();
    }
}