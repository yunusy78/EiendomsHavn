using System.ComponentModel.DataAnnotations;

namespace EindomsHavnAPI.DTOs.CategoryDtos;

public class ResultCategoryDto
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    
    [Required]
    public string CategoryDescription { get; set; }
    
    public string ImageUrl { get; set; }
    
    public DateTime CreatedAt { get; set; }
   
    public bool Status { get; set; }
}