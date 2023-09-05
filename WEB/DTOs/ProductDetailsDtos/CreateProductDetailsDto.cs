namespace EiendomsHavn.DTOs.ProductDtos;

public class CreateProductDetailsDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    
    public int Size { get; set; }
    
    public byte BadromCount { get; set; }
    
    public byte BathCount { get; set; }
    
    public byte RomCount { get; set; }
    
    public byte GarageSize { get; set; }
    
    public string BuildYear { get; set; }
    
    public string Location { get; set; }
    
    public string VideoUrl { get; set; }
}