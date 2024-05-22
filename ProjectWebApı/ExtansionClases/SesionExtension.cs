using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ProjectWebApı.ExtansionClases
{
    public  static class SesionExtension
    {
        public static void SetObject(this ISession session,string key,object value)
        {
            string objectstring =  JsonConvert.SerializeObject(value);
            session.SetString(key, objectstring);   

        }

        public static T GetObject<T>(this ISession session,string key) where T:class
        {
            string ObjectString = session.GetString(key);
            if (string.IsNullOrEmpty(ObjectString))
            {
                return null;

            }
            T DeserializedObject =JsonConvert.DeserializeObject<T>(ObjectString);
            return DeserializedObject;
        }
    }
}
