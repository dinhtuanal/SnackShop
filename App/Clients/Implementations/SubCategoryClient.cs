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
    public class SubCategoryClient : BaseClient, ISubCategoryClient
    {
        public async Task<int> Add(SubCategoryViewModel model, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization","Bearer " + token);
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("subcategories/add", content);
            return (int)response.StatusCode;
        }

        public async Task<int> Delete(string subCategoryId, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await httpClient.DeleteAsync("subcategories/delete/{subCategoryId}");
            return (int)response.StatusCode;

        }

        public async Task<List<VSubCategory>> GetAll()
        {
            var response = await httpClient.GetAsync("subcategories");
            var content = await response.Content.ReadAsStringAsync();
            List<VSubCategory> result = JsonConvert.DeserializeObject<List<VSubCategory>>(content);
            return result;
        }

        public async Task<List<VSubCategory>> GetByCategoryId(string categoryId)
        {
            var response = await httpClient.GetAsync("subcategories/{categoryId}/subcategories");
            var content = await response.Content.ReadAsStringAsync();
            List<VSubCategory> result = JsonConvert.DeserializeObject<List<VSubCategory>>(content);
            return result;
        }

        public async Task<VSubCategory> GetById(string subCategoryId)
        {
            var response = await httpClient.GetAsync("subcategories/{subCategoryId}");
            var content = await response.Content.ReadAsStringAsync();
            VSubCategory result = JsonConvert.DeserializeObject<VSubCategory>(content);
            return result;
        }

        public async Task<int> Update(SubCategoryViewModel model, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("subcategories/update", content);
            return (int)response.StatusCode;


        }
    }
}
