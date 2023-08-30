namespace EindomsHavnAPI.DTOs.ProductDtos;

public class ResultProductDto
{
    
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public string CoverImageUrl { get; set; }
    
    public Guid CategoryId { get; set; }
    
    public Guid EmployeeId { get; set; }
    
    public Guid AddressId { get; set; }
    
    
    
    
} 