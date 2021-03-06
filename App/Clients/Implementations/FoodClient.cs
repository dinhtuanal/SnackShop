using Clients.Interfaces;
using Newtonsoft.Json;
using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients.Implementations
{
    public class FoodClient : BaseClient, IFoodClient
    {
        public async Task<int> Add(FoodViewModel model, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("foods/add", content);
            return (int)response.StatusCode;
        }

        public async Task<int> CountPagination()
        {
            var responseMessage = await httpClient.GetAsync("foods/count-pagination");
            var response = await responseMessage.Content.ReadAsStringAsync();
            var responseResult = JsonConvert.DeserializeObject<int>(response);
            return responseResult;
        }

        public async Task<int> Delete(string foodId, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await httpClient.DeleteAsync("foods/delete/" + foodId);
            return (int)response.StatusCode;
        }

        public async Task<List<VFood>> GetAll()
        {
            var response = await httpClient.GetAsync("foods/");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<VFood>>(content);
        }

        public async Task<VFood> GetById(string foodId)
        {
            var response = await httpClient.GetAsync("foods/" + foodId);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<VFood>(content);
        }

        public async Task<List<VFood>> GetBySubCategoryId(string subCategoryId)
        {
            var response = await httpClient.GetAsync("foods/get-by-subcategoryid/" + subCategoryId);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<VFood>>(content);
        }

        public async Task<List<VFood>> GetPagination(PageViewModel page)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(page), Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("foods/get-pagination", content);
            var response = await responseMessage.Content.ReadAsStringAsync();
            var responseResult = JsonConvert.DeserializeObject<List<VFood>>(response);
            return responseResult;
        }

        public async Task<int> Update(FoodViewModel model, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("foods/update",content);
            return (int)response.StatusCode;
        }
    }
}
