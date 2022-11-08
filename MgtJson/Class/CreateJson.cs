using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MgtJson.Class
{
    public class CreateJson
    {
        private JsonTextWriter jsonWriter;
        StringBuilder buldier;
        StringWriter writer;

        public CreateJson()
        {
            buldier = new StringBuilder();
            writer = new StringWriter(buldier);
            jsonWriter = new JsonTextWriter(writer);
            jsonWriter.Formatting = Formatting.Indented;

        }

        public String ReturnJSon()
        {
            jsonWriter.Flush();
            string jsonstr = buldier.ToString();
            return jsonstr;
        }

        public void AddLine(String tag, String valor)
        {
            jsonWriter.WritePropertyName(tag);
            jsonWriter.WriteValue(valor);
        }

        public void InitJson()
        {
            jsonWriter.WriteStartObject();
        }

        public void EndJson()
        {
            jsonWriter.WriteEndObject();
        }

        public void InitAnidado(String tagAnidado)
        {
            if (tagAnidado != "")
            {
                jsonWriter.WritePropertyName(tagAnidado);
            }

            jsonWriter.WriteStartObject();
        }

        public void EndAnidado()
        {
            jsonWriter.WriteEndObject();
        }

        public void InitArray(String tagArray)
        {
            if (tagArray != "")
            {
                jsonWriter.WritePropertyName(tagArray);
            }
            jsonWriter.WriteStartArray();
        }

        public void EndArray()
        {
            jsonWriter.WriteEndArray();
        }
    }
}