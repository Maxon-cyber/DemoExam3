using Database.Cash.FileTextProcessing;
using Database.Cash.StorageLocation;
using System.Collections.Concurrent;

namespace Database.Cash;

public static class Cash
{
    private const int MAX_CAPACITY_STORAGE = 1_000;

    private static readonly string[] _textFile = null!;
    private static readonly TextProcessing _textProcessing = new TextProcessing();

    public static long FreeSpace => MAX_CAPACITY_STORAGE - _textFile.LongLength;

    static Cash() => _textFile = _textProcessing.GetFileText(PathStorageLocation.Path);

    public static bool TryAdd(string fileName ,string key, IProducerConsumerCollection<string> value)
    {
        if (_textFile.Length < MAX_CAPACITY_STORAGE && !Contains(key))
        {
            File.AppendAllLines(fileName, _textProcessing.AddKeyAndValue(key, value));
            return true;
        }

        return false;
    }

    public static IProducerConsumerCollection<string> Take(string key)
    {
        ConcurrentQueue<string> value = new ConcurrentQueue<string>();

        int initialIndexKey = _textProcessing.GetKeyLineNumberFromFile(_textFile, key);

        foreach (string text in _textFile)
            if (text == key)
                for (int index = initialIndexKey + 1; _textFile[index] != TextProcessing.TextSeparator; index++)
                    value.Enqueue($"{_textFile[index]}\n");

        return value;
    }

    public static bool Contains(string key)
    {
        for (int index = 0; index < _textFile.Length; index++)
            if (_textFile[index] == key)
                return true;

        return false;
    }
}