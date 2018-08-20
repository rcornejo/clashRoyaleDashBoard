using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleDashBoard
{
    class ClashRoyaleHttpHelper
    {
        static HttpClient client = new HttpClient();
        
        static string clansPath = "/clans";
        static string apiPath = "https://api.clashroyale.com/v1";
        static string clanName = "mexic anos";

        public static async Task<string> GetClanMembersAsync()
        {
            //curl -X GET --header "Accept: application/json" --header "authorization: Bearer TOKEN" "https://api.clashroyale.com/v1/clans?name=mexic%20anos"
            string path = String.Format("{0}{1}", apiPath, clansPath,TOKEN);
            string responseString = String.Empty;
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("authorization", "Bearer "+TOKEN);

            //path = "https://api.clashroyale.com/v1/clans?name=mexic%20anos";
            path = "https://api.clashroyale.com/v1/clans/%232Y2LV9G/warlog";
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                responseString = await response.Content.ReadAsStringAsync();
            }
            return responseString;
        }
    }
}
