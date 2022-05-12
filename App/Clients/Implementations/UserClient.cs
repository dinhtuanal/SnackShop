using Clients.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using SharedObjects.Commons;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients.Implementations
{
    public class UserClient : BaseClient, IUserClient
    {
        public async Task<ResponseResult> Add(AddUserViewModel model, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("users/add", content);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var responseResult = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            return responseResult;
        }

        public async Task<ResponseResult> Delete(string userId, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await httpClient.DeleteAsync("users/delete/" + userId);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var responseResult = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            return responseResult;
        }

        public async Task<List<IdentityUser>> GetAll(string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await httpClient.GetAsync("users/");
            var apiResponse = await response.Content.ReadAsStringAsync();
            var responseResult = JsonConvert.DeserializeObject<List<IdentityUser>>(apiResponse);
            return responseResult;
        }

        public async Task<IdentityUser> GetById(string userId, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await httpClient.GetAsync("users/" + userId);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var responseResult = JsonConvert.DeserializeObject<IdentityUser>(apiResponse);
            return responseResult;
        }

        public async Task<ResponseResult> Login(LoginViewModel model)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("users/login", content);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var responseResult = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            return responseResult;
        }

        public async Task<ResponseResult> Update(UpdateUserViewModel model, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("users/update", content);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var responseResult = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            return responseResult;
        }
    }
}
