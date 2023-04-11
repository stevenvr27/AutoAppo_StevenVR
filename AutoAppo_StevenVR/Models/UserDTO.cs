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

        //FUNCIONES
        public async Task<UserDTO> GetUserData(string email)
        {
            try
            {
                string RouteSufix = string.Format("Users/GetUserData?email={0}", email);

                //con esto obtenemos la ruta completa de consumo del API 
                string URL = Services.APIConnection.ProductionURLPrefix + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                //agregamos la info de la llave de seguridad (ApiKey) 
                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);

                //ejecución de la llamada al controlador 
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



    }
}
