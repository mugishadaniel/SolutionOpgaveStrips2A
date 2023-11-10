using StripsClientWPFReeksView.Exceptions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Documents;
using StripsClientWPFReeksView.ModelOutput;

namespace StripsClientWPFReeksView.Services
{
    public class StripServiceClient
    {
        private HttpClient client;


        public StripServiceClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5044/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }        

        public async Task<ReeksRESToutputDTO> GetReeksAsync(string path)
        {
            ReeksRESToutputDTO reeks = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                reeks = await response.Content.ReadAsAsync<ReeksRESToutputDTO>();
                return reeks;
            }
            else
            {
                return null;
            }
            
        }

    }
}
