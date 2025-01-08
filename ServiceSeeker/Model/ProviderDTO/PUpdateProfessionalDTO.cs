using System.ComponentModel.DataAnnotations;

namespace ServiceSeeker.Model.ProviderDTO
{
    public class PUpdateProfessionalDTO
    {

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
