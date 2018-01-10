using System.ComponentModel.DataAnnotations.Schema;

namespace gigstore.Models
{
    public class Attendance
    {
        [ForeignKey("GigId")]
        public int GigId { get; set; }
        [ForeignKey("AttendeeId")]
        public string AttendeeId { get; set; }
        public Gig Gig { get; set; }
        public ApplicationUser Attendee { get; set; }
        public bool IsAttending { get; set; }
    }
}
