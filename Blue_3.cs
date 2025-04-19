using System;
using System.Linq;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        // приватные поля
        private (char letter, double percent)[] _output;

        // публичные св-ва
        public (char letter, double percent)[] Output => _output;

        // конструктор
        public Blue_3(string input) : base(input)
        {
            _output = Array.Empty<(char, double)>();
        }

        // методы
        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = Array.Empty<(char, double)>();
                return;
            }

            char[] punctuation = { ' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
            string[] words = Input.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
            
            int totalWords = 0;
            int[] letterCounts = new int[1104];
            bool[] usedLetters = new bool[1104];

            foreach (string word in words)
            {
                if (string.IsNullOrWhiteSpace(word)) continue;

                char firstLetter = char.ToLower(word[0]);
                if (char.IsLetter(firstLetter))
                {
                    int index = firstLetter;
                    letterCounts[index]++;
                    usedLetters[index] = true;
                    totalWords++;
                }
            }

            var results = new (char letter, double percent)[0];
            for (int i = 0; i < 1104; i++)
            {
                if (usedLetters[i])
                {
                    char letter = (char)i;
                    double percent = Math.Round(letterCounts[i] * 100.0 / totalWords, 4);
                    Array.Resize(ref results, results.Length + 1);
                    results[results.Length - 1] = (letter, percent);
                }
            }

            _output = results
                .OrderByDescending(x => x.percent)
                .ThenBy(x => x.letter)
                .ToArray();
        }

        public override string ToString()
        {
            return string.Join("\n", _output.Select(x => $"{x.letter} - {x.percent.ToString("F4", System.Globalization.CultureInfo.GetCultureInfo("ru-RU"))}"));
        }
    }
}