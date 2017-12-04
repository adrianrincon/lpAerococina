using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace Aerococina.Controller
{
    public class SecurityController
    {
        public static async Task<Models.ItemResult> Authenticate(string Email, string Password)
        {
            #region Authenticate

            try
            {
                #region Set Request

                string json = "{\"Email\":\"" + Email + "\",\"Password\":\"" + Password + "\"}";

                var client = new RestClient("http://52.250.107.0/Kamehouse.WebApi");
                var request = new RestRequest("/Security/Authenticate", Method.POST);
                request.RequestFormat = DataFormat.Json;
                request.AddParameter("application/json", json, ParameterType.RequestBody);

                #endregion

                #region Get Result

                IRestResponse restResponse = await client.ExecuteTaskAsync(request);
                if (restResponse.StatusCode == HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<Models.ItemResult>(restResponse.Content);
                else
                    return null;

                #endregion
            }
            catch (Exception ex)
            {

                throw ex;
            }

            #endregion
        }
    }
}
