using System.ComponentModel.DataAnnotations;

namespace ServiceSeeker.Model.ProviderDTO
{
    public class PUpdateServiceDTO
    {

        [MaxLength(255)]
        public string? ServiceName1 { get; set; }

        [Display(Name = "Service Price")]
        public decimal? ServicePrice1 { get; set; }

        [MaxLength(255)]
        public string? ServiceImage1 { get; set; }

        [MaxLength(255)]
        [Display(Name= "Service Name is required")]
        public string? ServiceName2 { get; set; }

        public decimal? ServicePrice2 { get; set; }

        [MaxLength(255)]
        public string? ServiceImage2 { get; set; }

        [MaxLength(255)]
        public string? ServiceName3 { get; set; }

        public decimal? ServicePrice3 { get; set; }
        [MaxLength(255)]
        public string? ServiceImage3 { get; set; }


    }
}
