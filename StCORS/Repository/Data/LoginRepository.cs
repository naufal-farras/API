﻿using API.Models;
using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using StCORS.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StCORS.Repository.Data
{
    public class LoginRepository : GeneralRepository<Person, int>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;

        public LoginRepository(Address address, string request = "person/") : base(address, request)
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

        public async Task<JWTokenVM>Auth(LoginVM loginVM)
        {
            JWTokenVM token = null;
    
            StringContent content = new StringContent(JsonConvert.SerializeObject(loginVM), Encoding.UTF8,"application/json");
            var result = await httpClient.PostAsync(request + "login", content);
             if(result.IsSuccessStatusCode)
            {
                string apiResponse = await result.Content.ReadAsStringAsync();
                token = JsonConvert.DeserializeObject<JWTokenVM>(apiResponse);
            }
            return token;


        }



    }
}
