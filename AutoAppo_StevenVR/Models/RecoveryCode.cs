using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoAppo_StevenVR.Models
{
    public class RecoveryCode
    {
        public RestRequest Request { get; set; }

        public int RecoveryCodeId { get; set; }
        public string Email { get; set; } = null;
        public string RecoveryCode1 { get; set; } = null;
 

        //public DateTime GenerateDate { get; set; }
        //public bool IsUsed { get; set; }

        //funciones 
        

        public async Task<bool> ValidateRecoveryCode()
        {
            try
            {
                string RouteSufix = string.Format("RecoveryCodes/ValidateCode?pEmail={0}&pRecoveryCode={1}",
                                                  this.Email, this.RecoveryCode1);

                
                string URL = Services.APIConnection.ProductionURLPrefix + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                 
                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);

                
                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                string ErrorMsg = ex.Message;

                 

                throw;
            }

        }

        public async Task<bool> AddRecoveryCode()
        {
            try
            {
                string RouteSufix = string.Format("RecoveryCodes");

                  
                string URL = Services.APIConnection.ProductionURLPrefix + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Post);

                
                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);

                 
                string SerializedModel = JsonConvert.SerializeObject(this);

                Request.AddBody(SerializedModel, GlobalObjects.MimeType);
 
                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                string ErrorMsg = ex.Message;

                //almacenar registro de errores en una bitacora para analisis posterior 
                //también puede ser enviarlos a un servidor de captura de errores

                throw;


            }
        }

    }
}
