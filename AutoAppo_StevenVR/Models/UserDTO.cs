using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoAppo_StevenVR.Models
{
    public class UserDTO
    {
        public RestRequest Request { get; set; }

        public int IDUsuario { get; set; }
        public string Nombre { get; set; } = null;
        public string Correo { get; set; } = null;
        public string NumeroTelefono { get; set; } = null;
        public string Contrasennia { get; set; } = null;
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public int IdRol { get; set; }
        public int IdEstado { get; set; }
        public string EstadoDescripcion { get; set; } = null;
        public string RolDescripcion { get; set; } = null;

        public async Task<UserDTO> GetUserData(string email)
        {
            try
            {
                string RouteSufix = string.Format("Users/GetUserData?email={0}", email);
                 
                string URL = Services.APIConnection.ProductionURLPrefix + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);
                 
                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);
                 
                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<List<UserDTO>>(response.Content);

                    var item = list[0];

                    return item;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                string ErrorMsg = ex.Message;

                throw;
            }

        }


        public async Task<bool> UpdateUser()
        {
            try
            {

                string RouteSufix = string.Format("Users/{0}", this.IDUsuario);

                string URL = Services.APIConnection.ProductionURLPrefix + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Put);

           
                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);

                string SerializedModel = JsonConvert.SerializeObject(this);

                Request.AddBody(SerializedModel, GlobalObjects.MimeType);

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







    }
}