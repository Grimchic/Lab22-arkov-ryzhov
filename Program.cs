using System.Collections.Generic;
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

