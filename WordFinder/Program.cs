// See https://aka.ms/new-console-template for more information
using System.Dynamic;

var matrix = new List<string>();

//matrix.Add("ABCDA");
//matrix.Add("CDABA");
//matrix.Add("GHADA");
//matrix.Add("KLBNA");

matrix.Add("EBCDC");
matrix.Add("RGWIO");
matrix.Add("CHILL");
matrix.Add("PQNSD");
matrix.Add("UVDXY");

var wordFinder = new WordFinder.WordFinder(matrix);

List<string> words = new List<string>();
words.Add("COLD");
words.Add("WIND");
words.Add("CHILL");
words.Add("SNOW");
var result = wordFinder.Find(words);

foreach (var word in result)
{
    Console.WriteLine($"word: {word}");
}