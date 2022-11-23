using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace MgtJson.Class
{
    public class ReadJson
    {
        String StringJson;

        public ReadJson(String NewStringJson)
        {
            StringJson = NewStringJson;
        }

        public String GetValueJson_FromTag(String TagText)
        {
            JObject JsonObject = JObject.Parse(StringJson);
            var Jtoken = JsonObject.GetValue(TagText);
            String ValueText = Jtoken.ToString();

            return ValueText;
        }

        public String GetValueJson_FromKeyArray(int KeyArray)
        {
            JObject JsonObject = JObject.Parse(StringJson);
            JProperty property = JsonObject.Properties().ElementAt(KeyArray);
            String returnValue = property.Value.ToString();
            return (returnValue);
        }

        public String GetTagJson_FromKeyArray(int KeyArray)
        {
            JObject JsonObject = JObject.Parse(StringJson);
            JProperty property = JsonObject.Properties().ElementAt(KeyArray);
            String returnValue = property.Name.ToString();
            return (returnValue);
        }

        public String GetValue_FromJsonArray(int KeyArray)
        {
            JArray JsonArray = JArray.Parse(StringJson);
            String returnValue = JsonArray[KeyArray].ToString();
            return (returnValue);
        }

        public String GetJson_FormJson(String JsonTagText)
        {
            JObject JsonObject = JObject.Parse(StringJson);
            var Jtoken = JsonObject.SelectToken(JsonTagText);
            String JsonValueText = Jtoken.ToString();

            return JsonValueText;
        }
        public int GetCountJson()
        {
            JObject JsonObject = JObject.Parse(StringJson);
            return JsonObject.Properties().Count();
        }

        public int GetCountJsonArray()
        {
            JArray JsonArray = JArray.Parse(StringJson);
            return JsonArray.Count;
        }

        public Boolean ExistsTag(String TagText)
        {
            Boolean IsExistsTag;
            JToken Jtoken;
            JObject JsonObject = JObject.Parse(StringJson);
            if (JsonObject.TryGetValue(TagText, out Jtoken))
            {
                IsExistsTag = true;
            }
            else
            {
                IsExistsTag = false;
            }

            return IsExistsTag;
        }
    }
}
