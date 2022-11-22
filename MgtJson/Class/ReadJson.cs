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

        public String GetValueJson(String TagText)
        {
            String ValueText;

            JObject JsonObject = JObject.Parse(StringJson);
            var Jtoken = JsonObject.GetValue(TagText);
            ValueText = Jtoken.ToString();

            return ValueText;
        }
        public String GetJsonToJson(String JsonTagText)
        {
            String JsonValueText;

            JObject JsonObject = JObject.Parse(StringJson);
            var Jtoken = JsonObject.SelectToken(JsonTagText);
            JsonValueText = Jtoken.ToString();


            return JsonValueText;
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


        public int GetCountJsonArray()
        {
            JArray JsonArray = JArray.Parse(StringJson);
            return JsonArray.Count;
        }

        public String GetJsonTextToJsonArray(int KeyArray)
        {
            JArray JsonArray = JArray.Parse(StringJson);
            var returnValue = JsonArray[KeyArray].ToString();
            return (returnValue);
        }


    }
}
