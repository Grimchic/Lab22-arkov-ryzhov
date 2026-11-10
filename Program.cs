// using System.Collections.Generic;
// Dictionary<string, int> frequencies = new Dictionary<string, int>();

// frequencies.Add("код", 2);
// frequencies.Add("тест", 1);

// Console.WriteLine(frequencies.Count);
// Console.WriteLine(frequencies["код"]);


// Dictionary<string, int> repeated = new Dictionary<string, int>();
// repeated.Add("код", 1);
// repeated.Add("код", 2);

// Console.WriteLine(frequencies["код"]);
// Console.WriteLine(frequencies.Count);


// Dictionary<string, int> lookup = new Dictionary<string, int>
// {
//     { "код", 2 },
//     { "тест", 1 }
// };

// Console.WriteLine(lookup.ContainsKey("код"));
// Console.WriteLine(lookup.ContainsKey("план"));

// if (lookup.TryGetValue("код", out int count))
// {
//     Console.WriteLine($"Найдено: {count}");
// }
// void PrintFrequencies(Dictionary<string, int> frequencies)
// {
//     if (frequencies.Count == 0)
//     {
//         Console.WriteLine("Нет слов для анализа");
//         return;
//     }

//     foreach (KeyValuePair<string, int> entry in frequencies)
//     {
//         Console.WriteLine($"{entry.Key}: {entry.Value}");
//     }
// }


// HashSet<string> uniqueWords = new HashSet<string>();
// string[] words = { "код", "код", "тест" };
// HashSet<string> unique = new HashSet<string>(words);

// Console.WriteLine($"Всего слов: {words.Length}");
// Console.WriteLine($"Разных слов: {unique.Count}");

// Console.WriteLine(uniqueWords.Contains("код"));
// Console.WriteLine(uniqueWords.Contains("план"));
// Console.WriteLine(uniqueWords.Remove("тест"));
// Console.WriteLine(uniqueWords.Remove("план"));
// Console.WriteLine(uniqueWords.Count);


// void AddWord(Dictionary<string, int> frequencies, string word)
// {
//     if (frequencies.TryGetValue(word, out int count))
//     {
//         frequencies[word] = count + 1;
//     }
//     else
//     {
//         frequencies.Add(word, 1);
//     }
// }
// int SumFrequencies(Dictionary<string, int> frequencies)
// {
//     int sum = 0;

//     foreach (KeyValuePair<string, int> entry in frequencies)
//     {
//         sum += entry.Value;
//     }

//     return sum;
// }


// HashSet<string> first = new HashSet<string> { "код", "тест" };
// HashSet<string> second = new HashSet<string> { "тест", "план" };

// HashSet<string> union = new HashSet<string>(first);
// union.UnionWith(second);

// HashSet<string> intersection = new HashSet<string>(first);
// intersection.IntersectWith(second);

// HashSet<string> difference = new HashSet<string>(first);
// difference.ExceptWith(second);


using System.Collections.Generic;

HashSet<string> excludedWords = new HashSet<string> { "и", "в", "на" };

Console.Write("Введите слово для добавления в исключения: ");
string wordToAdd = Console.ReadLine() ?? "";

if (excludedWords.Add(wordToAdd.Trim().ToLowerInvariant()))
{
    Console.WriteLine("Исключение добавлено");
}
else
{
    Console.WriteLine("Такое исключение уже есть");
}

Console.Write("Введите слово для удаления из исключений: ");
string wordToRemove = Console.ReadLine() ?? "";

if (excludedWords.Remove(wordToRemove.Trim().ToLowerInvariant()))
{
    Console.WriteLine("Исключение удалено");
}
else
{
    Console.WriteLine("Такого исключения нет");
}

Console.WriteLine($"Количество исключений: {excludedWords.Count}");

Console.Write("Введите текст: ");
string text = Console.ReadLine() ?? "";
string source = text;

string[] words = text.ToLowerInvariant()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

Dictionary<string, int> frequencies = new Dictionary<string, int>();

foreach (string word in words)
{
    if (!excludedWords.Contains(word))
    {
        AddWord(frequencies, word);
    }
}

Console.WriteLine();
Console.WriteLine(">>> Анализ слов <<<");
Console.WriteLine();
Console.WriteLine($"Исходная строка: [{source}]");
Console.WriteLine($"Всего слов: {words.Length}");
Console.WriteLine($"Пропущено слов: {words.Length - SumFrequencies(frequencies)}");
Console.WriteLine($"Учтено слов: {SumFrequencies(frequencies)}");
Console.WriteLine($"Разных учтённых слов: {frequencies.Count}");
Console.WriteLine();
Console.WriteLine("Частоты слов:");
PrintFrequencies(frequencies);

Console.Write("Введите слово для поиска: ");
string searchWord = Console.ReadLine() ?? "";

if (frequencies.TryGetValue(searchWord.Trim().ToLowerInvariant(), out int found))
{
    Console.WriteLine($"Количество вхождений: {found}");
}
else
{
    Console.WriteLine("Слово не найдено");
}

Console.Write("Введите limit: ");
int limit = int.Parse(Console.ReadLine() ?? "0");

Console.WriteLine($"Слов с частотой не меньше {limit}: {CountFrequentWords(frequencies, limit)}");

void PrintFrequencies(Dictionary<string, int> frequencies)
{
    if (frequencies.Count == 0)
    {
        Console.WriteLine("Нет слов для анализа");
        return;
    }

    foreach (KeyValuePair<string, int> entry in frequencies)
    {
        Console.WriteLine($"{entry.Key}: {entry.Value}");
    }
}

void AddWord(Dictionary<string, int> frequencies, string word)
{
    if (frequencies.TryGetValue(word, out int count))
    {
        frequencies[word] = count + 1;
    }
    else
    {
        frequencies.Add(word, 1);
    }
}

int SumFrequencies(Dictionary<string, int> frequencies)
{
    int sum = 0;

    foreach (KeyValuePair<string, int> entry in frequencies)
    {
        sum += entry.Value;
    }

    return sum;
}

int CountFrequentWords(Dictionary<string, int> frequencies, int limit)
{
    int result = 0;

    foreach (KeyValuePair<string, int> entry in frequencies)
    {
        if (entry.Value >= limit)
        {
            result++;
        }
    }

    return result;
}



