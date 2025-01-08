using System.ComponentModel.DataAnnotations;

namespace ServiceSeeker.Model.ProviderDTO
{
    public class providerDetailsDTO
    {
        public int ProviderId { get; set; }

        [Required, MaxLength(100)]

        public required string UserName { get; set; }

        

        [Required, MaxLength(100)]
        public required string FirstName { get; set; }

        [MaxLength(100)]
        public string? MiddleName { get; set; }

        [MaxLength(100)]
        public string? LastName { get; set; }

        [MaxLength(255)]
        public string? ProfilePhoto { get; set; } = "defaultProfile.jpg";

        [Required, MinLength(10), MaxLength(15)]
        public required string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address..")]
        public required string Email { get; set; }

        [Required, MaxLength(100)]
        public required string ProfessionType { get; set; }

        [Range(0, 40, ErrorMessage = "Invalid experience details")]
        public int? YearOfEx { get; set; } = 0;

        [MaxLength(1000)]
        public required string Bio { get; set; }

        [MaxLength(255)]
        public string? LanguageSpoke { get; set; }

        [MaxLength(255)]
        public string? SocialLink1 { get; set; }

        [MaxLength(255)]
        public string? SocialLink2 { get; set; }

        [MaxLength(100)]
        public string? TimeOfService { get; set; }


        public string? AreaServe { get; set; }

        [Required]
        public required bool Availability { get; set; }

        [MaxLength(255)]
        public string? Skill1 { get; set; }

        [MaxLength(255)]
        public string? Skill2 { get; set; }

        [MaxLength(255)]
        public string? Skill3 { get; set; }

        [MaxLength(255)]
        public string? ServiceName1 { get; set; }

        public decimal? ServicePrice1 { get; set; }

        [MaxLength(255)]
        public string? ServiceImage1 { get; set; }

        [MaxLength(255)]
        public string? ServiceName2 { get; set; }

        public decimal? ServicePrice2 { get; set; }

        [MaxLength(255)]
        public string? ServiceImage2 { get; set; }

        [MaxLength(255)]
        public string? ServiceName3 { get; set; }

        public decimal? ServicePrice3 { get; set; }

        [MaxLength(255)]
        public string? ServiceImage3 { get; set; }
        public string? area { get; set; } = null;
        [Required, MaxLength(100)]
        public required string State { get; set; }

        [Required, MaxLength(100)]
        public required string District { get; set; }

        [Required]
        [Range(100000, 999999, ErrorMessage = "Pincode must be a 6-digit number.")]
        public required int PinCode { get; set; }

        [Required, MaxLength(100)]
        public required string City { get; set; }

        [Required]
        public required string Longitude { get; set; }

        [Required]
        public required string Latitude { get; set; }
    }
}
