using System.Text.RegularExpressions;

var words = new List<string>() { "Seven", "even", "Maven", "Amen", "eleven" };

var content = @"Foxes are omnivorous mammals belonging to several genera
of the family Canidae. Foxes have a flattened skull, upright triangular ears,
a pointed, slightly upturned snout, and a long bushy tail. Foxes live on every
continent except Antarctica. By far the most common and widespread species of
fox is the red fox. foxeses";

// . [match any single char]

var dotMarkRegex = new Regex(@".even", RegexOptions.Compiled | RegexOptions.IgnoreCase);
Console.WriteLine("sample of . in regex:\n");
PrintWords(words, dotMarkRegex);
Console.WriteLine("-------------------------------------");

// ? [match zero or one char]
var questionMarkRegex = new Regex(@"/?even", RegexOptions.Compiled | RegexOptions.IgnoreCase);
Console.WriteLine("sample of ? in regex:\n");
PrintWords(words, questionMarkRegex);
Console.WriteLine("-------------------------------------");

var questionMarkRegex2 = new Regex("fox(es)?", RegexOptions.Compiled | RegexOptions.IgnoreCase);
Console.WriteLine("sample of ? in regex:\n");
PrintContent(content, questionMarkRegex2);
Console.WriteLine("-------------------------------------");

// + [match one or more char]
var plusMarkRegex = new Regex("fox(es)+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
Console.WriteLine("sample of + in regex:\n");
PrintContent(content, plusMarkRegex);
Console.WriteLine("-------------------------------------");

// * [match one or more char]
var starMarkRegex = new Regex("fox(es)*", RegexOptions.Compiled | RegexOptions.IgnoreCase);
Console.WriteLine("sample of * in regex:\n");
PrintContent(content, starMarkRegex);
Console.WriteLine("-------------------------------------");



static void PrintWords(List<string> words, Regex regex)
{
    foreach (string word in words)
    {
        if (regex.IsMatch(word))
        {
            Console.WriteLine($"{word}: OK");
        }
        else
        {
            Console.WriteLine($"{word}: ERROR");
        }
    }
}

static void PrintContent(string content, Regex regex)
{
    Match match = regex.Match(content);

    while (match.Success)
    {
        Console.WriteLine($"{match.Value} at index {match.Index}");
        match = match.NextMatch();
    }
}