using Newtonsoft.Json;

namespace Bread.WebApi
{
    public class BreadJsonHttpResponseMessageHelper
    {
        public static string Create(BreadResponse response)
        {
            string jsonResponse = JsonConvert.SerializeObject(response);

            return jsonResponse;
        }
    }
}
