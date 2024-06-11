using MongoDB.Bson.IO;
using Newtonsoft.Json;
using ProjMongoDBApi10062024.Models;

namespace ProjMongoDBApi10062024.Services
{
    public class PostOfficeService
    {
        static readonly HttpClient address = new HttpClient();

        public static async Task<AddressDTO> GetAddress(string cep)
        {
            try
            {
                HttpResponseMessage response = await address.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

                response.EnsureSuccessStatusCode();

                string a = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<AddressDTO>(a);
            }
            catch(HttpRequestException ex)
            {
                throw;
            }
        }
    }
}
