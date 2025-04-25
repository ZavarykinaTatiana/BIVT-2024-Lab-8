using System;
using System.Linq;

namespace Lab_8
{
    public class Blue_1 : Blue
    {
        // приватные поля
        private string[] _output;

        // публичные св-ва
        public string[] Output => _output;

        // конструктор
        public Blue_1(string input) : base(input) { _output = null; }
        
        // методы
        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = null;
                return;
            }

            var words = Input.Split(' ');
            string[] lines = new string[words.Length];
            string currentLine = "";
            int linesCount = 0;

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                
                if (currentLine.Length + word.Length + 1 <= 50)
                {
                    if (currentLine.Length > 0)
                    {
                        currentLine += " " + word;
                    }
                    else
                    {
                        currentLine += word;
                    }
                }
                else
                {
                    lines[linesCount++] = currentLine;
                    currentLine = word;
                }
            }

            if (currentLine.Length > 0)
            {
                lines[linesCount++] = currentLine;
            }

            _output = new string[linesCount];
            Array.Copy(lines, _output, linesCount);
        }
        public override string ToString()
        {
            if (_output == null || _output.Length == 0) return null;
            return string.Join(Environment.NewLine, _output);
        }
    }
}