using System;

namespace ESVBible.Shared.Serialization
{
    public interface IJsonDataSerializer
    {
        string SerializeObject(
            object objectToSerialize);

        T DeserializeObject<T>(
            string objectToDeserialize);

        object DeserializeObject(
            string objectToDeserialize,
            Type objectType);
    }
}