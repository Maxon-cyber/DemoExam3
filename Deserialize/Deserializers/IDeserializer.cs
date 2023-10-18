using YamlDotNet.Serialization;

namespace Deserialize.Deserializers;

internal interface IDeserializer<TModel>
    where TModel : class
{
    TModel Deserialize(string path, INamingConvention convention);
}