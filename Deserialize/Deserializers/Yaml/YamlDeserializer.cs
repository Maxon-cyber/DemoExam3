using Deserialize.Deserializers;
using YamlDotNet.Serialization;

namespace Deserialize.Deserializers.Yaml;

internal sealed class YamlDeserializer<TModel> : IDeserializer<TModel>
    where TModel : class
{
    public TModel Deserialize(string path, INamingConvention namingConvention)
        => new DeserializerBuilder()
            .WithNamingConvention(namingConvention)
            .Build()
            .Deserialize<TModel>(File.ReadAllText(path));
}