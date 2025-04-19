using System;
using System.Text;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        // приватные поля
        private string _sequence;
        private string _output;
        private int _current;

        // публичные св-ва
        public string Output => _output;

        // конструктор
        public Blue_2(string input, string sequence) : base(input)
        {
            _sequence = sequence;
            _output = null;
        }

        // методы
        public override void Review()
        {
            if (string.IsNullOrEmpty(Input) || string.IsNullOrEmpty(_sequence))
            {
                _output = "";
                return;
            }

            _output = Input;
            _current = 0;

            while (_current < _output.Length)
            {
                _current = SkipNonLetters(_current);
                if (_current >= _output.Length) break;

                var (wordStart, wordEnd) = FindWordBoundaries(_current);
                if (wordStart == -1) break;

                ProcessWord(wordStart, wordEnd);
            }

            RemoveExtraSpaces();
        }

        private int SkipNonLetters(int start)
        {
            while (start < _output.Length && !char.IsLetter(_output[start]))
            {
                start++;
            }
            return start;
        }

        private (int start, int end) FindWordBoundaries(int start)
        {
            int wordStart = start;
            int current = start;

            while (current < _output.Length && IsWordCharacter(_output[current]))
            {
                current++;
            }

            return (wordStart, current - 1);
        }

        private bool IsWordCharacter(char c)
        {
            return char.IsLetter(c) || c == '\'' || c == '-';
        }

        private void ProcessWord(int wordStart, int wordEnd)
        {
            string word = _output.Substring(wordStart, wordEnd - wordStart + 1);
            
            if (word.IndexOf(_sequence, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                RemoveWord(wordStart, wordEnd);
            }
            else
            {
                _current = wordEnd + 1;
            }
        }

        private void RemoveWord(int wordStart, int wordEnd)
        {
            _output = _output.Remove(wordStart, wordEnd - wordStart + 1);

            if (wordStart > 0 && char.IsWhiteSpace(_output[wordStart - 1]))
            {
                _output = _output.Remove(wordStart - 1, 1);
                _current = wordStart - 1;
            }
            else if (wordStart < _output.Length && char.IsWhiteSpace(_output[wordStart]))
            {
                _output = _output.Remove(wordStart, 1);
                _current = wordStart;
            }
            else
            {
                _current = wordStart;
            }
        }

        private void RemoveExtraSpaces()
        {
            string result = "";
            bool wasSpace = false;

            foreach (char c in _output)
            {
                if (char.IsWhiteSpace(c))
                {
                    if (!wasSpace)
                    {
                        result += ' ';
                        wasSpace = true;
                    }
                }
                else
                {
                    result += c;
                    wasSpace = false;
                }
            }

            _output = result.Trim();
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(_output) ? string.Empty : _output;
        }
    }
}