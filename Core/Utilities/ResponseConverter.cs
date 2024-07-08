using Newtonsoft.Json;

namespace Core.Utilities;

public static class ResponseConverter
{
    public static T? JsonToTypedObject<T>(string json) => JsonConvert.DeserializeObject<T>(json);
    public static T? JsonToTypedObject<T>(HttpResponseMessage message) => JsonConvert.DeserializeObject<T>(message.Content.ReadAsStringAsync().Result);
}