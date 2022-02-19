using System.IO;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace Demo.Common
{
    public static class ModelManager
    {
        public static T JsonToModel<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }

        public static string ModelToJson<T>(T model)
        {
            return JsonSerializer.Serialize<T>(model);
        }

        public static T XmlToModel<T>(string objString)
        {
            var serializer = new XmlSerializer(typeof(T));
            var reader = new StreamReader(objString);
            var obj = (T)serializer.Deserialize(reader);

            reader.Close();

            return obj;
        }

        public static string ModelToXml<T>(T obj)
        {
            var serializer = new XmlSerializer(typeof(T));
            var sww = new StringWriter();
            var writer = XmlWriter.Create(sww);

            serializer.Serialize(writer, obj);

            return sww.ToString(); ;
        }
    }
}