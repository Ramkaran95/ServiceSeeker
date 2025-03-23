namespace ServiceSeeker.Model.BookingDTO
{
    public class ResponseDTO
    {
        public required string ProviderNote { get; set; }
        public required string CompletionDate { get; set; }
   
        public required string BookingStatus { get; set; } = "Booked";
    }
}
