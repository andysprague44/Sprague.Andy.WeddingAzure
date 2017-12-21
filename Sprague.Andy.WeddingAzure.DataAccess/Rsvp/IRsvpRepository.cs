using Sprague.Andy.WeddingAzure.Models.Rsvp;
using System.Threading.Tasks;

namespace Sprague.Andy.WeddingAzure.DataAccess.Rsvp
{
    public interface IRsvpRepository
    {
        Task AddRsvpAsync(RsvpEntity rsvp);
        Task AddOrReplaceRsvpAsync(RsvpEntity rsvp);
        Task UpdateRsvpAsync(RsvpEntity rsvp);
        Task DeleteRsvpAsync(RsvpEntity rsvp);
        Task<RsvpEntity> GetRsvpAsync(string name);
    }
}
