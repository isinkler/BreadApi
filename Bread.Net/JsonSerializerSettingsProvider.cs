using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Bread.Net
{
    public class JsonSerializerSettingsProvider
    {
        public static JsonSerializerSettings SerializerSettings()
        {
            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            return new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            };
        }
    }
}
