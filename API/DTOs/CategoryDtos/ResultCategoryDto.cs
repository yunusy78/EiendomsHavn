using System.ComponentModel.DataAnnotations;

namespace EindomsHavnAPI.DTOs.CategoryDtos;

public class ResultCategoryDto
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    
  
    public string CategoryDescription { get; set; }
    
    public DateTime CreatedAt { get; set; }
   
    public bool Status { get; set; }
}