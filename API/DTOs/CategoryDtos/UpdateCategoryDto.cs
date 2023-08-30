namespace EindomsHavnAPI.DTOs.CategoryDtos;

public class UpdateCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public string ImageUrl { get; set; }
    
    public bool Status { get; set; }
    
}