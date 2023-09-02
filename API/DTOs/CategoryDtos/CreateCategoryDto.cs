namespace EindomsHavnAPI.DTOs.CategoryDtos;

public class CreateCategoryDto
{
   
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public string ImageUrl { get; set; }
    
    public DateTime CreatedAt { get; set; }
   
    public bool Status { get; set; }
    
    
}