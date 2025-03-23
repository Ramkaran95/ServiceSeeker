using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceSeeker.Model.BookingDTO
{
    public class AddBookDTO
    {
        public int BookingId { get; set; }
       
        public int UserId { get; set; }

        
        public int ProviderId { get; set; }

        public required string ServiceName { get; set; }
        public required decimal? ServicePrice { get; set; }
        public string? ServiceImage { get; set; }
        public string? ProviderNote { get; set; }
        public string? CompletionDate { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;
        public required string BookingStatus { get; set; } = "Booked";
        public required string ModeOfPayment { get; set; }
        public string? PaymentId { get; set; }





    }
}
