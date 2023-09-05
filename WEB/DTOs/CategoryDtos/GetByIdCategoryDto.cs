namespace EindomsHavn.DTOs.CategoryDtos;

public class GetByIdCategoryDto
{
    public Guid CategoryIdId { get; set; }
    public string Name { get; set; }
    public string CategoryDescription { get; set; }
    
    public string ImageUrl { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public bool Status { get; set; }
    
}