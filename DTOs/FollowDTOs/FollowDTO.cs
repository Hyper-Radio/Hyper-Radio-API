using Hyper_Radio_API.Models;
using System.ComponentModel.DataAnnotations;

namespace Hyper_Radio_API.DTOs.FollowDTOs
{
    public class FollowDTO
    {
        public int? Id { get; set; }
        public int? UserId_FK { get; set; }
        public int? CreatorId_FK { get; set; }
    }
}
