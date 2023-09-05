namespace WEB.DTOs.CitiyDtos;

public class ResultCityDto
{
    public Guid Id { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string ImageUrl { get; set; }
    public string CreatedAt { get; set; }
    public bool Status { get; set; }
    public int CityCount { get; set; }
}