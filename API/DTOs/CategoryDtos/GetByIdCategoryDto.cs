namespace EindomsHavnAPI.DTOs.CategoryDtos;

public class GetByIdCategoryDto
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string CategoryDescription { get; set; }
    
    public string ImageUrl { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public bool Status { get; set; }
    
}