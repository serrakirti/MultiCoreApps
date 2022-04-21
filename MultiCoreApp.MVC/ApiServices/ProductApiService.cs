using MultiCoreApp.MVC.DTOs;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json;

namespace MultiCoreApp.MVC.ApiServices
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient=httpClient;
        }

        public async Task<IEnumerable<ProductWithCategoryDto>> GetAllAsync()
        {
            IEnumerable<ProductWithCategoryDto> proDtos;
            var response = await _httpClient.GetAsync("product");
            if (response.IsSuccessStatusCode)
            {
               proDtos =JsonConvert.DeserializeObject<IEnumerable<ProductWithCategoryDto>>(await response.Content.ReadAsStringAsync())!;

            }
            else
            {
                proDtos = null!;
            }
            return proDtos;
        }


        public async Task<ProductWithCategoryDto> AddAsync(ProductWithCategoryDto proDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(proDto), Encoding.UTF8, "application/json");//tek bir satır gönderiyoruz

            var response = await _httpClient.PostAsync("product", stringContent);
            if (response.IsSuccessStatusCode)
            {
                proDto = JsonConvert.DeserializeObject<ProductWithCategoryDto>(await response.Content.ReadAsStringAsync())!;
                return proDto;
            }
            else
            {
                return null!;
            }
        }


        public async Task<bool> Update(ProductWithCategoryDto proDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(proDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"product", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<ProductWithCategoryDto> GetByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"product/{id}");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ProductWithCategoryDto>(await response.Content.ReadAsStringAsync())!;
            }
            else
            {
                return null!;
            }
        }
        public async Task<IEnumerable<ProductWithCategoryDto>> GetAllWithCategoryAsync()
        {
            IEnumerable<ProductWithCategoryDto> productDtos;
            var response = await _httpClient.GetAsync("Product/categoryall");
            if (response.IsSuccessStatusCode)
            {
                productDtos=
                    JsonConvert.DeserializeObject<IEnumerable<ProductWithCategoryDto>>(await response.Content.ReadAsStringAsync())!; 
            }
            else
            {
                productDtos = null!;
            }
            return productDtos;
        }
       

    }
}
