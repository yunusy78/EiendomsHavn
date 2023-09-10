namespace web.DTOs.ApplicationUserDto;

public class Authenticated
{
    private readonly IHttpClientFactory _clientFactory;
    
    public Authenticated(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    
    public async Task<bool> IsAuthenticatedAsync()
    {
        try
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5076/api/Auth/api/IsAuthenticated");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return bool.Parse(content); // API'den dönen yanıtı bool'a çevirin
            }
            else
            {
                // API'den geçersiz yanıt alındıysa, kullanıcı oturumu kapalıdır.
                return false;
            }
        }
        catch (Exception)
        {
            // API'ye ulaşılamadıysa, kullanıcı oturumu kapalıdır.
            return false;
        }
    }
}