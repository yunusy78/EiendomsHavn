namespace EindomsHavnAPI.DTOs.ProductDtos;

public class ResultProductDetailsDtoWithProduct
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public string? Type { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    
    public string? Street { get; set; }
    
    public string? City { get; set; }
    
    public string? PostalCode { get; set; }
    
    public string? Country { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public string CoverImageUrl { get; set; }
    
    public Guid ProductId { get; set; }
    
    public int Size { get; set; }
    
    public byte BadromCount { get; set; }
    
    public byte BathCount { get; set; }
    
    public byte RomCount { get; set; }
    
    public byte GarageSize { get; set; }
    
    public string BuildYear { get; set; }
    
    public string Location { get; set; }
    
    public string VideoUrl { get; set; }
    
    public Guid EmployeeId { get; set; }
    
    public Guid CategoryId { get; set; }
    
    public string Name { get; set; }

    
    public string EmployeeName { get; set; }

    public string EmployeeTitle { get; set; }

    public string EmployeeEmail { get; set; }

    public string EmployeePhoneNumber { get; set; }

    public bool EmployeeStatus { get; set; }

    public string EmployeeImageUrl { get; set; }
    

    
}