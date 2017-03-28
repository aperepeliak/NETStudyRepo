using System.Collections.Generic;
using GH.WebUI.Core.Models;

namespace GH.WebUI.Core.Repositories
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