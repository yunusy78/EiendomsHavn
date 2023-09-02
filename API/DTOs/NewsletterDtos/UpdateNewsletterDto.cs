namespace EindomsHavnAPI.DTOs.NewsletterDtos;

public class UpdateNewsletterDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool Status { get; set; }
}