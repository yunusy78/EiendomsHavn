namespace EindomsHavnAPI.DTOs.CategoryDtos;

public class GetByIdCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public string ImageUrl { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public bool Status { get; set; }
    
}