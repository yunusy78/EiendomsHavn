namespace WEB.DTOs.ProductDtos;

public class ResultProductDto
{
    public Guid ProductId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CoverImageUrl { get; set; }
    public Guid CategoryId { get; set; }
    public Guid EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public string Name { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    
    public bool Status { get; set; }
}