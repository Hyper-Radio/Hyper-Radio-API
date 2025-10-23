using Hyper_Radio_API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hyper_Radio_API.DTOs.FavoriteDTOs
{
    public class FavoriteDTO
    {
        public int? Id { get; set; }

        public int? UserId_FK { get; set; }

        public int? TrackId_FK { get; set; }
    }
}
