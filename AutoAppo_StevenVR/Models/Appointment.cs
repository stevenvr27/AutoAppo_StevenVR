 
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;
namespace AutoAppo_StevenVR.Models
{
    public class Appointment
    {
        public RestRequest Request { get; set; }

        public int AppointmentId { get; set; }
        public DateTime AppoDate { get; set; }
        public int AppoStart { get; set; }
        public int AppoEnd { get; set; }
        public DateTime CreationDate { get; set; }
        public string? Notes { get; set; }
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public int ScheduleId { get; set; }
        public int AppoStatusId { get; set; }

        public virtual AppoStatus AppoStatus { get; set; } = null!;
        public virtual Schedule Schedule { get; set; } = null!;
        public virtual Service Service { get; set; } = null!;
        public virtual User User { get; set; } = null!;


        public async Task<ObservableCollection<Appointment>> GetAppointmentListByUser()
        {
            try
            {
                string RouteSufix = string.Format("Appointments/GetAppointmentListByUser?pUserID={0}",
                                                  this.UserId);
                string URL = Services.APIConnection.ProductionURLPrefix + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

               
                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);

               
                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var AppoList = JsonConvert.DeserializeObject<ObservableCollection<Appointment>>(response.Content);

                    return AppoList;
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
