using System.Text.Json;

namespace ESVBible.Api.Utilities.Serialization
{
    public static class JsonConfig
    {
        public static JsonSerializerOptions CreateJsonSerializerOptions()
        {
            return new JsonSerializerOptions
            {
                WriteIndented = true,
            };
        }
    }
}