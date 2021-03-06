using API.Models;
using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using StCORS.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StCORS.Repository.Data
{

    public class PersonRepository : GeneralRepository<Person, int>
    {      
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;

        public PersonRepository(Address address, string request = "person/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", _contextAccessor.HttpContext.Session.GetString("JWToken"));
        }

        public async Task<List<RegisterVM>> GetAllProfile()
        {
            List<RegisterVM> entities = new List<RegisterVM>();
            using (var response = await httpClient.GetAsync(request + "GetAllProfile"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<RegisterVM>>(apiResponse);
            }
            return entities;
        }
        public async Task<RegisterVM>GetProfilbyId(int nik)
        {
            RegisterVM entities = new RegisterVM();

            using (var response = await httpClient.GetAsync(request + "GetProfilbyId/"+ nik))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<RegisterVM>(apiResponse);
            }
            return entities;

           
        }

    }
}
