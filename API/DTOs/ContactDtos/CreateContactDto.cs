namespace EindomsHavnAPI.DTOs.ContactDtos;

public class CreateContactDto
{
    
    public Guid Id { get; set; }
    public string ContactName { get; set; }
    public string Email { get; set; }
    public string? Message { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool Status { get; set; }
    
}