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
        static string TOKEN = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjdkZjJlOGM4LWIxYzEtNDdiZi1iNGI0LWI5MTY4Y2JiYjI5YyIsImlhdCI6MTUzNDcxNTIxNCwic3ViIjoiZGV2ZWxvcGVyL2NlMDg1ODZiLTQ3NDItNjUyYy1iODYzLWFlZTE5N2QwMTVhZCIsInNjb3BlcyI6WyJyb3lhbGUiXSwibGltaXRzIjpbeyJ0aWVyIjoiZGV2ZWxvcGVyL3NpbHZlciIsInR5cGUiOiJ0aHJvdHRsaW5nIn0seyJjaWRycyI6WyIxODkuMjM3LjIzMS4xMTAiXSwidHlwZSI6ImNsaWVudCJ9XX0.CdUtL3gdG56QES24ZIc7XqKpYGOZGQNlPm7HeZu8 - AlQoFf3W98yAS_mlXrwagISK946L6GN179U20UO7tc0-g";
        static string clansPath = "/clans";
        static string apiPath = "https://api.clashroyale.com/v1";
        static string clanName = "mexic anos";

        public static async Task<string> GetClanMembersAsync()
        {
            //curl -X GET --header "Accept: application/json" --header "authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjdkZjJlOGM4LWIxYzEtNDdiZi1iNGI0LWI5MTY4Y2JiYjI5YyIsImlhdCI6MTUzNDcxNTIxNCwic3ViIjoiZGV2ZWxvcGVyL2NlMDg1ODZiLTQ3NDItNjUyYy1iODYzLWFlZTE5N2QwMTVhZCIsInNjb3BlcyI6WyJyb3lhbGUiXSwibGltaXRzIjpbeyJ0aWVyIjoiZGV2ZWxvcGVyL3NpbHZlciIsInR5cGUiOiJ0aHJvdHRsaW5nIn0seyJjaWRycyI6WyIxODkuMjM3LjIzMS4xMTAiXSwidHlwZSI6ImNsaWVudCJ9XX0.CdUtL3gdG56QES24ZIc7XqKpYGOZGQNlPm7HeZu8 - AlQoFf3W98yAS_mlXrwagISK946L6GN179U20UO7tc0-g" "https://api.clashroyale.com/v1/clans?name=mexic%20anos"
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
