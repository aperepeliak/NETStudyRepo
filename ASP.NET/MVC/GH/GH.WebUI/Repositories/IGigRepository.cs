using System.Collections.Generic;
using GH.WebUI.Models;

namespace GH.WebUI.Repositories
{
    public interface IGigRepository
    {
        void Add(Gig gig);

        Gig GetGig(int gigId);
        Gig GetGigWithAttendees(int gigId);

        IEnumerable<Gig> GetGigsUserAttending(string userId);
        IEnumerable<Gig> GetUpcomingGigsByArtist(string userId);
    }
}