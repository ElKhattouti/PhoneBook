using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PhoneBook_Models;

namespace PhoneBook_Web.Services
{
    public class ApiService
    {

        private static ApiService _api;
        public static ApiService Api
        {
            get
            {
                if (_api == null)
                    Api = new ApiService("https://localhost:5001/api/contact/");
                return _api;
            }
            private set
            {
                if (_api == null)
                    _api = value;
            }
        }

        private static HttpClient _httpClient;
        private static string _baseUrl;

        private ApiService(string BaseUrl)
        {
            _httpClient = new HttpClient();
            _baseUrl = BaseUrl;
        }

        public async Task<ObservableCollection<Contact>> Get()
        {
            HttpResponseMessage response;
            try
            {
                response = await _httpClient.GetAsync(_baseUrl, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();

                var contacts = JsonConvert.DeserializeObject<ObservableCollection<Contact>>(data);
                return contacts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Contact> Get(int id)
        {
            HttpResponseMessage response;
            try
            {
                response = await _httpClient.GetAsync(_baseUrl+id, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();

                var contact = JsonConvert.DeserializeObject<Contact>(data);
                return contact;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Contact> Post(Contact contact)
        {
            HttpResponseMessage response;
            var json = JsonConvert.SerializeObject(contact);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                response = await _httpClient.PostAsync(_baseUrl, content);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();

                contact = JsonConvert.DeserializeObject<Contact>(data);
                return contact;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Contact> Put(Contact contact)
        {
            HttpResponseMessage response;
            var json = JsonConvert.SerializeObject(contact);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                response = await _httpClient.PutAsync(_baseUrl+contact.ContactId, content);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();

                contact = JsonConvert.DeserializeObject<Contact>(data);
                return contact;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
