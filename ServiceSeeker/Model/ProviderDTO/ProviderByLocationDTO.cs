namespace ServiceSeeker.Model.ProviderDTO
{
    public class ProviderByLocationDTO
    {
        public int ProviderId { get; set; }
    public required string UserName { get; set; }
    public required string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string? ProfilePhoto { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
    public DateTime CreateAt { get; set; }
    public required string ProfessionType { get; set; }
    public int? YearOfEx { get; set; }
    public required string Bio { get; set; }
    public string? LanguageSpoke { get; set; }
    public string? SocialLink1 { get; set; }
    public string? SocialLink2 { get; set; }
    public string? TimeOfService { get; set; }
    public string? AreaServe { get; set; }
    public bool Availability { get; set; }
    public string? Skill1 { get; set; }
    public string? Skill2 { get; set; }
    public string? Skill3 { get; set; }
    public string? ServiceName1 { get; set; }
    public decimal? ServicePrice1 { get; set; }
    public string? ServiceImage1 { get; set; }
    public string? ServiceName2 { get; set; }
    public decimal? ServicePrice2 { get; set; }
    public string? ServiceImage2 { get; set; }
    public string? ServiceName3 { get; set; }
    public decimal? ServicePrice3 { get; set; }
    public string? ServiceImage3 { get; set; }
    public required string State { get; set; }
    public required string District { get; set; }
    public int PinCode { get; set; }
    public required string City { get; set; }
    public required string Longitude { get; set; }
    public required string Latitude { get; set; }
    }
}
