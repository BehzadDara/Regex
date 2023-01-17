using System.Text.RegularExpressions;

var words = new List<string>() { "Seven", "even", "Maven", "Amen", "eleven"};
var words2 = new List<string>() { "are", "far", "sir", "and", "door"};
var content = "Foxes are omnivorous mammals belonging to several genera "+
"of the family Canidae. Foxes have a flattened skull, upright triangular ears, "+
"a pointed, slightly upturned snout, and a long bushy tail. Foxes live on every "+
"continent except Antarctica. By far the most common and widespread species of "+
"fox is the red fox. foxeses";
var content2 = "Foxes   are omnivorous mammals.";
string content3 = @"Currency symbols: ฿ Thailand bath, ₹  Indian rupee, ₾ Georgian lari, $ Dollar, € Euro, ¥ Yen, £ Pound Sterling";

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

// * [match zero or more char]
var starMarkRegex = new Regex("fox(es)*", RegexOptions.Compiled | RegexOptions.IgnoreCase);
Console.WriteLine("sample of * in regex:\n");
PrintContent(content, starMarkRegex);
Console.WriteLine("-------------------------------------");

// ^ [match start of word]
var startRegex = new Regex("^ar", RegexOptions.Compiled | RegexOptions.IgnoreCase);
Console.WriteLine("sample of ^ in regex:\n");
PrintWords(words2, startRegex);
Console.WriteLine("-------------------------------------");

// $ [match end of word]
var endRegex = new Regex("ar$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
Console.WriteLine("sample of $ in regex:\n");
PrintWords(words2, endRegex);
Console.WriteLine("-------------------------------------");

// [] [match alphabet of words]
var alphabetRegex = new Regex("[ai]r", RegexOptions.Compiled | RegexOptions.IgnoreCase);
Console.WriteLine("sample of [] in regex:\n");
PrintWords(words2, alphabetRegex);
Console.WriteLine("-------------------------------------");

// [^] [match alphabet of words]
var notAlphabetRegex = new Regex("[^ai]r", RegexOptions.Compiled | RegexOptions.IgnoreCase);
Console.WriteLine("sample of [^] in regex:\n");
PrintWords(words2, notAlphabetRegex);
Console.WriteLine("-------------------------------------");

// \p{S} [match symbols] ( {Sc} and others for types of filter on symbols )
var backSlashPS = new Regex(@"\p{S}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
Console.WriteLine("sample of \\p{Sc} in regex:\n");
PrintContent(content3, backSlashPS);
Console.WriteLine("-------------------------------------");

// \s [match spaces]
var backSlashS = new Regex(@"\s", RegexOptions.Compiled | RegexOptions.IgnoreCase);
Console.WriteLine("sample of \\s in regex:\n");
PrintContent(content2, backSlashS);
Console.WriteLine("-------------------------------------");

// \s+ [match one or more spaces]
var backSlashSPlus = new Regex(@"\s+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
Console.WriteLine("sample of \\s+ in regex:\n");
PrintContent(content2, backSlashSPlus);
Console.WriteLine("-------------------------------------");

// \s\s+ [match more than one spaces]
var backSlashSSPlus = new Regex(@"\s\s+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
Console.WriteLine("sample of \\s\\s+ in regex:\n");
PrintContent(content2, backSlashSSPlus);
Console.WriteLine("-------------------------------------");

// \w [match chars]
var backSlashW = new Regex(@"\w", RegexOptions.Compiled | RegexOptions.IgnoreCase);
Console.WriteLine("sample of \\w in regex:\n");
PrintContent(content2, backSlashW);
Console.WriteLine("-------------------------------------");

// \b(\w+\s*)+\. [math whole word]
var backSlashWS = new Regex(@"\b(\w+\s*)+\.", RegexOptions.Compiled | RegexOptions.IgnoreCase);
Console.WriteLine("sample of \\b(\\w+\\s*)+\\. in regex:\n");
PrintContentCaptures(content2, backSlashWS);
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

static void PrintContentCaptures(string content, Regex regex)
{
    Match match = regex.Match(content);

    while (match.Success)
    {
        foreach (Group group in match.Groups)
        {
            foreach (Capture capture in group.Captures)
            {
                Console.WriteLine($"Group {group.Index}, Capture {capture.Index}: {capture.Value}");
            }
        }

        match = match.NextMatch();
    }
}