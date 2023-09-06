namespace API.DTOs.EmployeeDtos;

public class UpdateEmployeeDto
{
    public Guid EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public string EmployeeTitle { get; set; }
    public string EmployeeEmail { get; set; }
    public string EmployeePhoneNumber { get; set; }
    public string EmployeeImageUrl { get; set; }
    public bool EmployeeStatus { get; set; }
}