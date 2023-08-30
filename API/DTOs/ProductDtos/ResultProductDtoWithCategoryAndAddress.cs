namespace EindomsHavnAPI.DTOs.ProductDtos;

public class ResultProductDtoWithCategoryAndAddress
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CoverImageUrl { get; set; }
    public Guid CategoryId { get; set; }
    public Guid EmployeeId { get; set; }
    public Guid AddressId { get; set; }
    public string Name { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    
}