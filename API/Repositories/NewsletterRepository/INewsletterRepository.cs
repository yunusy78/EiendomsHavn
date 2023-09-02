using EindomsHavnAPI.DTOs.NewsletterDtos;
using EindomsHavnAPI.DTOs.ProductDtos;

namespace EindomsHavnAPI.Repositories.NewsletterRepository;

public interface INewsletterRepository
{
    Task<List<ResultNewsletterDto>> GetAllNewslettersAsync();
        
    void CreateNewsletterAsync(CreateNewsletterDto productDto);
        
    void UpdateNewsletterAsync(UpdateNewsletterDto productDto);
        
    void DeleteNewsletterAsync(Guid id);
        
    Task<GetByIdNewsletterDto> GetNewsletterByIdAsync(Guid id);
    

}