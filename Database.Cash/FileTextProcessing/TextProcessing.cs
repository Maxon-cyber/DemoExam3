using System.Collections.Concurrent;

namespace Database.Cash.FileTextProcessing;

internal class TextProcessing
{
    internal static string TextSeparator => new string('-', 40);

    internal IProducerConsumerCollection<string> AddKeyAndValue(string key, IProducerConsumerCollection<string> value)
    {
        ConcurrentQueue<string> text = new ConcurrentQueue<string>();

        text.Enqueue(key);

        foreach (string result in value)
            text.Enqueue(result);

        text.Enqueue(TextSeparator);

        return text;
    }

    internal string[] GetFileText(string path)
    {
        string[] text = File.ReadAllLines(path);

        return text;
    }

    internal int GetKeyLineNumberFromFile(string[] textFile, string key)
    {
        int keyLineNumber = 0;

        for (int index = 0; index < textFile.Length; index++)
        {
            if (textFile[index] == key)
            {
                keyLineNumber = index;
                break;
            }

        }

        return keyLineNumber;
    }
}