using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace asp_party_invitation.Models
{
    public class RSVPResponse
    {
        public ObjectId Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]      
        public bool WillAttend { get; set; }
        public string Message { get; set; }
    }
}
