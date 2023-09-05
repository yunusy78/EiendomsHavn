using System.ComponentModel.DataAnnotations;

namespace EindomsHavn.DTOs.CategoryDtos;

public class UpdateCategoryDto
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    
    public string CategoryDescription { get; set; }
    
    public string ImageUrl { get; set; }
    
    public bool Status { get; set; }
    
}