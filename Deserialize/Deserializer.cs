using Deserialize.Exceptions;
using Deserialize.Deserializers.Yaml;
using YamlDotNet.Serialization.NamingConventions;

namespace Deserialize;

public static class Deserializer<TModel>
    where TModel: class
{
    public static TModel Deserialize(string path)
        => GetFileExtension(path) switch
        {
            ".yml" => new YamlDeserializer<TModel>().Deserialize(path, PascalCaseNamingConvention.Instance),
            _ => throw new UnknowFileExtensionException("Неизвестное расширение файла")
        };

    private static string GetFileExtension(string path)
        => path[path.IndexOf(".")..];
}