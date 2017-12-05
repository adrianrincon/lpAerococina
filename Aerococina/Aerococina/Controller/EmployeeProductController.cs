using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace Aerococina.Controller
{
    public class EmployeeProductController
    {
        public static async Task<Models.ItemResult> GetListEmployeeProduct_Day(int CompanyId)
        {
            #region GetListEmployeeProduct_Day

            try
            {
                #region Set Request

                string json = "{\"CompanyId\":\"" + CompanyId + "\"}";

                var client = new RestClient("http://52.250.107.0/Kamehouse.WebApi");
                var request = new RestRequest("/EmployeeProduct/GetListEmployeeProduct_Day", Method.POST);
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

        public static async Task<Models.ItemResult> AddListEmployeeProduct(List<Models.EmployeeProduct> List)
        {
            #region GetListEmployeeProduct_Day

            try
            {
                #region Set Request

                //string json = "{\"CompanyId\":\"" + CompanyId + "\"}";
                string json = JsonConvert.SerializeObject(List);

                var client = new RestClient("http://52.250.107.0/Kamehouse.WebApi");
                var request = new RestRequest("/EmployeeProduct/AddListEmployeeProduct", Method.POST);
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
