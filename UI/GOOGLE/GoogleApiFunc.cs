using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsApi;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
using System.Configuration;

namespace UI.GOOGLE
{
    enum TravelType
    {
        Walking,
        Driving
    }
    class GoogleApiFunc
    {
#pragma warning disable CS0618 // Type or member is obsolete
        static string API_KEY = ConfigurationSettings.AppSettings.Get("googleApiKey");
#pragma warning restore CS0618 // Type or member is obsolete

        public static List<string> GetPlaceAutoComplete(string str)
        {
            List<string> result = new List<string>();
            GoogleMapsApi.Entities.PlaceAutocomplete.Request.PlaceAutocompleteRequest request = new GoogleMapsApi.Entities.PlaceAutocomplete.Request.PlaceAutocompleteRequest()
            {
                ApiKey = API_KEY,
                Input = str
            };
            var response = GoogleMaps.PlaceAutocomplete.Query(request);

            foreach (var item in response.Results)
            {
                result.Add(item.Description);
            }
            return result;
        }        
    }
}
