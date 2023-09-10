namespace WEB.DTOs.Customer;

public class ResultCustomerDto
{
    public Guid CustomerId { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerEmail { get; set; }
    public string? CustomerPhoneNumber { get; set; }
    public string? CustomerImageUrl { get; set; }
    public string? CustomerTitle { get; set; }
    public string? CustomerComment { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool CustomerStatus { get; set; }
    
}