using Microsoft.Build.Framework;

namespace WEB.DTOs.NewslettersDtos;

public class CreateNewsletterDto
{
    
    public Guid Id { get; set; }
    
   
    public string Email { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public bool Status { get; set; }
    
}