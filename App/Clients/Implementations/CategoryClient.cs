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
    public class CategoryClient : BaseClient, ICategoryClient
    {
        public async Task<int> Add(CategoryViewModel model, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("categories/add", content);
            return (int)response.StatusCode;
        }

        public async Task<int> Delete(string categoryId, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var result = await httpClient.DeleteAsync("categories/delete/" + categoryId);
            return (int)result.StatusCode;
        }

        public async Task<List<VCategory>> GetAll()
        {
            var response = await httpClient.GetAsync("Categories");
            var content = await response.Content.ReadAsStringAsync();
            List<VCategory> result = JsonConvert.DeserializeObject<List<VCategory>>(content);
            return result;
        }

        public async Task<VCategory> GetById(string categoryId)
        {
            var response = await httpClient.GetAsync("categories/" + categoryId);
            string content = await response.Content.ReadAsStringAsync();
            VCategory result = JsonConvert.DeserializeObject<VCategory>(content);
            return result;
        }

        public async Task<int> Update(CategoryViewModel model, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("categories/update", content);
            return (int)response.StatusCode;
        }
    }
}
