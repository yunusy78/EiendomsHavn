namespace WEB.DTOs.AboutDtos;

public class ResultAboutDto
{
    
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string SubTitle { get; set; }
    public string ImageUrl { get; set; }
    public string CoverImageUrl { get; set; }
    public string VideoUrl { get; set; }
    public bool Status { get; set; }
    
}