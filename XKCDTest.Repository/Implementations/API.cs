using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using XKCDTest.DTO.ViewModels;
using XKCDTest.Repository.Interfaces;

namespace XKCDTest.Repository.Implementations
{
    public class API: IAPI
    {
        private readonly HttpClient _client;

        public API(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("http://xkcd.com/");
        }

        public async Task<VMComicDetail> GetComicOfDay()
        {
            try
            {
                string endpoint = "/info.0.json";
                var response = await _client.GetAsync(endpoint);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = JsonConvert.DeserializeObject<VMComicDetail>(await response.Content.ReadAsStringAsync());
                    return result;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<VMComicDetail> GetCustomComic(int? id)
        {
            try
            {
                string endpoint = string.Format("/{0}/info.0.json", id);
                var response = await _client.GetAsync(endpoint);
                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = JsonConvert.DeserializeObject<VMComicDetail>(await response.Content.ReadAsStringAsync());
                    return result;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task<int?> GetFirstComicId()
        {
            return Task.Run(() => (int?)1);
        }
    }
}
