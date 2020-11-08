using System;
using System.Text.Json;
using ESVBible.Shared.Serialization;

namespace ESVBible.Api.Utilities.Serialization
{
    public class JsonDataSerializer : IJsonDataSerializer
    {
        private readonly JsonSerializerOptions serializerOptions;

        public JsonDataSerializer()
        {
            serializerOptions = JsonConfig.CreateJsonSerializerOptions();
        }

        public string SerializeObject(
            object objectToSerialize)
        {
            return JsonSerializer.Serialize(objectToSerialize, serializerOptions);
        }

        public T DeserializeObject<T>(
            string objectToDeserialize)
        {
            return JsonSerializer.Deserialize<T>(objectToDeserialize, serializerOptions);
        }

        public object DeserializeObject(
            string objectToDeserialize,
            Type objectType)
        {
            return JsonSerializer.Deserialize(objectToDeserialize, objectType);
        }
    }
}