using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceSeeker.Model
{
  
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        // Foreign key for User
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;

        // Foreign key for Provider
        public int ProviderId { get; set; }
        [ForeignKey("ProviderId")]
        public Provider Provider { get; set; } = null!;

        public required string  ServiceName { get; set; }
        public required decimal? ServicePrice { get; set; }
        public string? ServiceImage { get; set; }
        public string? ProviderNote { get; set; }
        public string? CompletionDate { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;
        public required string BookingStatus { get; set; }= "Booked";
        public required string ModeOfPayment { get; set; }
        public  string ? PaymentId { get; set; }

       
       




    }
}
