using EindomsHavnAPI.DTOs.ContactDtos;
using EindomsHavnAPI.DTOs.NewsletterDtos;
using EindomsHavnAPI.DTOs.ProductDtos;

namespace EindomsHavnAPI.Repositories.ContactRepository;

public interface IContactRepository
{
    Task<List<ResultContactDto>> GetAllAsync();
        
    void CreateAsync(CreateContactDto contactDto);
        
    void UpdateAsync(UpdateContactDto contactDto);
        
    void DeleteAsync(Guid id);
        
    Task<GetByIdContactDto> GetByIdAsync(Guid id);
    

}